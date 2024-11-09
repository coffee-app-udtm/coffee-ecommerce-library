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

namespace UCLogin
{
    public partial class UCLoginStore: UserControl
    {
        public event EventHandler<StoreLogin> LoginSuccessfulEvent;

        public UCLoginStore()
        {
            InitializeComponent();

            this.button_login.Click += Button_login_Click;
        }

        private async void Button_login_Click(object sender, EventArgs e)
        {
            string store_login_name = this.textbox_login_name.Text;
            string password = this.textbox_password.Text;

            if (string.IsNullOrEmpty(store_login_name) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Hãy điền tên đăng nhập và mật khẩu");
                return;
            }

            // Call API to login
            try
            {
                AuthRequest authRequest = new AuthRequest();
                StoreLogin storeLogin = await authRequest.loginToStore(store_login_name, password);

                if (storeLogin == null)
                {
                    MessageBox.Show("Đăng nhập thất bại");
                    return;
                }


                // Pass data to parent  
                LoginSuccessfulEvent?.Invoke(this, storeLogin);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
