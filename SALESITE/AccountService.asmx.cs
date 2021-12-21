using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SALESITE
{
    /// <summary>
    /// Summary description for AccountService
    /// </summary>
    [WebService(Namespace = "http://dinhan2509.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AccountService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Account> laydanhsach()
        {
            List<Account> accounts = new Account_DAO().laytatca();
            return accounts;
        }
        [WebMethod]
        public Account Getdetails(int id)
        {
            Account account = new Account_DAO().Selectbycode(id);
            return account;

        }
        [WebMethod]
        public List<Account> Search(String keyword)
        {
            List<Account> accounts = new Account_DAO().Selectbyword(keyword);
            return accounts;
        }
        [WebMethod]
        public bool Addnew(Account newaccount)
        {
            bool result = new Account_DAO().Insert(newaccount);
            return result;
        }

        [WebMethod]
        public bool Delete(int id)
        {
            bool result = new Account_DAO().Delete(id);
            return result;
        }

        [WebMethod]
        public bool Update(Account newaccount)
        {
            bool result = new Account_DAO().Update(newaccount);
            return result;
        }

    }
}
