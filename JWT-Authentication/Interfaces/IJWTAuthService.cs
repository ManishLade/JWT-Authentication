/*==========================================================================================
AUTHOR              :   Manan Pandya
CREATED ON          :   Aug 13, 2019
LAST MODIFIED ON    :   Aug 27, 2019
DESCRIPTION         :   JWTAuthService Interface
============================================================================================
REVISION HISTORY : 
Name:                 Date:                 Description
============================================================================================*/

using JWT_Authentication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JWT_Authentication.Services
{
    public interface IJWTAuthService
    {
        Task<User> FindAsync(int id);

        Task<IList<User>> GetAll();

        Task<int> Add(User user);

        Task Put(int id, User user);

        Task<bool> Delete(User user);

        Task<User> Authenticate(string username, string password);

        Task<IList<User>> GetManager();

        Task<IList<User>> GetUser();

        Task<User> GetManager(int id);

        Task<User> GetUser(int id);
    }
}

