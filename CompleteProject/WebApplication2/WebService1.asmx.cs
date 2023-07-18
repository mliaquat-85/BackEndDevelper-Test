using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebApplication2.Models;

namespace WebApplication2
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public IEnumerable<CategoryInfo> GetCategories(int? category_id, int? parent_category_id)
        {
            Models.LIB_LIAQUATEntities e = new Models.LIB_LIAQUATEntities();
            var list = e.usp_GET_CATEGORIES(category_id, parent_category_id);
            return (from l in list
                    select new CategoryInfo
                    {
                        CategortyId = l.CATEGORY_ID,
                        Category = l.CATEGORY_NAME

                    }).ToList();
        }
        [WebMethod]
        public IEnumerable<BookInfo> GetBooksByCategoryId(int category_id)
        {
            Models.LIB_LIAQUATEntities e = new Models.LIB_LIAQUATEntities();
            var list = (from l in e.TBL_BOOK
                        join a in e.TBL_AUTHOR on l.AUTHOR_ID equals a.AUTHOR_ID
                        join c in e.TBL_CATEGORY on l.CATEGORY_ID equals c.CATEGORY_ID

                        where l.CATEGORY_ID == category_id
                        select new BookInfo
                        {
                            BookId = l.BOOK_ID,
                            Edition = l.BOOK_EDITION,
                            Title = l.BOOK_TITLE,
                            Author = a.AUTHOR_NAME,
                            Category = c.CATEGORY_NAME,
                            IBAN = l.BOOK_IBAN_NO,

                        }).ToList();
            return list;
        }
    }
}
