using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SALESITE
{
    /// <summary>
    /// Summary description for Cart1
    /// </summary>
    [WebService(Namespace = "http://dinhan2509.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Cart1 : System.Web.Services.WebService
    {
        [WebMethod]
        public List<Cart> laydanhsach()
        {
            List<Cart> carts = new Cart_DAO().laytatca();
            return carts;
        }
        [WebMethod]
        public Cart Getdetails(int id)
        {
            Cart cart = new Cart_DAO().Selectbycode(id);
            return cart;

        }
        [WebMethod]
        public List<Cart> Search(String keyword)
        {
            List<Cart> carts = new Cart_DAO().Selectbyword(keyword);
            return carts;
        }
        [WebMethod]
        public bool Addnew(Cart newcart)
        {
            bool result = new Cart_DAO().Insert(newcart);
            return result;
        }

        [WebMethod]
        public bool Delete(int id)
        {
            bool result = new Cart_DAO().Delete(id);
            return result;
        }

        [WebMethod]
        public bool Update(Cart newcart)
        {
            bool result = new Cart_DAO().Update(newcart);
            return result;
        }
    }
}
