using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace SALESITE
{
    class Product_DAO
    {
        /* String strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;*/ // in App.config 
        MydbDataContext db = new MydbDataContext(ConfigurationManager.ConnectionStrings["strCon"].ConnectionString); // in App.config 
        public List<Product> laytatca()
        {
            db.ObjectTrackingEnabled = false;
            List<Product> products = db.Products.ToList();
            return products;

        }


        public List<Product> Selectbyword(String keyword)
         {
            db.ObjectTrackingEnabled = false;
            List<Product> Products = db.Products.Where(b => b.Name.Contains(keyword)).ToList();
            return Products;
        }


        public Product Selectbycode(int id) 
        {
            db.ObjectTrackingEnabled = false;
            Product product = db.Products.SingleOrDefault(b => b.ID == id);
            return product;
        }

        public bool Insert(Product newproduct)
        {
            try
            {
                db.Products.InsertOnSubmit(newproduct);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        public bool Delete(int id)
        {
            Product dbProduct = db.Products.SingleOrDefault(b => b.ID == id);
            if (db.Products != null)
            {
                try
                {
                    db.Products.DeleteOnSubmit(dbProduct);
                    db.SubmitChanges();
                    return true;
                }
                catch { return false; }
            }
            return false;
        }


        public bool Update(Product newproduct)
        {
            Product dbProduct = db.Products.SingleOrDefault(b => b.ID == newproduct.ID);
            if(dbProduct != null)
            {
                try
                {
                    dbProduct.Name = newproduct.Name;
                    dbProduct.Product_image = newproduct.Product_image;
                    dbProduct.Description = newproduct.Description;
                    dbProduct.Category = newproduct.Category;
                    dbProduct.Price = newproduct.Price;
                    dbProduct.Madein = newproduct.Madein;
                    db.SubmitChanges();
                    return true;
                }
                catch { return false; }

            }
            return false;
        }
    }
        
}
