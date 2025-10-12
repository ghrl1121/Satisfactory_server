using System;
using System.Diagnostics;
using System.Security.Permissions;
using System.Timers;
using System.Windows.Forms;

namespace Satisfactory_서버용
{
    public partial class Form4 : Form
    {


        public Form4()
        {

            InitializeComponent();
            //실행 채크
            var unme = Process.GetProcessesByName("FactoryServer-Win64-Shipping-Cmd");
            if (unme.Length > 0)
            {
                label8.Text = "실행중입니다. \n\r포트를 바꿔주세요 오류 납니다!\n\r옆 중지 누르면 서버중지(전부)됩니다";
                linkLabel2.Text = "중지";
            }

        }
        public Form4(string data)
        {
            InitializeComponent();
            textBox2.Text = data;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process[] M = Process.GetProcessesByName("FactoryServer-Win64-Shipping-Cmd");
            if (M.GetLongLength(0) > 0)
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
            //아무것도 없을경우
            if (textBox1.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("숫자를 넣어 주세요");
            }
            else
            {
                // 80 이하 적을때
                if (Query < 79 || Port < 79)
                {
                    MessageBox.Show("80이상을 넣어 주세요");
                }
                else
                {
                    if (checkBox1.Checked == true)
                    {
                    A:
                        var unpe = Process.GetProcessesByName("FactoryServer-Win64-Shipping-Cmd");
                        if (unpe.Length > 0)
                        {
                            //실행중...
                            //대기시간
                            //루트
                        }
                        else
                        {
                            //다시시작
                            var nem = new ProcessStartInfo(textBox2.Text + @"\FactoryServer.exe", " -ServerQusryPort=" + Query + " -port=" + Port + " -unattended" + " -NoAsyncLoadingThread -UseMultithreadForDS -log");
                            nem.UseShellExecute = false;
                            Process.Start(nem);
                            //대기시간
                        }
                        goto A;
                    }
                    else
                    {
                    A:
                        var unpe = Process.GetProcessesByName("FactoryServer-Win64-Shipping-Cmd");
                        if (unpe.Length > 0)
                        {
                            //실행중
                            //대기시간
                            //루트
                        }
                        else
                        {
                            //없음
                            var nem = new ProcessStartInfo(textBox2.Text + @"\FactoryServer.exe", " -ServerQusryPort=" + Query + " -port=" + Port + " -NoAsyncLoadingThread -UseMultithreadForDS -log");
                            nem.UseShellExecute = false;
                            Process.Start(nem);
                            //대기시간
                            timer1.Start();
                            timer1.Interval = 60000; 
                            timer1.Stop();
                        }
                        goto A;
                    }
                }
            }
        }
    }
}