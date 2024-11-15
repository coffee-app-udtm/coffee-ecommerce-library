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
using RevenueModel = CoffeeLibrary.Model.Revenue;
using StoreModel = CoffeeLibrary.Model.Store;

using CoffeeLibrary;

namespace UCRevenue
{
    public partial class UCRevenueList : UserControl
    {
        private int storeId = 0;
        private string accountType = null;
        private bool isAdmin = false;

        public UCRevenueList()
        {
            InitializeComponent();

            this.button_filter.Click += Button_filter_Click;
            this.button_export_excel.Click += Button_export_excel_Click;

            // Init năm hiện tại cho textbox năm
            textBox_Year.Text = DateTime.Now.Year.ToString();
        }

        // Gọi từ parent
        public async void RenderStoreRevenue(int storeId, string accountType) 
        {
            this.storeId = storeId;
            this.accountType = accountType;

            await RenderStoresCombobox();

            // Nếu account type là nhân viên thì chỉ cho filter theo ngày
            if (accountType == "Nhân viên")
            {
                this.radioButton_Day.Checked = true;

                this.radioButton_Month.Enabled = false;
                this.radioButton_Year.Enabled = false;
                this.textBox_Year.Enabled = false;
                this.comboBox_stores.Enabled = false;
            } else
            {
                this.radioButton_Day.Checked = true;

                this.radioButton_Month.Enabled = true;
                this.radioButton_Year.Enabled = true;
                this.textBox_Year.Enabled = true;
                this.comboBox_stores.Enabled = true;
            }

            if (this.radioButton_Day.Checked)
            {
                int month = dateTimePicker_Day.Value.Month;
                int year = dateTimePicker_Day.Value.Year;
                int day = dateTimePicker_Day.Value.Day;

                RenderRevenueGridView(day, month, year);

                return;
            }

            if (this.radioButton_Month.Checked)
            {
                int month = dateTimePicker_Month.Value.Month;
                int year = dateTimePicker_Month.Value.Year;

                RenderRevenueGridView(0, month, year);

                return;
            }

            if (this.radioButton_Year.Checked)
            {
                // Kiểm tra năm có hợp lệ không
                if (string.IsNullOrEmpty(textBox_Year.Text))
                {
                    MessageBox.Show("Vui lòng nhập năm cần lọc");
                    return;
                }

                // Kiểm tra năm có phải là số không
                if (!int.TryParse(textBox_Year.Text, out int n))
                {
                    MessageBox.Show("Năm không hợp lệ");
                    return;
                }

                int year = int.Parse(textBox_Year.Text);

                RenderRevenueGridView(0, 0, year);

                return;
            }
        }

        // Gọi từ parent
        public async void RenderAdminRevenue()
        {
            this.isAdmin = true;

            await RenderStoresCombobox();

            if (this.radioButton_Day.Checked)
            {
                int month = dateTimePicker_Day.Value.Month;
                int year = dateTimePicker_Day.Value.Year;
                int day = dateTimePicker_Day.Value.Day;

                RenderRevenueGridView(day, month, year);

                return;
            }

            if (this.radioButton_Month.Checked)
            {
                int month = dateTimePicker_Month.Value.Month;
                int year = dateTimePicker_Month.Value.Year;

                RenderRevenueGridView(0, month, year);

                return;
            }

            if (this.radioButton_Year.Checked)
            {
                // Kiểm tra năm có hợp lệ không
                if (string.IsNullOrEmpty(textBox_Year.Text))
                {
                    MessageBox.Show("Vui lòng nhập năm cần lọc");
                    return;
                }

                // Kiểm tra năm có phải là số không
                if (!int.TryParse(textBox_Year.Text, out int n))
                {
                    MessageBox.Show("Năm không hợp lệ");
                    return;
                }

                int year = int.Parse(textBox_Year.Text);

                RenderRevenueGridView(0, 0, year);

                return;
            }
        }

