namespace VetWebApp.Models
{
    public class UserDataModel
    {
        private int Id { get; set; }
        private string? FirstName { get; set; }
        private string? LastName { get; set; }
        private string? PhoneNumber { get; set; }
        private string? Email { get; set; }
        private string? Suburb { get; set; }
        private string? PostCode { get; set; }
        private AnimalDataModel Animal { get; set; }
    }
}
