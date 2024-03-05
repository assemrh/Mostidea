using Microsoft.AspNetCore.Mvc;
using Mostidea.Domain.Interfaces;

namespace Mostidea.Web.Controllers
{
    public class FileController : Controller
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Message = TempData["shortMessage"]?.ToString();
            return View(await _fileService.GetUploadedFiles());
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                if (!_fileService.ValidateFile(file))
                {
                    ViewBag.Error = "Geçersiz dosya formatı.";
                    return View();
                }
                await _fileService.SaveUploadedFile(file);
                TempData["shortMessage"] = "Dosya başarıyla yüklendi";


                return RedirectToAction(nameof(Index));
            }

            ViewBag.Error = "Dosya seçilmedi veya dosya boş.";
            return View();
        }



        public IActionResult Upload()
        {
            return View();
        }
    }
}
