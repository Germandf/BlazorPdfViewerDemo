﻿using BlazorInputFile;
using BlazorPdfViewerDemo.Data;

namespace BlazorPdfViewerDemo.Services
{
	public class FileService : IFileService
	{
		Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

		public FileService(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
		{
			_hostingEnvironment = hostingEnvironment;
		}

		public List<FileClass> GetAllPDFs()
		{
			var files = new List<FileClass>();
			string path = $"{_hostingEnvironment.WebRootPath}\\files\\";
			var nFileId = 1;
			foreach (var pdfPath in Directory.EnumerateFiles(path, "*.pdf"))
			{
				files.Add(new FileClass()
				{
					FileId = nFileId++,
					Name = Path.GetFileName(pdfPath),
					Path = pdfPath,
				});
			}
			return files;
		}

		public async Task Upload(IFileListEntry file)
		{
			var path = Path.Combine(_hostingEnvironment.WebRootPath, "files", file.Name);
			var memoryStream = new MemoryStream();
			await file.Data.CopyToAsync(memoryStream);
			using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
			{
				memoryStream.WriteTo(fileStream);
			}
		}
	}
}
