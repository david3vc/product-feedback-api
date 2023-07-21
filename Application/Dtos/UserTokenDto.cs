using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class UserTokenDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }

        public SecurityEntity? Security { get; set; }
    }
}
