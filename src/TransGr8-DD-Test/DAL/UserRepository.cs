using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransGr8_DD_Test.Models;

namespace TransGr8_DD_Test.Services
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
    }
    public class UserRepository : IUserRepository
    {

        public List<User> GetAllUsers()
        {
            string json = File.ReadAllText("./Ressources/users.json");
            return JsonConvert.DeserializeObject<List<User>>(json);
        }

    }
}
