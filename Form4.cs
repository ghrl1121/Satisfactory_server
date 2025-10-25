using System;
using System.Diagnostics;
using System.Drawing.Text;
using System.IO;
using System.Reflection.Emit;
using System.Security.Permissions;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Satisfactory_서버용
{
    public partial class Form4 : Form
    {

        private Thread thd;
        delegate void CrossCall();
        /*private static bool mtes;
        private Mutex ntx1 = new Mutex(false,"ntxobj",out  mtes);*/
        public Form4()
        {
            InitializeComponent();
        }
        public Form4(string data)
        {
            InitializeComponent();
            textBox2.Text = data;
            //실행 채크
            //반복으로 확인하기
            int i = 0;
            while (i < 10)
            {
                i++;
                var unme = Process.GetProcessesByName("FactoryServer-Win64-Shipping-Cmd");
                if (unme.Length > 0)
                {
                    label8.Text = "실행중입니다. \n\r포트를 바꿔주세요 오류 납니다!\n\r옆 중지 누르면 서버중지(전부)됩니다";
                    linkLabel2.Text = "중지";
                }
            }
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process[] M = Process.GetProcessesByName("FactoryServer-Win64-Shipping-Cmd");
            if (M.GetLongLength(0) > 0)
            {
                M[0].Kill();
                M[0].WaitForExit(1000);
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
                    thd = new Thread(new ThreadStart(ThreadFunction));
                    label2.Text = "실행중...";
                    button1.Enabled = false;
                    button2.Enabled = true;
                    thd.Start();
                }
                   
            }
        }

        private void ThreadFunction()
        {
            //포트 쿼리
            int Query = int.Parse(textBox1.Text);
            //포트 게임
            int Port = int.Parse(textBox3.Text);
            if (checkBox1.Checked == true)
            {
                while (true)
                {
                    var unpe = Process.GetProcessesByName("FactoryServer-Win64-Shipping-Cmd");
                    if (unpe.Length > 0)
                    {
                        //실행중...                       
                        //대기시간
                        Thread.Sleep(3000);
                    }
                    else
                    {
                        //다시시작
                        /*var nem = new ProcessStartInfo(textBox2.Text + @"\FactoryServer.exe", " -ServerQusryPort=" + Query + " -port=" + Port + " -unattended" + " -NoAsyncLoadingThread -UseMultithreadForDS -log");
                        nem.UseShellExecute = false;
                        Process.Start(nem);*/
                        Process process = new Process();
                        process.StartInfo.FileName = "FactoryServer.exe";
                        process.StartInfo.Arguments = " -ServerQusryPort=" + Query + " -port=" + Port + " -unattended" + " -NoAsyncLoadingThread -UseMultithreadForDS -log";
                        process.StartInfo.WorkingDirectory = textBox2.Text;
                        process.Start();
                        //대기시간
                        process.WaitForExit(5000);
                    }
                }
            }
            else
            {
                while (true)
                {
                    var unpe = Process.GetProcessesByName("FactoryServer-Win64-Shipping-Cmd");
                    if (unpe.Length > 0)
                    {
                        //실행중
                        
                        //대기시간
                        Thread.Sleep(3000);
                    }
                    else
                    {
                        //다시시작
                        /*var nem = new ProcessStartInfo(textBox2.Text + @"\FactoryServer.exe", " -ServerQusryPort=" + Query + " -port=" + Port + " -NoAsyncLoadingThread -UseMultithreadForDS -log");
                        nem.UseShellExecute = false;
                        Process.Start(nem);*/
                        Process process = new Process();
                        process.StartInfo.FileName = "FactoryServer.exe";
                        process.StartInfo.Arguments = " -ServerQusryPort=" + Query + " -port=" + Port + " -NoAsyncLoadingThread -UseMultithreadForDS -log";
                        process.StartInfo.WorkingDirectory = textBox2.Text;
                        process.Start();
                        //대기시간
                        process.WaitForExit(5000);
                    }
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            thd.Suspend();
            label2.Text = "일시정지";
            button3.Enabled = true;
            button2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            thd.Resume();
            label2.Text = "다시시작";
            label2.Text = "실행중...-3초마다 확인-";
            button2.Enabled = true;
            button3.Enabled = false;
        }
    }
}