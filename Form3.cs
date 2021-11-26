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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("https://steamcdn-a.akamaihd.net/client/installer/steamcmd.zip");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
