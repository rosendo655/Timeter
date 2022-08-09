namespace TimeManager.UserControls
{
    partial class Timer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTaskName = new System.Windows.Forms.Label();
            this.btnPlayPause = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.timeView1 = new TimeManager.UserControls.TimeView();
            this.SuspendLayout();
            // 
            // lblTaskName
            // 
            this.lblTaskName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTaskName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaskName.Location = new System.Drawing.Point(10, 12);
            this.lblTaskName.Name = "lblTaskName";
            this.lblTaskName.Size = new System.Drawing.Size(591, 24);
            this.lblTaskName.TabIndex = 0;
            this.lblTaskName.Text = "Task";
            this.lblTaskName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPlayPause
            // 
            this.btnPlayPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlayPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayPause.Location = new System.Drawing.Point(571, 56);
            this.btnPlayPause.Margin = new System.Windows.Forms.Padding(0);
            this.btnPlayPause.Name = "btnPlayPause";
            this.btnPlayPause.Size = new System.Drawing.Size(38, 30);
            this.btnPlayPause.TabIndex = 1;
            this.btnPlayPause.Text = "⏸️";
            this.btnPlayPause.UseVisualStyleBackColor = true;
            this.btnPlayPause.Click += new System.EventHandler(this.btn_clicked);
            // 
            // btnRestart
            // 
            this.btnRestart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestart.Location = new System.Drawing.Point(48, 56);
            this.btnRestart.Margin = new System.Windows.Forms.Padding(0);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(38, 30);
            this.btnRestart.TabIndex = 2;
            this.btnRestart.Text = "↩️";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btn_clicked);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(10, 56);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(38, 30);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "❌";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btn_clicked);
            // 
            // timeView1
            // 
            this.timeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.timeView1.Location = new System.Drawing.Point(462, 39);
            this.timeView1.Name = "timeView1";
            this.timeView1.Size = new System.Drawing.Size(92, 49);
            this.timeView1.TabIndex = 5;
            this.timeView1.Time = ((long)(0));
            this.timeView1.TimeString = "00:00:00";
            // 
            // Timer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.timeView1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.btnPlayPause);
            this.Controls.Add(this.lblTaskName);
            this.Name = "Timer";
            this.Size = new System.Drawing.Size(618, 92);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTaskName;
        private System.Windows.Forms.Button btnPlayPause;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnDelete;
        private TimeView timeView1;
    }
}
