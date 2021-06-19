using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuy.API.BDD.Modals
{
    class ErrorModal
    {
        public string name { get; set; }
        public string message { get; set; }
        public int code { get; set; }
        public string className { get; set; }
        public Data data { get; set; }
        public List<string> errors { get; set; }
    }

    public class Data
    {
    }
}
