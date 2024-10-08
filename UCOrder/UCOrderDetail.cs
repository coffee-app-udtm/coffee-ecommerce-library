using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CoffeeLibrary;
using CoffeeLibrary.Request;
using CoffeeLibrary.Model;

namespace UCOrder
{
    public partial class UCOrderDetail : UserControl
    {
        public Order order { get; set; }
        public event EventHandler<Order> updateOrderStatusEvent;

        public UCOrderDetail()
        {
            InitializeComponent();

            this.button_updateStatus.Click += Button_updateStatus_Click;
        }

        private async void Button_updateStatus_Click(object sender, EventArgs e)
        {
            if (comboBox_orderStatus.SelectedItem == null) return;
            
            string newStatus = comboBox_orderStatus.SelectedItem.ToString();
            
            if (newStatus == order.order_status) return;

            // Open dialog to confirm
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn cập nhật trạng thái đơn hàng?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No) return;

            try
            {
                button_updateStatus.Text = "Đang cập nhật...";
                button_updateStatus.Enabled = false;

                OrderRequest orderRequest = new OrderRequest();
               
                order.order_status = newStatus;

                bool result = await orderRequest.UpdateOrderStatusAsync(order, newStatus);

                if (updateOrderStatusEvent != null) updateOrderStatusEvent.Invoke(this, order);


                Init(order);

                MessageBox.Show("Cập nhật trạng thái đơn hàng thành công.");

                button_updateStatus.Text = "Cập nhật";
                button_updateStatus.Enabled = true;

                RenderComboboxOrderStatus();

            } catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

                button_updateStatus.Text = "Cập nhật";
                button_updateStatus.Enabled = true;
            }

        }

        public void Init(Order _order)
        {
            this.order = _order;
            if (_order == null || order == null) return;

            // Render order infor
            label_orderId.Text = order.id;
            label_orderDate.Text = order.order_date.ToString("dd/MM/yyyy HH:mm:ss");
            label_paymentMethod.Text = order.payment_method;
            label_totalPayment.Text = Util.FormatVNCurrency(order.total_payment);
            label_orderStatus.Text = order.order_status;

            // Render customer infor
            label_customerName.Text = order.user_name;
            label_phoneNumber.Text = order.phone_number;
            label_receiverName.Text = order.receiver_name;
            textBox_orderNote.Text = order.order_note;

            RenderComboboxOrderStatus();
            SetSelectedStatus(order.order_status);

            RenderGridViewOrderItems();
        }

        private void RenderComboboxOrderStatus()
        {
            string currentStatus = order.order_status;

            comboBox_orderStatus.Items.Clear();

            switch (currentStatus)
            {
                case "Đang chờ":
                    comboBox_orderStatus.Items.Add("Đang chờ");
                    comboBox_orderStatus.Items.Add("Đang xử lý");
                    comboBox_orderStatus.Items.Add("Đã hủy");
                    break;

                case "Đang xử lý":
                    comboBox_orderStatus.Items.Add("Đang xử lý");
                    comboBox_orderStatus.Items.Add("Đang giao hàng");
                    comboBox_orderStatus.Items.Add("Đã hủy");
                    break;

                case "Đang giao hàng":
                    comboBox_orderStatus.Items.Add("Đang giao hàng");
                    comboBox_orderStatus.Items.Add("Hoàn thành");
                    break;

                case "Hoàn thành":
                    comboBox_orderStatus.Items.Add("Hoàn thành");
                    break;

                case "Đã hủy":
                    comboBox_orderStatus.Items.Add("Đã hủy");
                    break;

                default:
                    MessageBox.Show("Trạng thái đơn hàng không hợp lệ.");
                    break;
            }
        }

        private void SetSelectedStatus(string status)
        {
            foreach(var item in comboBox_orderStatus.Items)
            {
                if (item.ToString() == status)
                {
                    comboBox_orderStatus.SelectedItem = item;
                    return;
                }
            }
        }

        private void RenderGridViewOrderItems()
        {
            dataGridView_orderItems.DataSource = order.order_items;

            // hide size_id column

            if (dataGridView_orderItems.Columns["size_id"] != null) dataGridView_orderItems.Columns["size_id"].Visible = false;
            dataGridView_orderItems.Columns["product_id"].Visible = false;
            if (dataGridView_orderItems.Columns["user_id"] != null) dataGridView_orderItems.Columns["user_id"].Visible = false;


            dataGridView_orderItems.Columns["product_name"].HeaderText = "Tên sản phẩm";
            dataGridView_orderItems.Columns["size_name"].HeaderText = "Kích cỡ";
            dataGridView_orderItems.Columns["quantity"].HeaderText = "Số lượng";
            dataGridView_orderItems.Columns["product_price"].HeaderText = "Đơn giá";
            dataGridView_orderItems.Columns["order_item_price"].HeaderText = "Thành tiền";
        }

    }
}
