/*==========================================================================================
AUTHOR              :   Manan Pandya
CREATED ON          :   Aug 13, 2019
LAST MODIFIED ON    :   Aug 27, 2019
DESCRIPTION         :   User Model
============================================================================================
REVISION HISTORY : 
Name:                 Date:                 Description
============================================================================================*/

using JWT_Authentication.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JWT_Authentication.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Gender { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }
    }
}
