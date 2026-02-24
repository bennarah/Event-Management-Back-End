namespace EventManagement.Api.Models
{
    public class CreateRegistrationRequest
    {
        public Guid UserId { get; set; }
        public string? Status { get; set; }
    }
}