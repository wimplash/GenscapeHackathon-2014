namespace AforgeHack
{
    partial class WatchForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ImageryCheckBox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.hackPictureBox1 = new AforgeHack.HackPictureBox();
            this.EventsListBox = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hackPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CancelButton);
            this.panel1.Controls.Add(this.ImageryCheckBox);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 466);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(883, 94);
            this.panel1.TabIndex = 1;
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButton.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.ForeColor = System.Drawing.Color.White;
            this.CancelButton.Location = new System.Drawing.Point(411, 16);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(227, 66);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Visible = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ImageryCheckBox
            // 
            this.ImageryCheckBox.AutoSize = true;
            this.ImageryCheckBox.Location = new System.Drawing.Point(27, 31);
            this.ImageryCheckBox.Name = "ImageryCheckBox";
            this.ImageryCheckBox.Size = new System.Drawing.Size(167, 23);
            this.ImageryCheckBox.TabIndex = 1;
            this.ImageryCheckBox.Text = "Show Motion Imagery";
            this.ImageryCheckBox.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(644, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(227, 66);
            this.button1.TabIndex = 0;
            this.button1.Text = "Set Watch Points";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // hackPictureBox1
            // 
            this.hackPictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hackPictureBox1.Location = new System.Drawing.Point(0, 0);
            this.hackPictureBox1.MarkerSize = new System.Drawing.Size(40, 40);
            this.hackPictureBox1.Name = "hackPictureBox1";
            this.hackPictureBox1.Size = new System.Drawing.Size(744, 466);
            this.hackPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.hackPictureBox1.TabIndex = 0;
            this.hackPictureBox1.TabStop = false;
            this.hackPictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            // 
            // EventsListBox
            // 
            this.EventsListBox.BackColor = System.Drawing.Color.Black;
            this.EventsListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EventsListBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.EventsListBox.ForeColor = System.Drawing.Color.White;
            this.EventsListBox.FormattingEnabled = true;
            this.EventsListBox.ItemHeight = 17;
            this.EventsListBox.Location = new System.Drawing.Point(744, 0);
            this.EventsListBox.Name = "EventsListBox";
            this.EventsListBox.Size = new System.Drawing.Size(139, 466);
            this.EventsListBox.TabIndex = 2;
            // 
            // WatchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(883, 560);
            this.Controls.Add(this.hackPictureBox1);
            this.Controls.Add(this.EventsListBox);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "WatchForm";
            this.Text = "Watch";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.WatchForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hackPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private HackPictureBox hackPictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox ImageryCheckBox;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.ListBox EventsListBox;

    }
}

