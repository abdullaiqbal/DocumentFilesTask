namespace DocumentFilesTask.Models
{
    public class AppFile
    {
        public int Id { get; set; }
        public string? fileName { get; set; }
        public byte[] Content { get; set; }
    }
}
