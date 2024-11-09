using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CoffeeLibrary.Model;
using CoffeeLibrary.Request;

namespace UCCategory
{
    public partial class UCCategoryList: UserControl
    {
        private readonly CategoryRequest categoryRequest = new CategoryRequest();

        public UCCategoryList()
        {
            InitializeComponent();

            RenderCategoryGridView();

            this.button_add.Click += Button_add_Click;
            this.button_edit.Click += Button_edit_Click;
            this.button_delete.Click += Button_delete_Click;
            this.dataGridView_categories.CellClick += DataGridView_categories_CellClick;
        }

        private void DataGridView_categories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_categories.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView_categories.SelectedRows[0];
                textBox_categoryName.Text = selectedRow.Cells["category_name"].Value.ToString();
            }
        }

        private async void Button_delete_Click(object sender, EventArgs e)
        {
            if (dataGridView_categories.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView_categories.SelectedRows[0];
                string categoryId = selectedRow.Cells["id"].Value.ToString();

                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    bool isDeleted = await categoryRequest.DeleteCategoryAsync(categoryId);

                    if (!isDeleted)
                    {
                        MessageBox.Show("Xóa danh mục thất bại.");
                        return;
                    }

                    MessageBox.Show("Xóa danh mục thành công");
                    RenderCategoryGridView();
                }
            }
            else
            {
                MessageBox.Show("Please select a category to delete.");
            }
        }

        private async void Button_edit_Click(object sender, EventArgs e)
        {
            if (dataGridView_categories.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView_categories.SelectedRows[0];
                
                // Lấy mã danh mục và chuyển sang kiểu int
                int categoryId = Convert.ToInt32(selectedRow.Cells["id"].Value);
                string newCategoryName = textBox_categoryName.Text;

                if (string.IsNullOrWhiteSpace(newCategoryName))
                {
                    MessageBox.Show("Hãy nhập tên danh mục");
                    return;
                }

                Category updatedCategory = await categoryRequest.UpdateCategoryAsync(categoryId, newCategoryName);

                if (updatedCategory == null)
                {
                    MessageBox.Show("Cập nhật danh mục thất bại");
                    return;
                }

                MessageBox.Show("Cập nhật danh mục thành công");
                RenderCategoryGridView();
                textBox_categoryName.Text = "";
            }
            else
            {
                MessageBox.Show("Hãy chọn danh mục để chỉnh sửa");
            }
        }

        private async void Button_add_Click(object sender, EventArgs e)
        {
            string categoryName = textBox_categoryName.Text;
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                MessageBox.Show("Hãy nhập tên danh mục");
                return;
            }

            Category newCategory = await categoryRequest.CreateCategoryAsync(categoryName);

            if (newCategory == null)
            {
                MessageBox.Show("Thêm danh mục thất bại");
                return;
            }


            MessageBox.Show("Thêm danh mục thành công");

            RenderCategoryGridView();
            textBox_categoryName.Text = "";

        }

        private async void RenderCategoryGridView()
        {
            try
            {
                List<Category> categories = await categoryRequest.GetCategoriesAsync();
                dataGridView_categories.DataSource = categories;

                // Đổi tên cột
                dataGridView_categories.Columns["id"].HeaderText = "Mã danh mục";
                dataGridView_categories.Columns["category_name"].HeaderText = "Tên danh mục";
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
