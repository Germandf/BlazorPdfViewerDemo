using BlazorInputFile;
using BlazorPdfViewerDemo.Data;

namespace BlazorPdfViewerDemo.Services
{
	public interface IFileService
	{
		List<FileClass> GetAllPDFs();
		Task Upload(IFileListEntry file);
	}
}
