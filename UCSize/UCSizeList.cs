using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeLibrary.Request;
using CoffeeLibrary.Model;
using Size = CoffeeLibrary.Model.Size;

namespace UCSize
{
    public partial class UCSizeList: UserControl
    {
        private readonly SizeRequest sizeRequest = new SizeRequest();
        public UCSizeList()
        {
            InitializeComponent();

            RenderSizeGridView();

            this.button_add.Click += Button_add_Click;
            this.button_edit.Click += Button_edit_Click;
            this.button_delete.Click += Button_delete_Click;
            this.dataGridView_sizes.CellClick += DataGridView_sizes_CellClick;
        }

        private void DataGridView_sizes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_sizes.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView_sizes.SelectedRows[0];
                textBox_sizeName.Text = selectedRow.Cells["size_name"].Value.ToString();
            }
        }

        private async void Button_delete_Click(object sender, EventArgs e)
        {
            if (dataGridView_sizes.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView_sizes.SelectedRows[0];
                string sizeId = selectedRow.Cells["id"].Value.ToString();

                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    bool isDeleted = await sizeRequest.DeleteSizeAsync(sizeId);

                    if (!isDeleted)
                    {
                        MessageBox.Show("Xóa size thất bại.");
                        return;
                    }

                    MessageBox.Show("Xóa size thành công");
                    RenderSizeGridView();
                }
            }
            else
            {
                MessageBox.Show("Please select a size to delete.");
            }
        }

        private async void Button_edit_Click(object sender, EventArgs e)
        {
            if (dataGridView_sizes.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView_sizes.SelectedRows[0];

                // Lấy mã size và chuyển sang kiểu int
                int sizeId = Convert.ToInt32(selectedRow.Cells["id"].Value);
                string newSizeName = textBox_sizeName.Text;

                if (string.IsNullOrWhiteSpace(newSizeName))
                {
                    MessageBox.Show("Hãy nhập tên size");
                    return;
                }

                Size updatedSize = await sizeRequest.UpdateSizeAsync(sizeId, newSizeName);

                if (updatedSize == null)
                {
                    MessageBox.Show("Cập nhật size thất bại");
                    return;
                }

                MessageBox.Show("Cập nhật size thành công");
                RenderSizeGridView();
                textBox_sizeName.Text = "";
            }
            else
            {
                MessageBox.Show("Hãy chọn size để chỉnh sửa");
            }
        }

        private async void Button_add_Click(object sender, EventArgs e)
        {
            string sizeName = textBox_sizeName.Text;
            if (string.IsNullOrWhiteSpace(sizeName))
            {
                MessageBox.Show("Hãy nhập tên size");
                return;
            }

            Size newSize = await sizeRequest.CreateSizeAsync(sizeName);

            if (newSize == null)
            {
                MessageBox.Show("Thêm size thất bại");
                return;
            }


            MessageBox.Show("Thêm size thành công");

            RenderSizeGridView();
            textBox_sizeName.Text = "";

        }

        private async void RenderSizeGridView()
        {
            try
            {
                List<Size> sizes = await sizeRequest.GetSizesAsync();
                dataGridView_sizes.DataSource = sizes;

                // Đổi tên cột
                dataGridView_sizes.Columns["id"].HeaderText = "Mã size";
                dataGridView_sizes.Columns["size_name"].HeaderText = "Tên size";
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
