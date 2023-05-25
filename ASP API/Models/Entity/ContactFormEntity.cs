using System.ComponentModel.DataAnnotations;

namespace ASP_API.Models.Entity
{
    public class ContactFormEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string ContactFormText { get; set; } = null!;

    }
}
