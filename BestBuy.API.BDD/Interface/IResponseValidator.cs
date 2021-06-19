using BestBuy.API.BDD.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuy.API.BDD.Interface
{
    interface IResponseValidator
    {
        ResponseWrapper responseWrapper { get; set; }

        void VerifyResponse(ResponseModalWrapper responseModalWrapper);
    }
}
