using BlazorPdfViewerDemo.Data;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorPdfViewerDemo.Services
{
	public interface IFileService
	{
		List<FileClass> GetAllPDFs();
		Task Upload(IBrowserFile file);
	}
}
