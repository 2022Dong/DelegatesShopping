using DemoLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsUI
{
    public partial class Dashboard : Form
    {
        static ShoppingCartModel cart = new ShoppingCartModel();
        public Dashboard()
        {
            InitializeComponent();
            PopulateCartWithDemoData();
        }

        private static void PopulateCartWithDemoData()
        {
            cart.Items.Add(new ProductModel { ItemName = "Cereal", Price = 3.63M });
            cart.Items.Add(new ProductModel { ItemName = "Milk", Price = 2.95M });
            cart.Items.Add(new ProductModel { ItemName = "Strawberries", Price = 7.51M });
            cart.Items.Add(new ProductModel { ItemName = "Blueberries", Price = 8.84M });
        }
        private void btnMessageBoxDemo_Click(object sender, EventArgs e)
        {
            // Calling each methods
            decimal total = cart.GenerateTotal(subTotalAlert, CalculateLeveledDiscount, PrintOutDiscountAlert);

            MessageBox.Show($"The total is {total:C2}");
        }               

        private void btnTextBoxDemo_Click(object sender, EventArgs e)
        {
            // Calling in a line
            decimal total = cart.GenerateTotal((subTotal) => txtSubtotal.Text = $"{subTotal:C2}",
                (products, subTotal) => subTotal - (products.Count * 2),
                (msg) => { });

            txtTotal.Text = $"{total:C2}";
        }

        // Calling delegates - pass similar signature
        private void PrintOutDiscountAlert(string discountMessage) // Action
        {
            MessageBox.Show(discountMessage);
        }

        private void subTotalAlert(decimal subTotal) // Delagates initial
        {
            MessageBox.Show($"The subtotal is {subTotal:C2}");
        }

        private decimal CalculateLeveledDiscount(List<ProductModel> products, decimal subTotal) // Func
        {
            return subTotal - products.Count;
        }
    }
}
