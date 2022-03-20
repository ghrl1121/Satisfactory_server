using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;

namespace Satisfactory_서버용
{
    public partial class Form4 : Form
    {            
        public Form4()
        {
            
            InitializeComponent();
            Process[] M = Process.GetProcessesByName("UE4Server-Win64-Shipping");
            if(M.GetLength(0) > 0)
            {
                label8.Text = "실행중입니다. \n\r포트를 바꿔주세요 오류 납니다!\n\r옆 중지 누르면 서버중지(전부)됩니다";
                textBox1.Text = "15778";
                textBox3.Text = "7778";
                //실행할때마다 올려야하는데...;;
                label2.Text = "15001";
                linkLabel2.Text = "중지";
            }
            else
            {

            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process[] M = Process.GetProcessesByName("UE4Server-Win64-Shipping");               
            if(M.GetLongLength(0)>0)
            {
                M[0].Kill();
                M[0].WaitForExit(1000);
                Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://landtosky.kr/855");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //포트 쿼리
            int Query = int.Parse(textBox1.Text);
            //포트 게임
            int Port = int.Parse(textBox3.Text);
            //포트 신호(고정값)
            string Beacon = label2.Text;
            //아무것도 없을경우
            if (textBox1.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("숫자를 넣어 주세요");
            }
            else
            {
                // 80 이하 적을때
                if(Query < 79 || Port < 79)
                {
                    MessageBox.Show("80이상을 넣어 주세요");
                }
                else
                {
                    if (checkBox1.Checked == true)
                    {
                        //클릭했을때 만들기                        
                        string[] lines = { "@echo off", @"C:\satisfactory_dedicated\FactoryServer.exe" + " -ServerQusryPort=" + Query + " -BeaconPort=" + Beacon + " -port=" + Port + " -unattended" + " -log"};
                        File.WriteAllLines(@"C:\satisfactory_dedicated\b.bat", lines);
                        Process p = new Process();
                        p.StartInfo.FileName = "b.bat";
                        p.StartInfo.WorkingDirectory = @"C:\satisfactory_dedicated";
                        p.Start();
                        p.WaitForExit(1000);
                        File.Delete(@"C:\satisfactory_dedicated\b.bat");
                        Process[] u = Process.GetProcessesByName("cmd");
                        if(u.GetLength(0) > 0)
                        {
                            u[0].Kill();
                        }
                        Close();
                    }
                    else
                    {
                        //없음
                        string[] lines = { "@echo off", @"C:\satisfactory_dedicated\FactoryServer.exe" + " -ServerQusryPort=" + Query + " -BeaconPort=" + Beacon + " -port=" + Port + " -log"};
                        File.WriteAllLines(@"C:\satisfactory_dedicated\c.bat", lines);
                        Process p = new Process();
                        p.StartInfo.FileName = "c.bat";
                        p.StartInfo.WorkingDirectory = @"C:\satisfactory_dedicated";
                        p.Start();
                        p.WaitForExit(1000);
                        File.Delete(@"C:\satisfactory_dedicated\c.bat");
                        Process[] u = Process.GetProcessesByName("cmd");
                        if (u.GetLength(0) > 0)
                        {
                            u[0].Kill();
                        }
                        Close();
                    }
                }
            }
        }

        
    }
}
