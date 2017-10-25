using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyBackup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            MyBackupService myBackupService = new MyBackupService();
            myBackupService.ProcessJsonConfigs();
            myBackupService.DoBackup();
            listBox1.Items.Add("顯示JSON檔內容筆數");
            listBox1.Items.Add(myBackupService.DoPrintCount());
        }
    }
}