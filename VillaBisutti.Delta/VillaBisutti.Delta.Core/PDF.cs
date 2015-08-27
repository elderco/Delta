﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText = iTextSharp.text;
using iPdf = iTextSharp.text.pdf;
using System.Drawing.Imaging;

namespace VillaBisutti.Delta.Core
{
	public class PDF
	{
		private const int headingSize = 13;
		private const int leadSize = 12;
		private const int normalSize = 11;
		private const int smallSize = 9;

		string baseFont = "Verdana";
		public string FileName { get; set; }
		private FileStream _stream;
		private FileStream stream
		{
			get
			{
				if (_stream == null)
					_stream = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
				return _stream;
			}
		}
		private iText.Document _document;
		private iText.Document document
		{
			get
			{
				if (_document == null)
					_document = new iText.Document(iText.PageSize.A4);
				return _document;
			}
		}
		private iPdf.PdfWriter _writer;
		private iPdf.PdfWriter writer
		{
			get
			{
				if (_writer == null)
					_writer = iPdf.PdfWriter.GetInstance(document, stream);
				return _writer;
			}
		}
		public PDF(string file)
		{
			FileName = file;
		}
		public void PrepareForWriting()
		{
			writer.Open();
			document.Open();
		}
		public void FinishWriting()
		{
			document.Close();
			document.Dispose();
			writer.Close();
			writer.Dispose();
		}
		private iPdf.PdfPTable header;
		private iPdf.PdfPTable Header
		{
			get
			{
				if (header == null)
					throw new InvalidOperationException("Cabeçalho não definido");
				return header;
			}
		}
		private iText.Phrase MakePhrase(string lead, string text)
		{
			iText.Chunk leadChunk = new iText.Chunk(lead);
			leadChunk.Font = iText.FontFactory.GetFont(baseFont, normalSize, iText.Font.BOLD);
			iText.Chunk textChunck = new iText.Chunk(text);
			iText.Phrase phrase = new iText.Phrase();
			phrase.Add(leadChunk);
			phrase.Add(textChunck);
			return phrase;
		}
		public void SetHeader(DateTime data, string casa, string tipoEvento, string homenageados, int pax, string horario, string cerimonial, string produtor, string contatoProdutor, string assessoria, string contatoAssessoria, string responsavel, string contatoResponsavel, string perfil)
		{
			header = new iPdf.PdfPTable(3);
			header.WidthPercentage = 100F;
			header.SetWidths(new float[] { 1F, 1F, 1F });
			header.SpacingBefore = 10F;
			header.SpacingAfter = 10F;

			iText.Chunk headChunk = new iText.Chunk(
				string.Format("{0} > {1} > {2} > {3}", data.ToString("dd/MM/yyyy"), casa, tipoEvento, homenageados));
			headChunk.Font = iText.FontFactory.GetFont(baseFont, headingSize, iText.Font.BOLD);
			iPdf.PdfPCell headerCell = new iPdf.PdfPCell(new iText.Phrase(headChunk));
			headerCell.Colspan = 3;
			header.AddCell(headerCell);

			header.AddCell(new iPdf.PdfPCell(MakePhrase("Pax: ", string.Format("{0} +10% ({1})", pax, (int)(pax * 1.1)))));
			header.AddCell(new iPdf.PdfPCell(MakePhrase("Horário:", horario)));
			header.AddCell(new iPdf.PdfPCell(MakePhrase("Cerimonial: ", cerimonial)));

			iPdf.PdfPCell detailCell = new iPdf.PdfPCell(MakePhrase("Perfil: ", perfil));
			detailCell.Rowspan = 3;
			header.AddCell(new iPdf.PdfPCell(detailCell));

			header.AddCell(new iPdf.PdfPCell(MakePhrase("Produtor(a): ", produtor)));
			header.AddCell(new iPdf.PdfPCell(MakePhrase("Contato: ", contatoProdutor)));

			header.AddCell(new iPdf.PdfPCell(MakePhrase("Assessoria: ", assessoria)));
			if (string.IsNullOrEmpty(contatoAssessoria))
				header.AddCell(new iPdf.PdfPCell(new iText.Phrase("")));
			else
				header.AddCell(new iPdf.PdfPCell(MakePhrase("Contato: ", contatoAssessoria)));

			header.AddCell(new iPdf.PdfPCell(MakePhrase("Responsável(a): ", responsavel)));
			header.AddCell(new iPdf.PdfPCell(MakePhrase("Contato: ", contatoResponsavel)));
		}
		public void AddHeader()
		{
			document.Add(Header);
		}
		public void AddLeadText(string text)
		{
			iText.Chunk chunck = new iText.Chunk(text);
			chunck.Font = iText.FontFactory.GetFont(baseFont, leadSize, iText.Font.BOLD, iText.BaseColor.BLACK);
			iText.Paragraph paragraph = new iText.Paragraph(chunck);
			document.Add(paragraph);
		}
		public void AddLineNoEmphasis(string text)
		{
			iText.Chunk chunck = new iText.Chunk(text);
				chunck.Font = iText.FontFactory.GetFont(baseFont, smallSize, iText.Font.NORMAL, iText.BaseColor.BLACK);
			iText.Paragraph paragraph = new iText.Paragraph(chunck);
			document.Add(paragraph);
		}
		public void AddLine(string text)
		{
			AddLine(text, false);
		}
		public void AddLine(string text, bool important)
		{
			iText.Chunk chunck = new iText.Chunk(text);
			if (important)
				chunck.Font = iText.FontFactory.GetFont(baseFont, leadSize, iText.Font.BOLD, iText.BaseColor.RED);
			else
				chunck.Font = iText.FontFactory.GetFont(baseFont, normalSize, iText.Font.NORMAL, iText.BaseColor.BLACK);
			iText.Paragraph paragraph = new iText.Paragraph(chunck);
			document.Add(paragraph);
		}
		public void AddImage(string path, string legenda, int width)
		{
			iText.Image image = iText.Image.GetInstance(path);
			image.ScaleToFit((float)width, (float)image.Height * (width / image.Width));
			image.Alignment = iText.Image.ALIGN_LEFT;
			document.Add(image);
			iText.Paragraph paragraph = new iText.Paragraph();
			paragraph.Alignment = iText.Element.ALIGN_JUSTIFIED;
			iText.Chunk chunk = new iText.Chunk(legenda);
			chunk.Font = iText.FontFactory.GetFont(baseFont, smallSize, iText.BaseColor.DARK_GRAY);
			paragraph.Add(chunk);
			document.Add(paragraph);
		}
		public void AddBreakRule()
		{
			iPdf.draw.LineSeparator line = new iPdf.draw.LineSeparator(1F, 100F, iText.BaseColor.DARK_GRAY, iText.Element.ALIGN_CENTER, -8F);
			document.Add(line);
			AddLine(" ", false);
		}
		public void BreakLine()
		{
			AddLine("");
		}
		public void BreakPage()
		{
			document.NewPage();
		}
	}
}