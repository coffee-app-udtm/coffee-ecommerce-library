using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CoffeeLibrary.Request;
using CoffeeLibrary.Model;


namespace UCLogin
{
    public partial class UCLoginAdmin : UserControl
    {
        public event EventHandler<User> LoginSuccessfulEvent;
        public UCLoginAdmin()
        {
            InitializeComponent();

            this.button_login.Click += Button_login_Click;
        }

        private async void Button_login_Click(object sender, EventArgs e)
        {
            string email = this.textbox_email.Text;
            string password = this.textbox_password.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Hãy điền email và mật khẩu");
                return;
            }

            // Call API to login
            try
            {
                AuthRequest authRequest = new AuthRequest();
                User user = await authRequest.loginToAdmin(email, password);

                if (user == null)
                {
                    MessageBox.Show("Đăng nhập thất bại");
                    return;
                }

                // Pass data to parent
                LoginSuccessfulEvent?.Invoke(this, user);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
