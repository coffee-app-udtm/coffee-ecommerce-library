using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

using CoffeeLibrary.Model;

namespace UCProduct
{
    public partial class UCProductCard: UserControl
    {
        public event EventHandler<Product> selectProductEvent;
        private static readonly CultureInfo VietnameseCulture = new CultureInfo("vi-VN");

        private Product _product;

        public Product product {
            get { return _product; }
            set
            {
                _product = value;
                if (_product != null)
                {
                    // Gán các giá trị của product cho các control
                    label_product_name.Text = _product.name;
                    label_product_price.Text = _product.price.ToString("N0", VietnameseCulture) + " đ";
                    pictureBox_product_image.ImageLocation = _product.image;
                }
            }
        }


        public UCProductCard()
        {
            InitializeComponent();

            button_select.Click += btn_select_Click;

        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            // Pass product to parent
            if (selectProductEvent != null)
                selectProductEvent.Invoke(this, product);
        }
    }
}
