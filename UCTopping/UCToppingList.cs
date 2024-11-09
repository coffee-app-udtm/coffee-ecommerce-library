using CoffeeLibrary.Model;
using CoffeeLibrary.Request;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UCTopping
{
    public partial class UCToppingList : UserControl
    {
        private readonly ToppingRequest toppingRequest = new ToppingRequest();

        public UCToppingList()
        {
            InitializeComponent();

            RenderToppingGridView();

            this.button_add.Click += Button_add_Click;
            this.button_edit.Click += Button_edit_Click;
            this.button_delete.Click += Button_delete_Click;
            this.dataGridView_toppings.CellClick += DataGridView_toppings_CellClick;
        }

        private void DataGridView_toppings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_toppings.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView_toppings.SelectedRows[0];
                textBox_toppingName.Text = selectedRow.Cells["topping_name"].Value.ToString();
                //textBox_toppingPrice.Text = selectedRow.Cells["topping_price"].Value.ToString();
                decimal toppingPrice = Convert.ToDecimal(selectedRow.Cells["topping_price"].Value);

                // Format it to remove decimal places
                textBox_toppingPrice.Text = toppingPrice.ToString("F0");

            }
        }

        private async void Button_delete_Click(object sender, EventArgs e)
        {
            if (dataGridView_toppings.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView_toppings.SelectedRows[0];
                string toppingId = selectedRow.Cells["id"].Value.ToString();

                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    bool isDeleted = await toppingRequest.DeleteToppingAsync(toppingId);

                    if (!isDeleted)
                    {
                        MessageBox.Show("Xóa topping thất bại.");
                        return;
                    }

                    MessageBox.Show("Xóa topping thành công");
                    RenderToppingGridView();
                }
            }
            else
            {
                MessageBox.Show("Please select a topping to delete.");
            }
        }

        private async void Button_edit_Click(object sender, EventArgs e)
        {
            if (dataGridView_toppings.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView_toppings.SelectedRows[0];

                // Lấy mã topping và chuyển sang kiểu int
                int toppingId = Convert.ToInt32(selectedRow.Cells["id"].Value);
                string newToppingName = textBox_toppingName.Text;
                decimal newToppingPrice = Convert.ToDecimal(textBox_toppingPrice.Text);

                if (string.IsNullOrWhiteSpace(newToppingName))
                {
                    MessageBox.Show("Hãy nhập tên topping");
                    return;
                }

                if (newToppingPrice < 0)
                {
                    MessageBox.Show("Giá topping phải lớn hơn 0");
                    return;
                }

                bool result = await toppingRequest.UpdateToppingAsync(toppingId, newToppingName, newToppingPrice);

                if (!result)
                {
                    MessageBox.Show("Cập nhật topping thất bại");
                    return;
                }

                MessageBox.Show("Cập nhật topping thành công");
                RenderToppingGridView();
                textBox_toppingName.Text = "";
            }
            else
            {
                MessageBox.Show("Hãy chọn topping để chỉnh sửa");
            }
        }

        private async void Button_add_Click(object sender, EventArgs e)
        {
            string toppingName = textBox_toppingName.Text;
            decimal toppingPrice = Convert.ToDecimal(textBox_toppingPrice.Text);

            if (string.IsNullOrWhiteSpace(toppingName))
            {
                MessageBox.Show("Hãy nhập tên topping");
                return;
            }

            if (toppingPrice < 0)
            {
                MessageBox.Show("Giá topping phải lớn hơn 0");
                return;
            }

            Topping newTopping = await toppingRequest.CreateToppingAsync(toppingName, toppingPrice);

            if (newTopping == null)
            {
                MessageBox.Show("Thêm topping thất bại");
                return;
            }


            MessageBox.Show("Thêm topping thành công");

            RenderToppingGridView();
            textBox_toppingName.Text = "";

        }

        private async void RenderToppingGridView()
        {
            try
            {
                List<Topping> toppings = await toppingRequest.GetToppingsAsync();
                dataGridView_toppings.DataSource = toppings;

                // Đổi tên cột
                dataGridView_toppings.Columns["id"].HeaderText = "Mã topping";
                dataGridView_toppings.Columns["topping_name"].HeaderText = "Tên topping";
                dataGridView_toppings.Columns["topping_price"].HeaderText = "Giá topping";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void HideActionButtons()
        {
            button_add.Visible = false;
            button_edit.Visible = false;
            button_delete.Visible = false;
        }
    }
}
