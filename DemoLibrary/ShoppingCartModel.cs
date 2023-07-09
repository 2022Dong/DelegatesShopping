using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class ShoppingCartModel
    {
        // delegate similar to interface, but only pass in method(s)
        public delegate void MentionDiscount(decimal subTotal);

        public List<ProductModel> Items { get; set; } = new List<ProductModel>();
        public decimal GenerateTotal(MentionDiscount mentionSubtotal,
            Func<List<ProductModel>, decimal,decimal> calculateDiscountedTotal,
            Action<string> tellUserWeAreDiscounting)// the last parameter is output, "calculateDiscountedTotal" is the Func name
        {
            decimal subTotal = Items.Sum(x => x.Price); // "x => x.Price" - Func ie. tpye of delegates

            mentionSubtotal(subTotal); // This class has no idea what that does.

            tellUserWeAreDiscounting("We are applying your discount.");

            return calculateDiscountedTotal(Items, subTotal);
        }
    }
}
