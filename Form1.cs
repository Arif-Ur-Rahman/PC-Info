using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Management;
using Microsoft.Win32;

namespace PC_Information_Display
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        // Show Basic information button details
        private void button2_Click(object sender, EventArgs e)
        {

            textBox1.Text = "";


            string newLine = Environment.NewLine;
            string hostName = Dns.GetHostName();
            DateTime now = DateTime.Now;


            textBox1.Text = "User Name : " + Environment.UserName +
                newLine + newLine + "Host Name : " + Environment.MachineName +
                newLine + newLine + "IP Address : " + Dns.GetHostByName(hostName).AddressList[0].ToString() +
                newLine + newLine + "Date & Time : " + now.ToString("F");

            
        }


        // Show software information button details
        private void button3_Click(object sender, EventArgs e)
        {

            textBox1.Text = "";
            string newLine = Environment.NewLine;


            string uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(uninstallKey))
            {
                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        try
                        {
                            textBox1.Text += "** ";
                            textBox1.Text += Convert.ToString(sk.GetValue("DisplayName"));
                            textBox1.Text += newLine;
                        }

                        catch (Exception ex)

                        { }
                    }
                    
                }
            }

        }

        // Show hardware information button details

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            

            string newLine = Environment.NewLine;  // for new line 

            textBox1.Text = "Version : " + Environment.OSVersion.Version.ToString() +
                newLine + newLine + "Operation System : " + Environment.OSVersion.ToString() +
                newLine + newLine + "Operation System Platform : " + Environment.OSVersion.Platform.ToString() +
                newLine + newLine + "Processor Counter : " + Environment.ProcessorCount.ToString() +
                newLine + newLine + "64 bit OS : " + Environment.Is64BitOperatingSystem.ToString() +
                newLine + newLine + "64 bit Process : " + Environment.Is64BitProcess.ToString();

        }





        // Show Storage information button details
        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            

            string newLine = Environment.NewLine;

            foreach (DriveInfo drInfo in DriveInfo.GetDrives())
            {

                if (drInfo.DriveType == DriveType.Fixed)
                {
                    double x1 = drInfo.TotalSize/(1024*1024*1024);
                    double x2 = drInfo.TotalFreeSpace/(1024*1024*1024);

                    textBox1.Text += "Drive Name : " + drInfo.Name +
                        newLine +  "Drive Lavel : " + drInfo.VolumeLabel +
                        newLine + "Total Space : " + x1 +" GB" +
                        newLine + "Total Free Space : " + x2 + " GB" +
                        newLine + "Drive Type : " + drInfo.DriveType +
                        newLine + "Drive Format : " + drInfo.DriveFormat+
                        newLine + "-------------------------------------------" + newLine;
            
                }
            }

            
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        
        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
           
        }

        private void panel_header_Paint(object sender, PaintEventArgs e)
        {

        }


        // Use close button for closing the window
        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Use minimize button for minimize the window
        private void btn_min_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
