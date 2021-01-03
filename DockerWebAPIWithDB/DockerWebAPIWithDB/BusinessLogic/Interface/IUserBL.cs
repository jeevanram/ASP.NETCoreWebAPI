using DockerWebAPIWithDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerWebAPIWithDB.BusinessLogic.Interface
{
    public interface IUserBL
    {
        public User GetUser(string userName);
    }
}
