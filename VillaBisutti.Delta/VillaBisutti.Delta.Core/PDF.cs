using System;
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
	class PDF
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
		public void AddHeader(DateTime data, string casa, string homenageados, string tipoEvento, string cerimonial, string horario, string perfil)
		{
			iPdf.PdfPTable table = new iPdf.PdfPTable(3);
			table.WidthPercentage = 100F;
			table.SetWidths(new float[] { 1F, 1F, 1F });
			table.SpacingBefore = 10F;
			table.SpacingAfter = 10F;
			iText.Chunk headChunk = new iText.Chunk(string.Format("{0} > {1} > {2}", data.ToString("dd/MM/yyyy"), casa, homenageados));
			headChunk.Font = iText.FontFactory.GetFont(baseFont, headingSize, iText.Font.BOLD);
			iPdf.PdfPCell headerCell = new iPdf.PdfPCell(new iText.Phrase(headChunk));
			headerCell.Colspan = 3;
			table.AddCell(headerCell);
			table.AddCell(new iPdf.PdfPCell(MakePhrase("Evento: ", tipoEvento)));
			if (string.IsNullOrEmpty(cerimonial))
				table.AddCell(new iPdf.PdfPCell(MakePhrase("", "")));
			else
				table.AddCell(new iPdf.PdfPCell(MakePhrase("Cerimonial:", tipoEvento)));
			table.AddCell(new iPdf.PdfPCell(MakePhrase("Horário:", horario)));
			iPdf.PdfPCell detailCell = new iPdf.PdfPCell(MakePhrase("Perfil: ", perfil));
			detailCell.Colspan = 3;
			table.AddCell(new iPdf.PdfPCell(detailCell));
			document.Add(table);
		}
		public void AddLeadText(string text)
		{
			iText.Chunk chunck = new iText.Chunk(text);
			chunck.Font = iText.FontFactory.GetFont(baseFont, 11, iText.Font.BOLD, iText.BaseColor.BLACK);
			iText.Paragraph paragraph = new iText.Paragraph(chunck);
			document.Add(paragraph);
		}
		public iText.Phrase MakePhrase(string lead, string text)
		{
			iText.Chunk leadChunk = new iText.Chunk(lead);
			leadChunk.Font = iText.FontFactory.GetFont(baseFont, normalSize, iText.Font.BOLD);
			iText.Chunk textChunck = new iText.Chunk(text);
			iText.Phrase phrase = new iText.Phrase();
			phrase.Add(leadChunk);
			phrase.Add(textChunck);
			return phrase;
		}
		public void AddLine(string text, bool important)
		{
			iText.Chunk chunck = new iText.Chunk(text);
			if (important)
				chunck.Font = iText.FontFactory.GetFont(baseFont, 11, iText.Font.BOLD, iText.BaseColor.RED);
			else
				chunck.Font = iText.FontFactory.GetFont(baseFont, 11, iText.Font.NORMAL, iText.BaseColor.BLACK);
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
		public void BreakPage()
		{
			document.NewPage();
		}
	}
}
