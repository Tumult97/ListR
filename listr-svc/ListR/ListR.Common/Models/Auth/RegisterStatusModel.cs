using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListR.Common.Models.Auth
{
    public class RegisterStatusModel
    {
        public bool Success { get; set; }
        public string? Error { get; set; }
    }
}
