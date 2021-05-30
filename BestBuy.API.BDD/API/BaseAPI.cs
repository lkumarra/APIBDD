using BestBuy.API.BDD.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuy.API.BDD.API
{
    class BaseAPI
    {
        protected string _endpoint;
        protected ResponseWrapper _resposeWrapper;

        public BaseAPI(string endpoint)
        {
            _endpoint = endpoint;
        }
    }
}
