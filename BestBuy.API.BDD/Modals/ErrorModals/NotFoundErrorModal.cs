using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuy.API.BDD.Modals.ErrorModals
{
    class NotFoundErrorModal
    {
        public string name { get; set; }
        public string message { get; set; }
        public int code { get; set; }
        public string className { get; set; }
        public Errors errors { get; set; }
    }
    public class Errors
    {
    }
}
