using DocumentFilesTask.Data;
using DocumentFilesTask.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DocumentFilesTask.Controllers
{
    public class UploadFilesController : Controller
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly IWebHostEnvironment _hostEnvironment;

        public UploadFilesController(ApplicationDbContext dbcontext, IWebHostEnvironment hostEnvironment)
        {
            this._dbcontext = dbcontext;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public IActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadFile(FilesViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var formFile = userViewModel.File1;
                if (formFile == null || formFile.Length == 0)
                {
                    ModelState.AddModelError("", "Uploaded file is empty or null.");
                    return View(viewName: "Index");
                }

                var uploadsRootFolder = Path.Combine(_hostEnvironment.WebRootPath, @"Files\");
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }

                var filePath = Path.Combine(uploadsRootFolder, formFile.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(fileStream).ConfigureAwait(false);
                }

                RedirectToAction("Index");
            }
            return View(viewName: "Index");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
