using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reqres_Automation_Framework.Model
{
    public class SingleUserModel
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public List<UserModel> data { get; set; }
    }
}
