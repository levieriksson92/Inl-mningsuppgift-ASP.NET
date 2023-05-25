namespace Inlämningsuppgift_ASP.NET.Models.DTO
{
    public class ContactFormDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string CommentsText { get; set; } = null!;
    }
}
