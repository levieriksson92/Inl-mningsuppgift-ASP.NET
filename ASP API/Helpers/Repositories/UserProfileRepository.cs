using ASP_API.Contexts;
using ASP_API.Models.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Diagnostics;

namespace ASP_API.Helpers.Repositories
{
    public class UserProfileRepository
    {
        private readonly IdentityContext _context;

        public UserProfileRepository(IdentityContext context)
        {
            _context = context;
        }


        public async Task<UserProfileEntity> AddAsync(UserProfileEntity entity)
        {
            try
            {
                _context.UserProfiles.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return entity;
        }

    }
}
