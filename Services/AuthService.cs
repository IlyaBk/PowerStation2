using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PowerStation;
using PowerStation.Models;
using PowerStation2.Models;

namespace PowerStation2.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;
        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ActionResult<User>> Login(LoginModel model)
        {
            var user = await _context.Users
                .Include(user => user.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Email == model.Email);

            return user ?? throw new Exception();
        }
    }
}
