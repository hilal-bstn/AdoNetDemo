using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNetDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductDal _productDal = new ProductDal();
        private void LoadPRoducts()
        { dgwProducts.DataSource = _productDal.GetAll2(); }
        private void Form1_Load(object sender, EventArgs e)
        {

            dgwProducts.DataSource = _productDal.GetAll2();
        }

       

        private void btnRemove_Click_1(object sender, EventArgs e)
        { int id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value);
            _productDal.Delete(id);
            LoadPRoducts();
            MessageBox.Show("Deleted");

        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            Product product = new Product
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                Name = tbxNameUpdate.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text),
                StockAmount = Convert.ToInt32(tbxStockAmountUpdate.Text)
            };
            _productDal.Update(product);
            LoadPRoducts();
            MessageBox.Show("Updated");

        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            _productDal.Add(new Product { Name = tbxName.Text, UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text), StockAmount = Convert.ToInt32(tbxStockAmount.Text) });
            MessageBox.Show("Product Added");
            LoadPRoducts();

        }

        private void dgwProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgwProducts_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            tbxNameUpdate.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbxUnitPriceUpdate.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbxStockAmountUpdate.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();

        }
    }
}

