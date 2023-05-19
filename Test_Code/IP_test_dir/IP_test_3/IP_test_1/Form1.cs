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
using System.Net.NetworkInformation;

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
            label1.Text = GetIP();
            foreach (var network in NetworkInterface.GetAllNetworkInterfaces())
            {
                label2.Text = label2.Text + network.Name + "\n";
            }
                
        }

        // VMware Network 무시하려면?
        public static string GetIP()
        {
            string IPs = "";

            //모든 네트워크 인터페이스 얻기
            foreach (var network in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (network.Name == "이더넷" || network.Name == "Wi-Fi")
                {
                    //IPv4를 지원하는 네트워크 확인
                    if (network.Supports(NetworkInterfaceComponent.IPv4) == true)
                    {
                        if (NetworkInterface.GetIsNetworkAvailable() && network.OperationalStatus == OperationalStatus.Up)
                        {
                            //Unicast 주소가 할당된 ip 얻기
                            foreach (UnicastIPAddressInformation uniIp in network.GetIPProperties().UnicastAddresses)
                            {
                                if (uniIp.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                                {
                                    string ipAddress = uniIp.Address.ToString();
                                    if (ipAddress != null)
                                    {
                                        IPs = IPs + ipAddress + "\n";
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return IPs;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
