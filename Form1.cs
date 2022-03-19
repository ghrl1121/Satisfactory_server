using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;


namespace Satisfactory_서버용
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("잠깐 steamcmd.exe 가 있어야 됩니다.");
            B:
            Process[] u = Process.GetProcessesByName("steamcmd");
           if (u.GetLength(0) > 0)
            {
                MessageBox.Show("어라 steamcmd.exe 가 실행 되고 있습니다 \r 강재 종료 됩니다.!");
                u[0].Kill();
                u[0].WaitForExit(1000);                
                goto B;
            }
            else { 
            AC:
            OpenFileDialog A = new OpenFileDialog();
            A.Title = "steamcmd.exe 선택하세요";
            A.FileName = "steamcmd.exe";
            A.Filter = "실행파일(*.exe)|*.exe;";
            DialogResult d = A.ShowDialog();
                if (d == DialogResult.OK)
                {
                    if (Path.GetFileName(A.FileName) == "steamcmd.exe")
                    {
                        string fileName = A.FileName;
                        string[] lines = { "@echo off", "steamcmd.exe +login anonymous +force_install_dir C:\\Satisfactory_Dedicated +app_update 1690800 +quit", "pause" };
                        File.WriteAllLines(Path.GetDirectoryName(A.FileName) + "\\commd.bat", lines);
                        Process p = new Process();
                        p.StartInfo.FileName = "commd.bat";
                        p.StartInfo.WorkingDirectory = Path.GetDirectoryName(fileName);
                        p.Start();
                        p.WaitForExit(1000);
                        File.Delete(Path.GetDirectoryName(fileName) + "\\commd.bat");
                    }
                    else
                    {
                        MessageBox.Show("앗 stamcmd.exe를 선택을 안하셨습니다.");
                        goto AC;
                    }
                }
                else if (d == DialogResult.Cancel)
                {
                    MessageBox.Show("파일이 없습니까?");
                    Form3 m = new Form3();
                    m.ShowDialog();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(Directory.Exists(@"C:\Satisfactory_Dedicated"))
            { 
                Form4 d = new Form4();
                d.Show();
            }
            else
            {
                MessageBox.Show("파일이 없습니다! \n서버 다운후 다시 클릭하세요");
            }
                    
        }
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("잠깐 실행 먼저 하시고 접속하신후에 눌려 주세요 아니면 오류 납니다!");
            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\..\Local\FactoryGame\Saved\SaveGames\"))
            {
                Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\..\Local\FactoryGame\Saved\SaveGames\");
            }
            else
            {
                MessageBox.Show("실행후 만들고 눌려 주세요!");
            }
        }
        
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/ghrl1121/Satisfactory_server");
        }
    }
}
