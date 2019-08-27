/*==========================================================================================
AUTHOR              :   Manan Pandya
CREATED ON          :   Aug 13, 2019
LAST MODIFIED ON    :   Aug 27, 2019
DESCRIPTION         :   Authentication Service
============================================================================================
REVISION HISTORY : 
Name:                 Date:                 Description
============================================================================================*/

using JWT_Authentication.Data;
using JWT_Authentication.Helpers;
using JWT_Authentication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace JWT_Authentication.Services
{
    public class JWTAuthService : IJWTAuthService
    {
        #region VARIBLE
        private readonly JWTAuthContext _context;
        private AppSettings _appSettings;
        #endregion

        #region CONSTRUCTOR
        public JWTAuthService(JWTAuthContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }
        #endregion

        #region METHODS

        // Authenticate User 
        public async Task<User> Authenticate(string username, string password)
        {
            var user = await _context.Users.Where(x => x.Username == username && x.Password == password).FirstOrDefaultAsync();

            // Return null if User not exist
            if (user == null)
                return null;

            var userRole = await _context.UserRoles.Where(x => x.UserId == user.UserId).FirstOrDefaultAsync();
            var role = await _context.Roles.Where(x => x.RoleId == userRole.RoleId).FirstOrDefaultAsync();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString()),
                    new Claim(ClaimTypes.Role, role.Name.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // Remove password before returning
            user.Password = null;
            return user;
        }

        // Get User by id
        public async Task<User> FindAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        // Get all Users
        public async Task<IList<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        // Add User
        public async Task<int> Add(User user)
        {
            await _context.Users.AddAsync(user);
            return await _context.SaveChangesAsync();            
        }

        // Modify User data by id
        public async Task Put(int id, User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Delete user by id
        public async Task<bool> Delete(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        // Get all Managers
        public async Task<IList<User>> GetManager()
        {
            var users = await _context.UserRoles.Where(ur => ur.RoleId == (int)Enums.Role.Manager || ur.RoleId == (int)Enums.Role.User)
                        .Join(_context.Users, ur => ur.UserId, u => u.UserId, (ur, u) => u).ToListAsync();

            return users;
        }

        // Get all Users
        public async Task<IList<User>> GetUser()
        {
            var users = from ur in _context.UserRoles.Where(x => x.RoleId == (int)Enums.Role.User)
                        join u in _context.Users on ur.UserId equals u.UserId
                        select u;

            return await users.ToListAsync();
        }

        // Get Manager by id
        public async Task<User> GetManager(int id)
        {
            var users = from ur in _context.UserRoles join u in _context.Users on ur.UserId equals u.UserId
                        where (u.UserId == id && (ur.RoleId == (int)Enums.Role.Manager || ur.RoleId == (int)Enums.Role.User))
                        select u;

            return await users.FirstOrDefaultAsync();
        }

        // Get User by id
        public async Task<User> GetUser(int id)
        {
            var userList = from ur in _context.UserRoles join u in _context.Users on ur.UserId equals u.UserId
                           where (u.UserId == id && ur.RoleId == (int)Enums.Role.User)
                           select u;

            return await userList.FirstOrDefaultAsync();
        }

        #endregion
    }
}
