/*==========================================================================================
AUTHOR              :   Manan Pandya
CREATED ON          :   Sept 05, 2019
LAST MODIFIED ON    :   -
DESCRIPTION         :   ErrorViewModel
============================================================================================
REVISION HISTORY : 
Name:                 Date:                 Description
============================================================================================*/

using System;

namespace Policys.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}