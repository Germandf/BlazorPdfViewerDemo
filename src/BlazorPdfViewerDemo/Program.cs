using BlazorPdfViewerDemo.Services;
using Microsoft.AspNetCore.StaticFiles;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
    app.UseHsts();

app.UseHttpsRedirection();

var provider = new FileExtensionContentTypeProvider();
provider.Mappings.Add(".properties", "application/octet-stream");
app.UseStaticFiles(new StaticFileOptions // needed for pdf js .properties files
{
    ContentTypeProvider = provider
});

app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();
