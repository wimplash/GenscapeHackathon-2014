using AForgeHack.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AforgeHack
{
    public partial class LaunchForm : Form
    {
        public LaunchForm()
        {
            InitializeComponent();
            using (var db = new HackEntities())
            {
                this.FacilitiesComboBox.DataSource = db.Facilities.ToList();
            }
        }

        private void FacilitiesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CamerasComboBox.DataSource = (this.FacilitiesComboBox.SelectedItem as Facility).Cameras;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WatchForm watchForm = new WatchForm();
            watchForm.Camera = (Camera)this.CamerasComboBox.SelectedItem;
            watchForm.Show();
        }

    }
}
