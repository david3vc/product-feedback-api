using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Entities
{
    public class SecurityEntity
    {
        public string TokenType { get; set; }
        public string AccesToken { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
}
