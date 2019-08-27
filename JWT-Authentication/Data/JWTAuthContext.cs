/*==========================================================================================
AUTHOR              :   Manan Pandya
CREATED ON          :   Aug 13, 2019
LAST MODIFIED ON    :   Aug 27, 2019
DESCRIPTION         :   JWTAuth Context
============================================================================================
REVISION HISTORY : 
Name:                 Date:                 Description
============================================================================================*/

using JWT_Authentication.Enums;
using JWT_Authentication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JWT_Authentication.Data
{
    public class JWTAuthContext : DbContext
    {
        public IConfiguration Configuration { get; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Models.Role> Roles { get; set; }

        public virtual DbSet<UserRole> UserRoles { get; set; }

        public JWTAuthContext()
        {
        }

        public JWTAuthContext(DbContextOptions<JWTAuthContext> options, IConfiguration configuration)
          : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Admin
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Firstname = "Hosea",
                    Lastname = "Burton",
                    Gender = Enums.Gender.Male.ToString(),
                    Username = "hosea.b@jwt.com",
                    Password = "Hosea@123"
                },

                new User
                {
                    UserId = 2,
                    Firstname = "Colin",
                    Lastname = "Kaepernick",
                    Gender = Enums.Gender.Male.ToString(),
                    Username = "colin.k@jwt.com",
                    Password = "Colin@123"
                },

                new User
                {
                    UserId = 3,
                    Firstname = "Juan",
                    Lastname = "Cole",
                    Gender = Enums.Gender.Male.ToString(),
                    Username = "juan.c@jwt.com",
                    Password = "Juan@123"
                },

                new User
                {
                    UserId = 4,
                    Firstname = "James",
                    Lastname = "Baldwin",
                    Gender = Enums.Gender.Male.ToString(),
                    Username = "james.b@jwt.com",
                    Password = "James@123"
                },

                new User
                {
                    UserId = 5,
                    Firstname = "Thomas",
                    Lastname = "Parisi",
                    Gender = Enums.Gender.Male.ToString(),
                    Username = "thomas.p@jwt.com",
                    Password = "Thomas@123"
                },

                new User
                {
                    UserId = 6,
                    Firstname = "Ferguson",
                    Lastname = "Jenkins",
                    Gender = Enums.Gender.Male.ToString(),
                    Username = "ferguson.j@jwt.com",
                    Password = "Ferguson@123"
                },

                new User
                {
                    UserId = 7,
                    Firstname = "Sonali",
                    Lastname = "Sharma",
                    Gender = Enums.Gender.Female.ToString(),
                    Username = "sonali.s@jwt.com",
                    Password = "Sonali@123"
                },

                new User
                {
                    UserId = 8,
                    Firstname = "Eric",
                    Lastname = "Margolis",
                    Gender = Enums.Gender.Male.ToString(),
                    Username = "eric.m@jwt.com",
                    Password = "Eric@123"
                },

                new User
                {
                    UserId = 9,
                    Firstname = "Charles",
                    Lastname = "Pierce",
                    Gender = Enums.Gender.Male.ToString(),
                    Username = "charles.p@jwt.com",
                    Password = "Charles@123"
                },

                new User
                {
                    UserId = 10,
                    Firstname = "Pierre",
                    Lastname = "Tristam",
                    Gender = Enums.Gender.Male.ToString(),
                    Username = "pierre.t@jwt.com",
                    Password = "Pierre@123"
                },

                new User
                {
                    UserId = 11,
                    Firstname = "Juliette",
                    Lastname = "Majot",
                    Gender = Enums.Gender.Male.ToString(),
                    Username = "juliette.m@jwt.com",
                    Password = "Juliette@123"
                },

                new User
                {
                    UserId = 12,
                    Firstname = "Shane",
                    Lastname = "Ryan",
                    Gender = Enums.Gender.Male.ToString(),
                    Username = "shane.r@jwt.com",
                    Password = "Shane@123"
                },

                new User
                {
                    UserId = 13,
                    Firstname = "Karen",
                    Lastname = "Kinney",
                    Gender = Enums.Gender.Female.ToString(),
                    Username = "karen.k@jwt.com",
                    Password = "Karen@123"
                },

                new User
                {
                    UserId = 14,
                    Firstname = "Robert",
                    Lastname = "Lipsyte",
                    Gender = Enums.Gender.Male.ToString(),
                    Username = "robert.l@jwt.com",
                    Password = "Robert@123"
                },

                new User
                {
                    UserId = 15,
                    Firstname = "Leonard",
                    Lastname = "Junior",
                    Gender = Enums.Gender.Male.ToString(),
                    Username = "leonard.j@jwt.com",
                    Password = "Leonard@123"
                }
                );
            #endregion

            #region Role
            modelBuilder.Entity<Models.Role>().ToTable("Role");

            modelBuilder.Entity<Models.Role>().HasData(
                new Models.Role { RoleId = 1, Name = Enums.Role.Admin.ToString() },
                new Models.Role { RoleId = 2, Name = Enums.Role.Manager.ToString() },
                new Models.Role { RoleId = 3, Name = Enums.Role.User.ToString() }
                );
            #endregion

            #region UserRole
            modelBuilder.Entity<UserRole>().ToTable("UserRole");
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { UserRoleId = 1, UserId = 1, RoleId = 1 },
                new UserRole { UserRoleId = 2, UserId = 2, RoleId = 1 },
                new UserRole { UserRoleId = 3, UserId = 3, RoleId = 1 },
                new UserRole { UserRoleId = 4, UserId = 4, RoleId = 2 },
                new UserRole { UserRoleId = 5, UserId = 5, RoleId = 2 },
                new UserRole { UserRoleId = 6, UserId = 6, RoleId = 3 },
                new UserRole { UserRoleId = 7, UserId = 7, RoleId = 3 },
                new UserRole { UserRoleId = 8, UserId = 8, RoleId = 3 },
                new UserRole { UserRoleId = 9, UserId = 9, RoleId = 3 },
                new UserRole { UserRoleId = 10, UserId = 10, RoleId = 3 },
                new UserRole { UserRoleId = 11, UserId = 11, RoleId = 3 },
                new UserRole { UserRoleId = 12, UserId = 12, RoleId = 3 },
                new UserRole { UserRoleId = 13, UserId = 13, RoleId = 3 },
                new UserRole { UserRoleId = 14, UserId = 14, RoleId = 3 },
                new UserRole { UserRoleId = 15, UserId = 15, RoleId = 3 }
                );
            #endregion
        }
    }
}
