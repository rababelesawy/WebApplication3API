using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Core.Identity
{
    public class ApplicationUser:IdentityUser
    {


        public string Type { get; set; }


    }
}
