/*==========================================================================================
AUTHOR              :   Manan Pandya
CREATED ON          :   Aug 31, 2019
LAST MODIFIED ON    :   -
DESCRIPTION         :   ErrorViewModel
============================================================================================
REVISION HISTORY : 
Name:                 Date:                 Description
============================================================================================*/

using System;

namespace Claims.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}