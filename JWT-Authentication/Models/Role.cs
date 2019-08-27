/*==========================================================================================
AUTHOR              :   Manan Pandya
CREATED ON          :   Aug 13, 2019
LAST MODIFIED ON    :   Aug 27, 2019
DESCRIPTION         :   Role Model
============================================================================================
REVISION HISTORY : 
Name:                 Date:                 Description
============================================================================================*/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JWT_Authentication.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        public string Name { get; set; }
    }
}
