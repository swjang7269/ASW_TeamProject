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

namespace IP_test_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = GetInternalIP();
            label2.Text = GetPublicIP();
        }

        /*
        static void Main(string[] args)
        {

            Console.WriteLine("사설 IP : " + GetInternalIP());
            Console.WriteLine("공인 IP : " + GetPublicIP());
            Console.ReadKey();
        }
        */

        public static string GetInternalIP()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            throw new Exception("IPv4 주소를 찾을 수 없습니다.");
        }

        private static string GetPublicIP()
        {
            string publicIp = new WebClient().DownloadString("http://ipinfo.io/ip").Trim();

            //null경우 Get Internal IP를 가져오게 한다.
            if (String.IsNullOrWhiteSpace(publicIp))
            {
                publicIp = GetInternalIP();
            }

            return publicIp;
        }
    }
}
