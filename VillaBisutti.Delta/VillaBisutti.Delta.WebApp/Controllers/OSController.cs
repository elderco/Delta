using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using io = System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ICSharpCode.SharpZipLib.Core;

namespace VillaBisutti.Delta.WebApp.Controllers
{
	public class OSController : Controller
	{
		//
		// GET: /OS/
		public ActionResult Index()
		{
			SessionFacade.FilesToDownload.Add(@"OS\Capa\2015\11\Capa-15-11-2015-CM-priscila-e-rafael-Casamento.pdf");
			SessionFacade.FilesToDownload.Add(@"OS\Capa\2015\5\Capa-07-05-2015-TE-lide-futuro-Corporativo.pdf");
			SessionFacade.FilesToDownload.Add(@"OS\Capa\2015\9\Capa-05-09-2015-TE-camila-e-guilherme-Casamento.pdf");
			SessionFacade.FilesToDownload.Add(@"OS\OS\2015\9\OS-05-09-2015-TE-camila-e-guilherme-Casamento.pdf");
			return View();
		}
		public ActionResult AddToDownload(string file)
		{
			return View();
		}
		public ActionResult RemoveFromDownload(string file)
		{
			return View();
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
					FileInfo fi = new FileInfo(Server.MapPath("~/" + fileName));

					string entryName = fileName.Substring(fileName.LastIndexOf("\\") + 1);
					ZipEntry newEntry = new ZipEntry(entryName);
					newEntry.DateTime = fi.LastWriteTime;
					zipOS.UseZip64 = UseZip64.Off;
					newEntry.Size = fi.Length;

					zipOS.PutNextEntry(newEntry);

					// Zip the file in buffered chunks
					// the "using" will close the stream even if an exception occurs
					byte[] buffer = new byte[4096];
					using (FileStream streamReader = io.File.OpenRead(Server.MapPath("~/" + fileName)))
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
				return new EmptyResult();
			}
			else
			{
				Response.Write("Escolha as OSs para baixar.");
				Response.End();
				return new EmptyResult();
			}
		}
	}
}