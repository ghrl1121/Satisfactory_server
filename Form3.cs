using System;
using System.Diagnostics;
using System.Windows.Forms;


namespace Satisfactory_서버용
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("https://steamcdn-a.akamaihd.net/client/installer/steamcmd.zip");
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
