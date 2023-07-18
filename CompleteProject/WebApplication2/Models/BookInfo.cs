using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Web;

namespace WebApplication2.Models
{
    public class CategoryInfo:ISerializable
    {
        public int CategortyId { get; set; }
        public string Category { get; set; }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");

            info.AddValue("CategortyId", CategortyId);
            info.AddValue("Category", Category);
        }
    }
    public class BookInfo : ISerializable
    {
        public int BookId { get; set; }
        public string IBAN { get; set; }
        public string Edition { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");

            info.AddValue("BookId", BookId);
            info.AddValue("Category", Category);
            info.AddValue("Author", Author);
            info.AddValue("Title", Title);
            info.AddValue("Edition", Edition);
            info.AddValue("IBAN", IBAN);
        }
    }
}