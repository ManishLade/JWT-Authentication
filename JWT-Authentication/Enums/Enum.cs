/*==========================================================================================
AUTHOR              :   Manan Pandya
CREATED ON          :   Aug 23, 2019
LAST MODIFIED ON    :   Aug 27, 2019
DESCRIPTION         :   All Coanstants and Enums
============================================================================================
REVISION HISTORY : 
Name:                 Date:                 Description
============================================================================================*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT_Authentication.Enums
{
    /// <summary>
    /// Gender Enum
    /// </summary>
    public enum Gender
    {
        Male,
        Female
    }
    /// <summary>
    /// Role Enum
    /// </summary>
    public enum Role
    {
        Admin = 1,
        Manager = 2,
        User = 3
    }
}
