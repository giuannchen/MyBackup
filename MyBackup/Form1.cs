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
            ConfigManager configManager = new ConfigManager();
            configManager.ProcessConfigs();
            for (int i = 0; i < configManager.Count; i++)
            {
                Config config = configManager[i];
                listBox1.Items.Add(config.Ext);
            }

            ScheduleManager scheduleManager = new ScheduleManager();
            scheduleManager.ProcessSchedules();
            for (int i = 0; i < scheduleManager.Count - 1; i++)
            {
                Schedule schedule = scheduleManager[i];
                listBox1.Items.Add(schedule.Ext);
            }
        }
    }
}