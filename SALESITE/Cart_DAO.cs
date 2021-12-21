using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace SALESITE
{
    class Cart_DAO
    {
        /* String strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;*/ // in App.config 
        MydbDataContext db = new MydbDataContext(ConfigurationManager.ConnectionStrings["strCon"].ConnectionString); // in App.config 
        public List<Cart> laytatca()
        {
            db.ObjectTrackingEnabled = false;
            List<Cart> carts = db.Carts.ToList();
            return carts;

        }


        public List<Cart> Selectbyword(String keyword)
         {
            db.ObjectTrackingEnabled = false;
            List<Cart> Carts = db.Carts.Where(b => b.Product_name.Contains(keyword)).ToList();
            return Carts;
        }


        public Cart Selectbycode(int id) 
        {
            db.ObjectTrackingEnabled = false;
            Cart cart = db.Carts.SingleOrDefault(b => b.ID == id);
            return cart;
        }

        public bool Insert(Cart newcart)
        {
            try
            {
                db.Carts.InsertOnSubmit(newcart);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        public bool Delete(int id)
        {
            Cart dbCart = db.Carts.SingleOrDefault(b => b.ID == id);
            if (db.Check_outs != null)
            {
                try
                {
                    db.Carts.DeleteOnSubmit(dbCart);
                    db.SubmitChanges();
                    return true;
                }
                catch { return false; }
            }
            return false;
        }


        public bool Update(Cart newcart)
        {
            Cart dbCart = db.Carts.SingleOrDefault(b => b.ID == newcart.ID);
            if(dbCart != null)
            {
                try
                {
                    dbCart.Account_id = newcart.Account_id;
                    dbCart.Product_id = newcart.Product_id;
                    dbCart.Product_name = newcart.Product_name;
                    dbCart.Quantity = newcart.Quantity;
                    dbCart.Total = newcart.Total;
                    db.SubmitChanges();
                    return true;
                }
                catch { return false; }

            }
            return false;
        }
    }
        
}
