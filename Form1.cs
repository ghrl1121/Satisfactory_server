﻿using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;


namespace Satisfactory_서버용
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (File.Exists("txat.lal"))
            {
                button1.Text = "얼리 액세스\n\r서버다운로드";
                StreamReader sr = new StreamReader("txat.lal");
                textBox1.Text = sr.ReadLine();
                sr.Close();
            }
            else if (File.Exists("beta.lal"))
            {
                button1.Text = "익스페리멘탈\n\r서버다운로드";
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
                //실행중  
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
                    MessageBox.Show("잠깐!! 폴더를 한글로 하지 마세요 요류납니다!!\r\n예) 딱다구리폴더에 steamcmd.exe 넣었으면 실행후 바로 종료됨(오류임)");
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
                            MessageBox.Show("이것도 마찬가기 입니다 한글로 하실경우 원하는 위치가 설치가 안됩니다 \r\n예) 딱다구리폴더에 넣음 하지만 파일은 steamcmd.exe 파일에 있는 steamapps폴더에 저장이 됨");
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
                                string[] lines = { "@echo off","cd "+A.FileName+"steamcmd.exe +login anonymous +force_install_dir " + mest + " +app_update 1690800 -beta experimental validate  +quit", "pause" };
                                File.WriteAllLines(Path.GetDirectoryName(A.FileName) + "\\commd.bat", lines);
                                Process process = new Process();
                                process.StartInfo.FileName = "commd.bat";
                                process.StartInfo.WorkingDirectory = Path.GetDirectoryName(A.FileName);
                                process.Start();
                                process.WaitForExit(1000);
                                process.Close();
                                File.Delete(Path.GetDirectoryName(A.FileName) + "\\commd.bat");
                                //필요없는 파일 삭제
                                File.Delete(Path.GetDirectoryName(mest) + @"\b.ini");
                            }
                            else
                            {
                                MessageBox.Show("저장될 위치를 넣어 주세요!");
                                goto C;
                            }                           
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
                    MessageBox.Show("잠깐!! 폴더를 한글로 하지 마세요 요류납니다!!\r\n예) 딱다구리폴더에 steamcmd.exe 넣었으면 실행후 바로 종료됨(오류임)");
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
                            MessageBox.Show("이것도 마찬가기 입니다 한글로 하실경우 원하는 위치가 설치가 안됩니다 \r\n예) 딱다구리폴더에 넣음 하지만 파일은 steamcmd.exe 파일에 있는 steamapps폴더에 저장이 됨");
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
                                string[] lines = { "@echo off","steamcmd.exe +login anonymous +force_install_dir " + mest + " +app_update 1690800 -beta public validate +quit", "pause" };
                                File.WriteAllLines(Path.GetDirectoryName(A.FileName) + "\\commd.bat", lines);
                                Process process = new Process();
                                process.StartInfo.FileName = "commd.bat";
                                process.StartInfo.WorkingDirectory = Path.GetDirectoryName(A.FileName);
                                process.Start();
                                process.WaitForExit(1000);
                                process.Close();
                                File.Delete(Path.GetDirectoryName(A.FileName) + "\\commd.bat");
                                //필요없는 파일 삭제
                                File.Delete(Path.GetDirectoryName(mest) + @"\b.ini");
                            }
                            else
                            {
                                MessageBox.Show("저장될 위치를 넣어 주세요!");
                                goto C;
                            }
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
            if (File.Exists(textBox1.Text + @"\FactoryServer.exe"))
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
                button1.Text = "익스페리멘탈\n\r서버다운로드";
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
                button1.Text = "얼리 액세스\n\r서버다운로드";
                if (File.Exists("txat.lal"))
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
