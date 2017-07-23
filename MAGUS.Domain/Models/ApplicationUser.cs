using MAGUS.Model;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MAGUS.Domain.Models
{
    public class ApplicationUser
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string EmailAddress { get; set; }
    }
}
