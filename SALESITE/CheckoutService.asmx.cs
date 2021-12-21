using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SALESITE
{
    /// <summary>
    /// Summary description for CheckoutService
    /// </summary>
    [WebService(Namespace = "http://dinhan2509.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CheckoutService : System.Web.Services.WebService
    {


        [WebMethod]
        public List<Check_out> laydanhsach()
        {
            List<Check_out> check_outs = new Checkout_DAO().laytatca();
            return check_outs;
        }
        [WebMethod]
        public Check_out Getdetails(int id)
        {
            Check_out check_out = new Checkout_DAO().Selectbycode(id);
            return check_out;

        }
        [WebMethod]
        public List<Check_out> Search(String keyword)
        {
            List<Check_out> check_outs = new Checkout_DAO().Selectbyword(keyword);
            return check_outs;
        }
        [WebMethod]
        public bool Addnew(Check_out newcheckout)
        {
            bool result = new Checkout_DAO().Insert(newcheckout);
            return result;
        }

        [WebMethod]
        public bool Delete(int id)
        {
            bool result = new Checkout_DAO().Delete(id);
            return result;
        }

        [WebMethod]
        public bool Update(Check_out newcheckout)
        {
            bool result = new Checkout_DAO().Update(newcheckout);
            return result;
        }
    }
}
