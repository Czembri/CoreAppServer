namespace API.DTOs
{
    public class DocumentInfoDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? Date { get; set; }
        public int Scale { get; set; }
        public string Footer { get; set; }
        public string Header { get; set; }
        public string Type { get; set; }
    }
}
