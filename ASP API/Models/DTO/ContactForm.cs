using ASP_API.Models.Entity;

namespace ASP_API.Models.DTO
{
    public class ContactForm
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string ContactFormText { get; set; } = null!;


        public static implicit operator ContactForm(ContactFormEntity entity)
        {
            return new ContactForm
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                ContactFormText = entity.ContactFormText
            };
        }

        public static implicit operator ContactFormEntity(ContactForm entity)
        {
            return new ContactFormEntity
            {
                Name = entity.Name,
                Email = entity.Email,
                ContactFormText = entity.ContactFormText
            };
        }

    }
}
