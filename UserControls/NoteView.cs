using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeManager.Models;

namespace TimeManager.UserControls
{
    public partial class NoteView : UserControl
    {
        public event EventHandler DeleteClicked;
        public event EventHandler PinClicked;

        private bool pinned;
        public bool Pinned
        {
            get { return pinned; }
            set 
            { 
                pinned = value;
                btnPin.BackColor = value ? Color.LightGreen : Control.DefaultBackColor;
            }
        }

        private string note;
        new public string Text
        {
            get { return note; }
            set 
            { 
                note = value; 
                lblText.Text = value;
            }
        }
        public NoteView()
        {
            InitializeComponent();
        }
        public static NoteView FromModel(NoteModel model)
        {
            return new NoteView()
            {
                Text = model.Text,
                Pinned = model.Pinned == 1
            };
        }
        public NoteModel GetModel()
        {
            return new NoteModel()
            {
                Pinned = Pinned ? 1 : 0,
                Text = Text
            };
        }
        private void btnClick(object sender, EventArgs e)
        {
            if (sender == btnDelete) DeleteClicked?.Invoke(this, e);
            if(sender == btnPin)
            {
                Pinned = !Pinned;
                PinClicked?.Invoke(this, e);
            }
        }
    }
}
