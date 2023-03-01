﻿using System;
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
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Satisfactory_서버용
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (File.Exists("txat.lal"))
            {
                StreamReader sr = new StreamReader("txat.lal");
                textBox1.Text = sr.ReadLine();
                sr.Close();
            }
            else if (File.Exists("beta.lal"))
            {
                StreamReader su = new StreamReader("beta.lal");
                textBox1.Text = su.ReadLine();
                checkBox1.Checked = true;
                su.Close();
            }
            else
            {
                textBox1.Text = "설치 먼저 해 주세요";
            }
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
            else
            {
                //배타 넣기
                if (checkBox1.Checked == true)
                {
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
                           C:
                            SaveFileDialog saveFileDialog = new SaveFileDialog();
                            saveFileDialog.Title = "저장될 위치 설정";
                            saveFileDialog.FileName = "b.ini";
                            DialogResult saveResult = saveFileDialog.ShowDialog();
                            if (saveResult == DialogResult.OK)
                            {
                                //선언 하면 저정
                                textBox1.Text = Path.GetDirectoryName(saveFileDialog.FileName);
                                string mest = textBox1.Text;
                                string[] ping = { textBox1.Text };
                                File.WriteAllLines("beta.lal", ping);
                                //설치
                                string[] lines = { "@echo off", "steamcmd.exe +login anonymous +force_install_dir " + mest + " +app_update 1690800 -beta experimental validate  +quit", "pause" };
                                File.WriteAllLines(Path.GetDirectoryName(A.FileName) + "\\commd.bat", lines);
                                //필요없는 파일 삭제
                                File.Delete(Path.GetDirectoryName(mest) + @"\b.ini");
                            }
                            else
                            {
                                MessageBox.Show("저장될 위치를 넣어 주세요!");
                                goto C;
                            }
                            string fileName = A.FileName;


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
                else
                {
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
                         C:
                            SaveFileDialog saveFileDialog = new SaveFileDialog();
                            saveFileDialog.Title = "저장될 위치 설정";
                            saveFileDialog.FileName = "b.ini";
                            DialogResult saveResult = saveFileDialog.ShowDialog();
                            if (saveResult == DialogResult.OK)
                            {
                                //선언 하면 저정
                                textBox1.Text = Path.GetDirectoryName(saveFileDialog.FileName);
                                string mest = textBox1.Text;
                                string[] ping = { textBox1.Text };
                                File.WriteAllLines("txat.lal", ping);
                                //설치
                                string[] lines = { "@echo off", "steamcmd.exe +login anonymous +force_install_dir " + mest + " +app_update 1690800 -beta public validate +quit", "pause" };
                                File.WriteAllLines(Path.GetDirectoryName(A.FileName) + "\\commd.bat", lines);
                                //필요없는 파일 삭제
                                File.Delete(Path.GetDirectoryName(mest) + @"\b.ini");
                            }
                            else
                            {
                                MessageBox.Show("저장될 위치를 넣어 주세요!");
                                goto C;
                            }
                            string fileName = A.FileName;


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
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if(Directory.Exists(textBox1.Text))
            { 
                Form4 d = new Form4(textBox1.Text);                             
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (File.Exists("beta.lal"))
                {
                    StreamReader su = new StreamReader("beta.lal");
                    textBox1.Text = su.ReadLine();
                    checkBox1.Checked = true;
                    su.Close();
                }
                else
                {
                    textBox1.Text = "파일이 없습니다 설치 먼저 해주세요";
                }
            }
            else if (checkBox1.Checked == false) 
            {
                if(File.Exists("txat.lal"))
                {
                    StreamReader bv = new StreamReader("txat.lal");
                    textBox1.Text = bv.ReadLine();
                    bv.Close();
                }
                else
                {
                    textBox1.Text = "파일이 없습니다 설치 먼저 해주세요";
                }
            }
        }
    }
}
