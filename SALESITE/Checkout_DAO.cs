using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace SALESITE
{
    class Checkout_DAO
    {
        /* String strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;*/ // in App.config 
        MydbDataContext db = new MydbDataContext(ConfigurationManager.ConnectionStrings["strCon"].ConnectionString); // in App.config 
        public List<Check_out> laytatca()
        {
            db.ObjectTrackingEnabled = false;
            List<Check_out> check_outs = db.Check_outs.ToList();
            return check_outs;

        }


        public List<Check_out> Selectbyword(String keyword)
         {
            db.ObjectTrackingEnabled = false;
            List<Check_out> Check_outs = db.Check_outs.Where(b => b.Account_username.Contains(keyword)).ToList();
            return Check_outs;
        }


        public Check_out Selectbycode(int id) 
        {
            db.ObjectTrackingEnabled = false;
            Check_out check_out = db.Check_outs.SingleOrDefault(b => b.ID == id);
            return check_out;
        }

        public bool Insert(Check_out newcheckout)
        {
            try
            {
                db.Check_outs.InsertOnSubmit(newcheckout);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        public bool Delete(int id)
        {
            Check_out dbCheck_out = db.Check_outs.SingleOrDefault(b => b.ID == id);
            if (db.Check_outs != null)
            {
                try
                {
                    db.Check_outs.DeleteOnSubmit(dbCheck_out);
                    db.SubmitChanges();
                    return true;
                }
                catch { return false; }
            }
            return false;
        }


        public bool Update(Check_out newcheckout)
        {
            Check_out dbCheck_out = db.Check_outs.SingleOrDefault(b => b.ID == newcheckout.ID);
            if(dbCheck_out != null)
            {
                try
                {
                    dbCheck_out.Account_id = newcheckout.Account_id;
                    dbCheck_out.Account_username = newcheckout.Account_username;
                    dbCheck_out.Address = newcheckout.Address;
                    dbCheck_out.Cart_total = newcheckout.Cart_total;
                    dbCheck_out.Voucher = newcheckout.Voucher;
                    dbCheck_out.Shipping_fee = newcheckout.Shipping_fee;
                    db.SubmitChanges();
                    return true;
                }
                catch { return false; }

            }
            return false;
        }
    }
        
}
