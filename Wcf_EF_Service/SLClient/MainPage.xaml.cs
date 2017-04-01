using Demo.WcfService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Demo
{
    public partial class MainPage : UserControl
    {
        public static userinfo CurrentUser = null;
        private WcfServiceClient Client = null;
        public MainPage()
        {
            InitializeComponent();

            Client = new WcfServiceClient(); //ServiceUtil.GetWcfServiceClient();
            Client.loginCompleted += Client_loginCompleted;
        }

        void Client_loginCompleted(object sender, loginCompletedEventArgs e)
        {
            CurrentUser = e.Result;
            if (CurrentUser != null)
            {
                this.resultLabel.Content = CurrentUser.realname + " 登陆成功!";
            }
            else
            {
                this.resultLabel.Content = "登陆失败!";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = this.TextBox1.Text.Trim();
            string pwd = this.TextBox2.Text.Trim();
            Client.loginAsync(name, pwd);
        }
    }
}
