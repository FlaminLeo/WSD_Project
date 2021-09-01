using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSD_Project_C2004V_4.Models
{
    [JsonObject(MemberSerialization.OptOut)]
    public class TokenResponseViewModel
    {
        public TokenResponseViewModel()
        {

        }

        public string token { get; set; }
        public int expiration { get; set; }
    }
}
