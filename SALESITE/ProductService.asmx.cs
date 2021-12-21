using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SALESITE
{
    /// <summary>
    /// Summary description for ProductService
    /// </summary>
    [WebService(Namespace = "http://dinhan2509.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ProductService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Product> laydanhsach()
        {
            List<Product> products = new Product_DAO().laytatca();
            return products;
        }
        [WebMethod]
        public Product Getdetails(int id)
        {
            Product product = new Product_DAO().Selectbycode(id);
            return product;

        }
        [WebMethod]
        public List<Product> Search(String keyword)
        {
            List<Product> products = new Product_DAO().Selectbyword(keyword);
            return products;
        }
        [WebMethod]
        public bool Addnew(Product newproduct)
        {
            bool result = new Product_DAO().Insert(newproduct);
            return result;
        }

        [WebMethod]
        public bool Delete(int id)
        {
            bool result = new Product_DAO().Delete(id);
            return result;
        }

        [WebMethod]
        public bool Update(Product newproduct)
        {
            bool result = new Product_DAO().Update(newproduct);
            return result;
        }
    }
}
