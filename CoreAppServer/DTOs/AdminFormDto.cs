namespace API.DTOs
{
    public class AdminFormDto
    {
        public int? Id { get; set; }
        public string Login { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public string Roles { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Password { get; set; }
    }
}
