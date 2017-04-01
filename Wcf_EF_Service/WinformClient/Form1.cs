using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinformClient.WcfService;

namespace WinformClient
{
    public partial class Form1 : Form
    {
        private WcfServiceClient WcfClient = null;
        public Form1()
        {
            InitializeComponent();
            WcfClient = new WcfServiceClient();

            WcfClient.loginCompleted += WcfClient_loginCompleted;
            WcfClient.AddUserCompleted += WcfClient_AddUserCompleted;
        }

        void WcfClient_AddUserCompleted(object sender, AddUserCompletedEventArgs e)
        {
            if (e.Result)
            {
                MessageBox.Show("添加成功!");
            }
            else {
                MessageBox.Show("添加失败!");
            }
        }

        void WcfClient_loginCompleted(object sender, loginCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                MessageBox.Show(string.Format("{0}登陆成功!", e.Result.realname));
            }
            else {
                MessageBox.Show("登录失败!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string uid = this.textBox1.Text.Trim();
            string pwd = this.textBox2.Text.Trim();
            WcfClient.loginAsync(uid, pwd);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string uid = this.textBox1.Text.Trim();
            string pwd = this.textBox2.Text.Trim();
            if (uid==""||pwd=="")
            {
                MessageBox.Show("信息不全!");
                return;
            }
            userinfo u = new userinfo();
            u.userid = uid;
            u.password = pwd;
            u.creator = "arwqt4g";
            u.realname = "AAAAAA";
            WcfClient.AddUserAsync(u);
        }
    }
}
