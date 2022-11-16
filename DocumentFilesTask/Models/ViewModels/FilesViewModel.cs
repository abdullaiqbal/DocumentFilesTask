using DocumentFilesTask.CustomValidation;
using System.ComponentModel.DataAnnotations;

namespace DocumentFilesTask.Models.ViewModels
{
    public class FilesViewModel
    {
        [Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        [MaxFileSizeAttribute(5 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".pdf", ".docx" })]
        public IFormFile File1 { get; set; }
    }
}
