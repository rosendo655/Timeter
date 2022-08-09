using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeManager.Models;

namespace TimeManager.UserControls
{
    public partial class Timer : UserControl
    {
        public static Timer FromModel(TaskModel model)
        {
            return new Timer()
            {
                Running = model.TaskStatus == TaskModelStatus.RUNNING,
                TaskName = model.TaskName,
                Seconds = model.Seconds
            };
        }

        public event EventHandler DeleteClicked;
        public event EventHandler RestartClicked;
        public event EventHandler PlayPauseClicked;

        private string taskName;
        public string TaskName
        {
            get => taskName;
            set
            {
                taskName = value;
                lblTaskName.Text = value;
            }
        }

        public long Seconds
        {
            get => timeView1.Time;
            set => timeView1.Time = value;
        }

        public string SecondsString => timeView1.TimeString;

        



        private bool running;

        public bool Running
        {
            get { return running; }
            set
            {
                running = value;
                btnPlayPause.Text = running ? "⏸️" : "▶️";
                if (value) Blink();
            }
        }

        public Timer()
        {
            InitializeComponent();
        }
        private void Blink()
        {
            
            this.BeginInvoke(new Action(async () =>
            {
                while (running)
                {
                    BackColor = Color.AliceBlue;
                    await Task.Delay(1500);
                    BackColor = Control.DefaultBackColor;
                    await Task.Delay(2000);
                }
                BackColor = Control.DefaultBackColor;
            }));
        }
        public void Tick()
        {
            if (!running) return;
            Seconds++;
        }
        public TaskModel GetModel()
        {
            return new TaskModel()
            {
                TaskName = TaskName,
                Seconds = Seconds,
                TaskStatus = Running ? TaskModelStatus.RUNNING : TaskModelStatus.PAUSED
            };
        }
        private void btn_clicked(object sender, EventArgs e)
        {
            if (sender == btnDelete) DeleteClicked?.Invoke(this, e);
            if (sender == btnRestart) RestartClicked?.Invoke(this, e);
            if (sender == btnPlayPause) PlayPauseClicked?.Invoke(this, e);
        }
    }
}
