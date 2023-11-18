namespace API.DTOs
{
    public class DocumentInfoDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? Date { get; set; }
        public int? Scale { get; set; }
        public string Footer { get; set; }
        public string Header { get; set; }
        public string Type { get; set; }
        public string Recipient { get; set; }
        public string RecipientAddress { get; set; }
        public string RecipientPhone { get; set; }
        public string SenderPhone { get; set; }
        public string Sender { get; set; }
        public string City { get; set; }
    }
}
