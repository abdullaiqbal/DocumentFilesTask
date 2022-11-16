using DocumentFilesTask.Data;
using DocumentFilesTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using System.IO;

namespace DocumentFilesTask.Controllers
{
    public class HomeController : Controller
    {
        //[BindProperty]
        //public BufferedSingleFileUploadDb FileUpload { get; set; }
        private readonly ApplicationDbContext _dbcontext;
        private readonly IWebHostEnvironment _hostEnvironment;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbcontext, IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            _dbcontext = dbcontext;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult FilesUpload()
        {
            return View();
        }

        [HttpPost]
        [ActionName("FilesUpload")]
        public async Task<IActionResult> FilesUploadPost(BufferedSingleFileUploadDb fromFile /*IFormFile FormFile*/)
        {
            var memoryStream = new MemoryStream();
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName1 = Guid.NewGuid().ToString();
            var uploads = Path.Combine(wwwRootPath, @"Files\");




            ////Loop Portion
            //for(int i = 1; i <= 3; i++)
            //{

            //    //First File Portion
            //    var extension = Path.GetExtension(fromFile.FormFile.FileName);
            //    if (extension == ".docx" || extension == ".pdf")
            //    {


            //        await fromFile.FormFile1.CopyToAsync(memoryStream);

            //        // Upload the file if less than 2 MB
            //        if (memoryStream.Length < 2097152)
            //        {
            //            using (var filestreams = new FileStream(Path.Combine(uploads, fileName1 + extension1), FileMode.Create))
            //            {
            //                fromFile.FormFile1.CopyTo(filestreams);
            //            }
            //            var file = new AppFile()
            //            {
            //                Content = memoryStream.ToArray(),
            //                fileName = @"\Files\" + fileName1 + extension1

            //            };
            //            _dbcontext.File.Add(file);


            //            await _dbcontext.SaveChangesAsync();
            //        }
            //        else
            //        {
            //            ViewBag.message = "The file is too large";
            //            ModelState.AddModelError("File", "The file is too large.");
            //        }
            //    }

            //    else
            //    {
            //        ModelState.AddModelError("File", "You can only update docx or pdf files");
            //    }

            //}








            //First File Portion
            var extension1 = Path.GetExtension(fromFile.FormFile1.FileName);
            if (extension1 == ".docx" || extension1 == ".pdf")
            {


                await fromFile.FormFile1.CopyToAsync(memoryStream);

                // Upload the file if less than 2 MB
                if (memoryStream.Length < 2097152)
                {
                    using (var filestreams = new FileStream(Path.Combine(uploads, fileName1 + extension1), FileMode.Create))
                    {
                        fromFile.FormFile1.CopyTo(filestreams);
                    }
                    var file = new AppFile()
                    {
                        Content = memoryStream.ToArray(),
                        fileName = @"\Files\" + fileName1 + extension1

                    };
                    _dbcontext.File.Add(file);


                    await _dbcontext.SaveChangesAsync();
                }
                else
                {
                    ViewBag.message = "The file is too large";
                    ModelState.AddModelError("File", "The file is too large.");
                }
            }

            else
            {
                ModelState.AddModelError("File", "You can only update docx or pdf files");
            }

            //Second File Portion
            //if (fromFile.FormFile2 != null)
            //{
                string fileName2 = Guid.NewGuid().ToString();
                var extension2 = Path.GetExtension(fromFile.FormFile2.FileName);

                await fromFile.FormFile2.CopyToAsync(memoryStream);

                // Upload the file if less than 2 MB
                if (memoryStream.Length < 2097152)
                {
                    using (var filestreams = new FileStream(Path.Combine(uploads, fileName2 + extension2), FileMode.Create))
                    {
                        fromFile.FormFile2.CopyTo(filestreams);
                    }
                    var file = new AppFile()
                    {
                        Content = memoryStream.ToArray(),
                        fileName = @"\Files\" + fileName2 + extension2

                    };
                    _dbcontext.File.Add(file);


                    await _dbcontext.SaveChangesAsync();
                }
                else
                {
                    ModelState.AddModelError("File", "The file is too large.");
                    ViewBag.message = "The file is too large.";
                }
            //}

            //Third File Portion
            //if (fromFile.FormFile3 != null)
            //{
                string fileName3 = Guid.NewGuid().ToString();
                var extension3 = Path.GetExtension(fromFile.FormFile3.FileName);

                await fromFile.FormFile3.CopyToAsync(memoryStream);

                // Upload the file if less than 2 MB
                if (memoryStream.Length < 2097152)
                {
                    using (var filestreams = new FileStream(Path.Combine(uploads, fileName3 + extension3), FileMode.Create))
                    {
                        fromFile.FormFile3.CopyTo(filestreams);
                    }
                    var file = new AppFile()
                    {
                        Content = memoryStream.ToArray(),
                        fileName = @"\Files\" + fileName3 + extension3

                    };
                    _dbcontext.File.Add(file);


                    await _dbcontext.SaveChangesAsync();
                }
                else
                {
                    ViewBag.message = "The file is too large";
                    ModelState.AddModelError("File", "The file is too large.");
                }
            //}
            return View("FilesUpload");
        }
       

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}