/*==========================================================================================
AUTHOR              :   Manan Pandya
CREATED ON          :   Sept 05, 2019
LAST MODIFIED ON    :   -
DESCRIPTION         :   ApplicationDbContext
============================================================================================
REVISION HISTORY : 
Name:                 Date:                 Description
============================================================================================*/

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Policys.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { 
        }
    }
}
