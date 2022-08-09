using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeManager.Models;
using TimeManager.UserControls;

namespace TimeManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        public List<UserControls.Timer> Timers =>
             flpTimers.Controls.Cast<Control>()
            .Where(w => w is UserControls.Timer)
            .Select(s => s as UserControls.Timer)
            .ToList();

        public List<NoteView> Notes =>
             flpNotes.Controls.Cast<Control>()
            .Where(w => w is NoteView)
            .Select(s => s as NoteView)
            .ToList();

        private void TickTimers()
            => Timers.ForEach(fe => fe.Tick());


        private void AddTimer(string name, long seconds)
        => AddTimer(new Models.TaskModel { TaskName = name, Seconds = seconds, TaskStatus = TaskModelStatus.PAUSED });
        private void AddTimer(TaskModel model)
        {
            UserControls.Timer timer = UserControls.Timer.FromModel(model);
            flpTimers.Controls.Add(timer);
        }
        private void AddNote(NoteModel model)
        {
            flpNotes.Controls.Add(UserControls.NoteView.FromModel(model));
        }
        private void SaveData()
        {
            File.WriteAllText("data.json", JsonConvert.SerializeObject(new ContentModel
            {
                Tasks = Timers.Select(s => s.GetModel()).ToList(),
                QuickNotes = Notes.Select(s => s.GetModel()).ToList()
            }));
        }
        private void ReadData()
        {
            if (File.Exists("data.json"))
            {
                string jsonText = File.ReadAllText("data.json");
                ContentModel model = JsonConvert.DeserializeObject<ContentModel>(jsonText);

                model.Tasks.ForEach(fe => fe.TaskStatus = TaskModelStatus.PAUSED);

                model.Tasks.ForEach(fe => AddTimer(fe));
                model.QuickNotes.ForEach(fe => AddNote(fe));
            }
        }
        private void Export()
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.DefaultExt = ".txt";

            if (fd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllLines(fd.FileName, Timers.Select(s => $"{s.TaskName}\t{s.SecondsString}"));
            }
        }


        
        private void flPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            if (e.Control is UserControls.Timer t)
            {
                t.Width = flpTimers.Width - 10;
                //t.Anchor = AnchorStyles.Left | AnchorStyles.Right;

                t.DeleteClicked += TimerDeleteClicked;
                t.RestartClicked += TimerRestartClicked;
                t.PlayPauseClicked += TimerPlayPauseClicked;
            }
        }
        private void TimerPlayPauseClicked(object sender, EventArgs e)
        {
            if (sender is UserControls.Timer t)
            {
                bool prevState = t.Running;
                Timers.ForEach(fe => fe.Running = false);
                t.Running = !prevState;
            }
        }
        private void TimerRestartClicked(object sender, EventArgs e)
        {
            var mboxResult = MessageBox.Show("Seguro que deseas reiniciar?", "Aviso", MessageBoxButtons.YesNo);
            if (sender is UserControls.Timer t && mboxResult == DialogResult.Yes)
            {
                t.Running = false;
                t.Seconds = 0;
            }
        }
        private void TimerDeleteClicked(object sender, EventArgs e)
        {
            var mboxResult = MessageBox.Show("Seguro que deseas borrar esta tarea?", "Aviso", MessageBoxButtons.YesNo);
            if (sender is UserControls.Timer t && mboxResult == DialogResult.Yes)
            {
                flpTimers.Controls.Remove(t);
            }
        }
        private void flPanel_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (e.Control is UserControls.Timer t)
            {
                t.DeleteClicked -= TimerDeleteClicked;
                t.RestartClicked -= TimerRestartClicked;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var model = new Models.TaskModel { Seconds = 0, TaskName = tbTask.Text, TaskStatus = Models.TaskModelStatus.PAUSED };
            AddTimer(model);
        }
        private void btnAddNote_Click(object sender, EventArgs e)
        {
            var model = new Models.NoteModel()
            {
                Text = tbNote.Text,
                Pinned = 0
            };
            AddNote(model);
        }
        private void NotePinClicked(object sender, EventArgs e)
        {
            var notes = Notes;
            flpNotes.Controls.Clear();
            flpNotes.Controls.AddRange(notes.OrderByDescending(o => o.Pinned ? 1 : 0).ToArray());
        }
        private void flpNotes_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (e.Control is NoteView nv)
            {
                nv.DeleteClicked -= NoteDeleteClicked;
                nv.PinClicked -= NotePinClicked;
            }
        }
        private void NoteDeleteClicked(object sender, EventArgs e)
        {
            if (sender is NoteView nv)
            {
                flpNotes.Controls.Remove(nv);
            }
        }
        private void flpNotes_ControlAdded(object sender, ControlEventArgs e)
        {
            if (e.Control is NoteView nv)
            {
                nv.Width = flpNotes.Width - 5;
                nv.Anchor = AnchorStyles.Right | AnchorStyles.Left;

                nv.DeleteClicked += NoteDeleteClicked;
                nv.PinClicked += NotePinClicked;
            }
        }
        private void FormShown(object sender, EventArgs e)
        {
            ReadData();
            timerSeconds.Start();
            timerSaver.Start();
        }
        private void FormClosedd(object sender, FormClosedEventArgs e)
        {
            SaveData();
        }
        private void TimerTick(object sender, EventArgs e)
        {
            if (sender == timerSeconds)
            {
                TickTimers();
                timeViewTotal.Time = Timers.Sum(s => s.Seconds);
            }
            if (sender == timerSaver) SaveData();
        }
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void tbKeydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (sender == tbTask)
            {
                AddTimer(tbTask.Text, 0);
            }
            if(sender == tbNote)
            {
                
            }
        }
    }
}
