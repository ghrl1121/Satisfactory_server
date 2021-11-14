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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("잠깐 실행 먼저 하시고 접속하신후에 눌려 주세요 아니면 오류 납니다!");
            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\..\Local\FactoryGame\Saved\SaveGames\server"))
            {
                Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\..\Local\FactoryGame\Saved\SaveGames\server");
            }
            else
            {
                MessageBox.Show("실행후 만들고 눌려 주세요!");
            }
        }
    }
}
