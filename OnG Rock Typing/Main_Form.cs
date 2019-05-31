using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnG_Rock_Typing
{
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();

            // Loading ucLoadFile user controll when app initially loads
            if (!panelMain.Controls.Contains(ucLoadFile.Instance))
            {
                panelMain.Controls.Add(ucLoadFile.Instance);
                ucLoadFile.Instance.Dock = DockStyle.Fill;
                ucLoadFile.Instance.BringToFront();
                btnBack.Enabled = false;
                btnBack.Visible = false;
                btnCSVsave.Enabled = false;
                btnCSVsave.Visible = false;
                btnPNGsave.Enabled = false;
                btnPNGsave.Visible = false;
                btnStatSave.Enabled = false;
                btnStatSave.Visible = false;
            }
            else { ucLoadFile.Instance.BringToFront(); }
        }

        /// <summary>
        /// When BACK button is clicked ucLoadFile is brought to the front.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
                panelMain.Controls.Remove(ucFiltering.Instance);
                ucLoadFile.Instance.BringToFront();
                pictureBox2.Image = OnG_Rock_Typing.Properties.Resources.filtering_off;
                pictureBox3.Image = OnG_Rock_Typing.Properties.Resources.modeling_off;
                btnBack.Enabled = false;
                btnBack.Visible = false;
                btnNextStep.Enabled = true;
                btnNextStep.Visible = true;

            btnCSVsave.Enabled = false;
            btnCSVsave.Visible = false;
            btnPNGsave.Enabled = false;
            btnPNGsave.Visible = false;
            btnStatSave.Enabled = false;
            btnStatSave.Visible = false;
        }

        /// <summary>
        /// When NEXT STEP button is clicked ucFiltering is brought to the front
        /// or created.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNextStep_Click(object sender, EventArgs e)
        {
            if (ucLoadFile.Instance.getCurrentDataArray() == null)
            {
                MessageBox.Show("Data file must be loaded first in order to proceed.", "No data detected!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            { 
                panelMain.Controls.Add(ucFiltering.Instance);
                ucFiltering.Instance.Dock = DockStyle.Fill;
                ucFiltering.Instance.BringToFront();
                pictureBox2.Image = OnG_Rock_Typing.Properties.Resources.filtering_on;
                pictureBox3.Image = OnG_Rock_Typing.Properties.Resources.modeling_on;
                btnBack.Enabled = true;
                btnBack.Visible = true;
                btnNextStep.Enabled = false;
                btnNextStep.Visible = false;

                btnCSVsave.Enabled = true;
                btnCSVsave.Visible = true;
                btnPNGsave.Enabled = true;
                btnPNGsave.Visible = true;
                btnStatSave.Enabled = true;
                btnStatSave.Visible = true;
            }
        }

        private void btnCSVsave_Click(object sender, EventArgs e)
        {
            ucFiltering.Instance.saveCSVFile();
        }

        private void btnStatSave_Click(object sender, EventArgs e)
        {
            ucFiltering.Instance.saveCSVStatistics();
        }

        private void btnPNGsave_Click(object sender, EventArgs e)
        {
            ucFiltering.Instance.saveGraphs();
        }
    }
}
