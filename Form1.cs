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
            
            OpenFileDialog A = new OpenFileDialog();
            A.Title = "steamcmd.exe 선택하세요";
            A.FileName = "steamcmd.exe";
            A.Filter = "실행파일(*.exe)|*.exe;";
            DialogResult d = A.ShowDialog();
            if (d == DialogResult.OK)
            {
                string fileName = A.FileName;
                
                string[] lines = { "@echo off","steamcmd.exe +login anonymous +force_install_dir C:\\Satisfactory_Dedicated +app_update 1690800 +quit", "pause" };
                File.WriteAllLines(Path.GetDirectoryName(A.FileName)+"\\commd.bat", lines);
                Process p = new Process();
                p.StartInfo.FileName = "commd.bat";
                p.StartInfo.WorkingDirectory = Path.GetDirectoryName(fileName);
                p.Start();
                File.Delete(Path.GetDirectoryName(fileName) + "\\commd.bat");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] lines = {"@echo off", "FactoryServer.exe -log -unattended","pause" };
            File.WriteAllLines(@"C:\satisfactory_dedicated\실행.bat", lines);
            Process a = new Process();
            a.StartInfo.FileName = "실행.bat";
            a.StartInfo.WorkingDirectory = @"C:\satisfactory_dedicated";
            a.Start();
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form2 m = new Form2();
            m.Show();
        }
        
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/ghrl1121/Satisfactory_server");
        }

      
    }
}