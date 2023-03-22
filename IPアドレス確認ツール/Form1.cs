using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPアドレス確認ツール
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            // コントロールの値をクリア
            HostNameTextBox.Clear();
            IPv4TextBox.Clear();
            IPv6TextBox.Clear();

            // IPアドレスを取得
            string hostName = "";
            string ipv4 = "";
            string ipv6 = "";
            try
            {
                hostName = Dns.GetHostName();
                IPAddress[] ips = Dns.GetHostAddresses(hostName);
                foreach (IPAddress ip in ips)
                {
                    // IPv4アドレスを取得
                    if (ip.AddressFamily.Equals(AddressFamily.InterNetwork))
                    {
                        ipv4 = ip.ToString();
                    }

                    // IPv6アドレスを取得
                    if (ip.AddressFamily.Equals(AddressFamily.InterNetworkV6))
                    {
                        ipv6 = ip.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"IPアドレス取得中にエラー発生\n{ex}");
                MessageBox.Show($"IPアドレスの取得中にエラーが発生しました。\n\n{ex}",
                                "エラー",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }


            // 結果を表示
            Console.WriteLine("IPアドレス取得完了");
            Console.WriteLine($"ホスト名：{hostName}");
            Console.WriteLine($"IPv4アドレス：{ipv4}");
            Console.WriteLine($"IPv6アドレス：{ipv6}");
            HostNameTextBox.Text = hostName;
            IPv4TextBox.Text = ipv4;
            IPv6TextBox.Text = ipv6;
            MessageBox.Show("IPアドレス取得完了",
                            "完了",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }
    }
}
