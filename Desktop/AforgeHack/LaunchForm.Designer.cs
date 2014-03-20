namespace AforgeHack
{
    partial class LaunchForm
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
            this.FacilitiesComboBox = new System.Windows.Forms.ComboBox();
            this.CamerasComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FacilitiesComboBox
            // 
            this.FacilitiesComboBox.FormattingEnabled = true;
            this.FacilitiesComboBox.Location = new System.Drawing.Point(301, 79);
            this.FacilitiesComboBox.Name = "FacilitiesComboBox";
            this.FacilitiesComboBox.Size = new System.Drawing.Size(337, 24);
            this.FacilitiesComboBox.TabIndex = 0;
            this.FacilitiesComboBox.SelectedIndexChanged += new System.EventHandler(this.FacilitiesComboBox_SelectedIndexChanged);
            // 
            // CamerasComboBox
            // 
            this.CamerasComboBox.FormattingEnabled = true;
            this.CamerasComboBox.Location = new System.Drawing.Point(301, 110);
            this.CamerasComboBox.Name = "CamerasComboBox";
            this.CamerasComboBox.Size = new System.Drawing.Size(337, 24);
            this.CamerasComboBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(189, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select a Facility";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Select a Camera";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(301, 188);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(218, 86);
            this.button1.TabIndex = 5;
            this.button1.Text = "Watch";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LaunchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(832, 387);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CamerasComboBox);
            this.Controls.Add(this.FacilitiesComboBox);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "LaunchForm";
            this.Text = "LaunchForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox FacilitiesComboBox;
        private System.Windows.Forms.ComboBox CamerasComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}