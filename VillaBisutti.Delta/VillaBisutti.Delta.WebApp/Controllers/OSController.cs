using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using io = System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ICSharpCode.SharpZipLib.Core;
using dto = VillaBisutti.Delta.Core.DTO;

namespace VillaBisutti.Delta.WebApp.Controllers
{
	public class OSController : Controller
	{
		//
		// GET: /OS/
		public ActionResult Index()
		{
			return View();
		}
		public ActionResult Filtered(int y = 0, int m = 0)
		{
			dto.FileSys files = new dto.FileSys();
			if (y == 0)
				y = DateTime.Now.Year;
			if (m == 0)
				m = DateTime.Now.Month;
			if (Directory.Exists(Server.MapPath(string.Format("~/OS/{0}/{1}/{2}/", Util.TipoDocumentoOS, y, m))))
				foreach (string file in Directory.GetFiles(Server.MapPath(string.Format("~/OS/{0}/{1}/{2}/", Util.TipoDocumentoOS, y, m))))
					files.OSs.Add(file.Substring(file.LastIndexOf("\\") + 1));
			if (Directory.Exists(Server.MapPath(string.Format("~/OS/{0}/{1}/{2}/", Util.TipoDocumentoDegustacao, y, m))))
				foreach (string file in Directory.GetFiles(Server.MapPath(string.Format("~/OS/{0}/{1}/{2}/", Util.TipoDocumentoDegustacao, y, m))))
					files.Degustacoes.Add(file.Substring(file.LastIndexOf("\\") + 1));
			if (Directory.Exists(Server.MapPath(string.Format("~/OS/{0}/{1}/{2}/", Util.TipoDocumentoCapa, y, m))))
				foreach (string file in Directory.GetFiles(Server.MapPath(string.Format("~/OS/{0}/{1}/{2}/", Util.TipoDocumentoCapa, y, m))))
					files.Capas.Add(file.Substring(file.LastIndexOf("\\") + 1));
			return View(files);
		}
		public ActionResult ListDownloads()
		{
			return View();
		}
		public ActionResult AddDownload(string file)
		{
			string fileName = HandleFileName(file);
			if (!SessionFacade.FilesToDownload.Exists(f => f == fileName))
				SessionFacade.FilesToDownload.Add(fileName);
			return RedirectToAction("ListDownloads");
		}
		public ActionResult RemoveDownload(string file)
		{
			string fileName = HandleFileName(file);
			if (SessionFacade.FilesToDownload.Exists(f => f == file))
				SessionFacade.FilesToDownload.Remove(file);
			return RedirectToAction("ListDownloads");
		}
		public ActionResult Download()
		{
			if (SessionFacade.FilesToDownload.Count > 0)
			{
				// Create the ZIP file that will be downloaded. Need to name the file something unique ...
				string strNow = DateTime.Now.ToString("yyyyMMddhhmmss");
				ZipOutputStream zipOS = new ZipOutputStream(io.File.Create(Server.MapPath("~/OS/") + strNow + ".zip"));
				zipOS.SetLevel(5); // ranges 0 to 9 ... 0 = no compression : 9 = max compression

				// Loop through the dataset to fill the zip file
				foreach (string fileName in SessionFacade.FilesToDownload)
				{
					FileInfo fi = new FileInfo(Server.MapPath("~/OS/" + fileName));

					string entryName = fileName.Substring(fileName.LastIndexOf("/") + 1);
					ZipEntry newEntry = new ZipEntry(entryName);
					newEntry.DateTime = fi.LastWriteTime;
					zipOS.UseZip64 = UseZip64.Off;
					newEntry.Size = fi.Length;

					zipOS.PutNextEntry(newEntry);

					// Zip the file in buffered chunks
					// the "using" will close the stream even if an exception occurs
					byte[] buffer = new byte[4096];
					using (FileStream streamReader = io.File.OpenRead(Server.MapPath("~/OS/" + fileName)))
					{
						StreamUtils.Copy(streamReader, zipOS, buffer);
					}
					zipOS.CloseEntry();
				}
				zipOS.Finish();
				zipOS.Close();
				FileInfo file = new FileInfo(Server.MapPath("~/OS/") + strNow + ".zip");
				if (file.Exists)
				{
					Response.Clear();
					Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
					Response.AddHeader("Content-Length", file.Length.ToString());
					Response.ContentType = "application/zip";
					Response.WriteFile(file.FullName);
					Response.Flush();
					file.Delete();
					Response.End();
				}
				SessionFacade.FilesToDownload.Clear();
				return new EmptyResult();
			}
			else
			{
				Response.Write("Escolha as OSs para baixar.");
				Response.End();
				return new EmptyResult();
			}
		}
		private string HandleFileName(string file)
		{
			string[] splited = file.Split('-');
			return splited[0] + "/" + splited[3] + "/" + splited[2] + "/" + file;
		}
	}
}