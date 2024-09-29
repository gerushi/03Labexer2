using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using _03LabExer2;

namespace _03LabExer2
{

    public partial class frmAddProduct : Form
    {
        private string _ProductName, _Category, _MfgDate, _ExpDate, _Description;
        private int _Quantity;
        private double _SellPrice;

        private BindingSource showProductList;
        public string Product_Name(string name)
        {
            try
            {
                if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                {
                    throw new StringFormatException("Product Name must contain only letters.");
                }
                return name;
            }
            catch (StringFormatException ex)
            {
                MessageBox.Show(ex.Message, "Invalid Product Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {

            }
        }
        public int Quantity(string qty)
        {
            try
            {
                if (!Regex.IsMatch(qty, @"^[0-9]+$"))
                {
                    throw new NumberFormatException("Quantity must be a valid integer.");
                }
                return Convert.ToInt32(qty);
            }
            catch (NumberFormatException ex)
            {
                MessageBox.Show(ex.Message, "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0; 
            }
            finally
            {
            }
        }

        public double SellingPrice(string price)
        {
            try
            {
                if (!Regex.IsMatch(price.ToString(), @"^(\d*\.)?\d+$"))
                {
                    throw new CurrencyFormatException("Selling Price must be a valid currency amount.");
                }
                return Convert.ToDouble(price);
            }
            catch (CurrencyFormatException ex)
            {
                MessageBox.Show(ex.Message, "Invalid Selling Price", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0.0;
            }
            finally
            {

            }
        }
        public frmAddProduct()
        {
            InitializeComponent();
            showProductList = new BindingSource();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ListOfProductCategory = new string[]
            {
                "Beverages",
                "Bread/Bakery",
                "Canned/Jarred Goods",
                "Dairy",
                "Frozen Goods",
                "Meat",
                "Personal Care",
                "Other"
            };
            foreach (string productList in ListOfProductCategory)
            {
                cbCategory.Items.Add(productList);
            }
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSellPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtPickerExpDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtPickerMfgDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void richTxtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void gridViewProductList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            _ProductName = Product_Name(txtProductName.Text);
            _Category = cbCategory.Text;
            _MfgDate = dtPickerMfgDate.Value.ToString("yyyy-MM-dd");
            _ExpDate = dtPickerExpDate.Value.ToString("yyyy-MM-dd");
            _Description = richTxtDescription.Text;
            _Quantity = Quantity(txtQuantity.Text);
            _SellPrice = SellingPrice(txtSellPrice.Text);
            showProductList.Add(new ProductClass(_ProductName, _Category, _MfgDate,
            _ExpDate, _SellPrice, _Quantity, _Description));
            gridViewProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridViewProductList.DataSource = showProductList;
        }

        public class StringFormatException : Exception
        {
            public StringFormatException(string message) : base(message) { }
        }

        public class NumberFormatException : Exception
        {
            public NumberFormatException(string message) : base(message) { }
        }

        public class CurrencyFormatException : Exception
        {
            public CurrencyFormatException(string message) : base(message) { }
        }

    }
}
