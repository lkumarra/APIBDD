using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuy.API.BDD.Enum.DataEnum
{
    public enum Categories_DataEnum
    {
        DVD_Games,
        Unique_Gifts
    }

    internal class CategoriesData
    {
        public static string GetEnumString(Categories_DataEnum categories_DataEnum)
        {
            switch (categories_DataEnum)
            {
                case Categories_DataEnum.DVD_Games:
                    return "abcat0020002";
                case Categories_DataEnum.Unique_Gifts:
                    return "abcat0020004";
                default:
                    return null;
            }
        }
    }
}
