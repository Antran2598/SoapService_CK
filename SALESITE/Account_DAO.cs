using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace SALESITE
{
    class Account_DAO
    {
        /* String strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;*/ // in App.config 
        MydbDataContext db = new MydbDataContext(ConfigurationManager.ConnectionStrings["strCon"].ConnectionString); // in App.config 
        public List<Account> laytatca()
        {
            db.ObjectTrackingEnabled = false;
            List<Account> accounts = db.Accounts.ToList();
            return accounts;

        }


        public List<Account> Selectbyword(String keyword)
         {
            db.ObjectTrackingEnabled = false;
            List<Account> Accounts = db.Accounts.Where(b => b.Username.Contains(keyword)).ToList();
            return Accounts;
        }


        public Account Selectbycode(int id) 
        {
            db.ObjectTrackingEnabled = false;
            Account account = db.Accounts.SingleOrDefault(b => b.ID == id);
            return account;
        }

        public bool Insert(Account newaccount)
        {
            try
            {
                db.Accounts.InsertOnSubmit(newaccount);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        public bool Delete(int id)
        {
            Account dbAccount = db.Accounts.SingleOrDefault(b => b.ID == id);
            if (db.Accounts != null)
            {
                try
                {
                    db.Accounts.DeleteOnSubmit(dbAccount);
                    db.SubmitChanges();
                    return true;
                }
                catch { return false; }
            }
            return false;
        }


        public bool Update(Account newaccount)
        {
            Account dbAccount = db.Accounts.SingleOrDefault(b => b.ID == newaccount.ID);
            if(dbAccount != null)
            {
                try
                {
                    dbAccount.Username = newaccount.Username;
                    dbAccount.Password = newaccount.Password;
                    dbAccount.First_name = newaccount.First_name;
                    dbAccount.Last_name = newaccount.Last_name;
                    dbAccount.Address = newaccount.Address;
                    dbAccount.Phone = newaccount.Phone;
                    db.SubmitChanges();
                    return true;
                }
                catch { return false; }

            }
            return false;
        }
    }
        
}
