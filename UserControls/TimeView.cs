using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeManager.UserControls
{
    public partial class TimeView : UserControl
    {
        private static string SecondsToTime(long seconds)
        {
            long hours = seconds / 3600;
            long minutes = (seconds % 3600) / 60;
            seconds = seconds % 60;
            return $"{hours:00}:{minutes:00}:{seconds:00}";
        }
        public string TimeString
        {
            get => lblTime.Text;
            set => lblTime.Text = value;
        }
        private long time;
            public long Time
        {
            get => time;
            set
            {
                time = value;
                TimeString = SecondsToTime(value);
            }
        }
        public TimeView()
        {
            InitializeComponent();
        }

        private void btn_click(object sender, EventArgs e)
        {
            var button = sender as Button;
            int add = int.Parse(button.Tag as string);
            Time += add;
        }
    }
}