        private void Button_filter_Click(object sender, EventArgs e)
        {
            // Kiểm tra radio button nào được chọn
            if (this.radioButton_Day.Checked)
            {
                int month = dateTimePicker_Day.Value.Month;
                int year = dateTimePicker_Day.Value.Year;
                int day = dateTimePicker_Day.Value.Day;

                RenderRevenueGridView(day, month, year);

                return;
            }

            if (this.radioButton_Month.Checked)
            {
                int month = dateTimePicker_Month.Value.Month;
                int year = dateTimePicker_Month.Value.Year;

                RenderRevenueGridView(0, month, year);

                return;
            }

            if (this.radioButton_Year.Checked)
            {
                // Kiểm tra năm có hợp lệ không
                if (string.IsNullOrEmpty(textBox_Year.Text))
                {
                    MessageBox.Show("Vui lòng nhập năm cần lọc");
                    return;
                }

                // Kiểm tra năm có phải là số không
                if (!int.TryParse(textBox_Year.Text, out int n))
                {
                    MessageBox.Show("Năm không hợp lệ");
                    return;
                }

                int year = int.Parse(textBox_Year.Text);

                RenderRevenueGridView(0, 0, year);

                return;
            }

        }
    
        private async void RenderRevenueGridView(int day, int month, int year)
        {
            RevenueRequest revenueRequest = new RevenueRequest();
            List<RevenueModel> revenues = null;
            try
            {
                if (storeId > 0)
                {
                    // Render store revenue
                    revenues = await revenueRequest.GetRevenuesAsync(day, month, year, this.storeId);
                }
                else
                {
                    int storeIdCombobox = int.Parse(comboBox_stores.SelectedValue.ToString());

                    revenues = await revenueRequest.GetRevenuesAsync(day, month, year, storeIdCombobox);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (revenues == null)
            {
                MessageBox.Show("Không có dữ liệu");
                return;
            }

            dataGridView_revenue.DataSource = revenues;

            // Đổi tên cột period -> kiểm tra xem đang filter theo ngày, tháng hay năm
            if (year > 0 && day == 0 && month == 0)
            {
                dataGridView_revenue.Columns["period"].HeaderText = "Tháng";
            }

            if (month > 0 && year > 0)
            {
                dataGridView_revenue.Columns["period"].HeaderText = "Ngày";
            }

            dataGridView_revenue.Columns["total_revenue"].HeaderText = "Doanh thu";

            // Render total revenue label
            decimal totalRevenue = 0;

            foreach (var revenue in revenues)
            {
                totalRevenue += revenue.total_revenue ?? 0;
            }

            label_total_revenue.Text = Util.FormatVNCurrency(totalRevenue);
        }

        private async Task RenderStoresCombobox()
        {
            try
            {
                StoreRequest storeRequest = new StoreRequest();
                List<StoreModel> stores = await storeRequest.GetStoresAsync();

                // Add all store
                StoreModel allStore = new StoreModel
                {
                    id = 0,
                    store_name = "Tất cả cửa hàng"
                };

                stores.Insert(0, allStore);

                // Render combobox
                comboBox_stores.DataSource = stores;
                comboBox_stores.DisplayMember = "store_name";
                comboBox_stores.ValueMember = "id";

                // Disable combobox if is admin
                if (!this.isAdmin)
                {
                    comboBox_stores.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_export_excel_Click(object sender, EventArgs e)
        {
            if (dataGridView_revenue.DataSource == null)
            {
                MessageBox.Show("Không có dữ liệu để xuất file");
                return;
            }

            if (dataGridView_revenue.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất file");
                return;
            }

            // Show confirm dialog
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xuất file excel không?", "Xác nhận", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No)
            {
                return;
            }


            Microsoft.Office.Interop.Excel.Application MExcel = new Microsoft.Office.Interop.Excel.Application();
            MExcel.Application.Workbooks.Add(Type.Missing);

            for (int i = 1; i < dataGridView_revenue.Columns.Count + 1; i++)
            {
                MExcel.Cells[1, i] = dataGridView_revenue.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dataGridView_revenue.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView_revenue.Columns.Count; j++)
                {
                    MExcel.Cells[i + 2, j + 1] = dataGridView_revenue.Rows[i].Cells[j].Value?.ToString();
                }
            }

            MExcel.Columns.AutoFit();
            MExcel.Rows.AutoFit();
            MExcel.Columns.Font.Size = 12;
            MExcel.Visible = true;
        }
    }
}
