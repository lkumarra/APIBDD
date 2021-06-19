using BestBuy.API.BDD.Helpers;
using BestBuy.API.BDD.Helpers.DBHelpers.Categories;
using BestBuy.API.BDD.Interface;
using BestBuy.API.BDD.Modals.Categories;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuy.API.BDD.API.Categories
{
    class PostCategories : BaseAPI
    {
        private PostCategoriesModal _postCategoriesModal;
        private string _id;

        public PostCategories(IResponseValidator responseValidator) : base("/categories", responseValidator)
        {

        }

        internal void ExecutePostCategoriesAPI(string id, string name)
        {
            _id = id;
            _postCategoriesModal = new PostCategoriesModal()
            {
                id = id,
                name = name,
            };
            _response.responseWrapper = ConfigHelper._httpClientHelper.PerformPostRequest(_endpoint, JsonConvert.SerializeObject(_postCategoriesModal));
        }

        internal void VerifyCategoryCreatedInDb()
        {
            PostCategoriesModal dataInDB = CategoriesDBHelper.GetCategoriesViaId(_id).FirstOrDefault();
            if (!_postCategoriesModal.Equals(dataInDB))
            {
                Assert.Fail("Data created in Db does not match with actual data");
            }
        }
    }
}
