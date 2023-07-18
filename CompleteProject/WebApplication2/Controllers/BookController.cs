using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class BookController : ApiController
    {
        // GET api/values
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
        public IEnumerable<BookInfo> GetBooksByCategoryId(int category_id)
        {
            Models.LIB_LIAQUATEntities e = new Models.LIB_LIAQUATEntities();
            var list = (from l in e.TBL_BOOK
                       join a in e.TBL_AUTHOR on l.AUTHOR_ID equals a.AUTHOR_ID
                       join c in e.TBL_CATEGORY on l.CATEGORY_ID equals c.CATEGORY_ID

                       where l.CATEGORY_ID==category_id
                       select new BookInfo
                       {
                           BookId=l.BOOK_ID,
                           Edition=l.BOOK_EDITION,
                           Title=l.BOOK_TITLE,
                           Author=a.AUTHOR_NAME,
                           Category=c.CATEGORY_NAME,
                           IBAN=l.BOOK_IBAN_NO,

                       }).ToList();
            return list;
        }

    }
}
