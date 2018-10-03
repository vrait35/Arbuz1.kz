using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Kategory { get; set; }
        public Product(string name,int price,string kategory)
        {
            Name = name;
            Price = price;
            Kategory = kategory;
        }
    }

    public interface IBase
    {
        int Size { get; set; }
        List<Product> Product { get; set; }
         Product this[int index] { get;set; }
    }

    public class Basket:IBase
    {
        public int Size { get; set; }
        public  List<Product> Product { get; set; }

        // public List<Product> Product { get; set; }
         public Product this[int index]
         {
             get
            {
                 return   Product[index];
            }
             
             set
             {
                 Product[index] = value;
             }
         }
    }

    public class Browsing : IBase
    {
        public int Size { get; set; }
        public string NameKategory { get; set; }
        public int Count { get; set; }
        public List<Product> Product { get; set; }

        public Browsing(string name,List<Product> products)
        {
            //Product = products;
            Product = new List<Product>();
            Count = 0;
            NameKategory = name;
            Size = products.Count;           
            for(int i = 0; i < products.Count; i++)
            {                
                if (string.Compare(name, products[i].Kategory)==0)
                {                   
                    Product.Add(products[i]);
                    Count++;
                }
            }
        }

        // public List<Product> Product { get; set; }
        public Product this[int index]
        {
            get
            {
                return Product[index];
            }

            set
            {
                Product[index] = value;
            }
        }

        static public void StringToInt(string s, ref int kategory)
        {
            if(!int.TryParse(s,out kategory))
            {
                throw new Exception("ошибка при преобразовании с строки к числовому значению");
            }
        }
    }

}
