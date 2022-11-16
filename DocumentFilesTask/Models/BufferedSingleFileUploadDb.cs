using System.ComponentModel.DataAnnotations;

namespace DocumentFilesTask.Models
{
    public class BufferedSingleFileUploadDb
    {
        [Required]
        [Display(Name = "First File")]
        public IFormFile FormFile1 { get; set; }
        [Required]
        [Display(Name = "Second File")]
        public IFormFile FormFile2 { get; set; }
        [Required]
        [Display(Name = "Third File")]
        public IFormFile FormFile3 { get; set; }
    }
}
