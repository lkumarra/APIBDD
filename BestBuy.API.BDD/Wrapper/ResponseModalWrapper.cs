using BestBuy.API.BDD.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuy.API.BDD.Wrapper
{
    class ResponseModalWrapper
    {
        public string name { get; set; }
        public string message { get; set; }
        public int code { get; set; }
        public string errors { get; set; }
    }
}
