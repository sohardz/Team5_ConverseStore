using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Exeptions
{
    public class ShopExeption : Exception
    {
        public ShopExeption() { }
        public ShopExeption(string message) : base(message)
        { 

        }
        public ShopExeption(string message, Exception inner)
           : base(message, inner)
        {
        }
    }
}
