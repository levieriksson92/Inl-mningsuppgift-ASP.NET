using ASP_API.Contexts;
using ASP_API.Helpers.Repositories.Base;
using ASP_API.Models.Entity;

namespace ASP_API.Helpers.Repositories
{
    public class ContactFormRepository : Repository<ContactFormEntity>
    {
        public ContactFormRepository(DataContext context) : base(context)
        {
        }
    }
}
