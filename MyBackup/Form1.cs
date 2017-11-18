using System.Windows.Forms;

namespace MyBackup
{
    /// <summary>
    /// DEMO 頁面
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// 初始
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
            MyBackupService myBackupService = new MyBackupService();
            myBackupService.ProcessJsonConfigs();
            myBackupService.SimpleBackup();
            myBackupService.ScheduledBackup();
            listBox1.Items.Add("顯示JSON檔內容筆數");
            listBox1.Items.Add(myBackupService.DoPrintCount());
        }
    }
}