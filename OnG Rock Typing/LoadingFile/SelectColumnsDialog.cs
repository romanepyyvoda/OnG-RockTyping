using System;
using System.Collections;
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
    /// <summary>
    /// Selection dialog that allows to choose specific columns to work with.
    /// </summary>
    public partial class SelectColumnsDialog : Form
    {
        private ArrayList selectedItems = new ArrayList();
        public SelectColumnsDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method populates list of check boxes with list of original columns.
        /// </summary>
        /// <param name="initialheaderRow"></param>
        public void setCheckBoxList(string[] initialheaderRow) {
            string[] headerRow = initialheaderRow;

            foreach(string item in headerRow)
            {
                checkedListBoxColumnsToDisplay.Items.Add(item, false);
            }
        }

        /// <summary>
        /// Method collects selected items into array list.
        /// </summary>
        /// <returns></returns>
        public ArrayList getSelectedItems() {

            ArrayList checkedItems = new ArrayList();
            foreach (string item in checkedListBoxColumnsToDisplay.CheckedItems)
            {
                checkedItems.Add(item);
            }
            return checkedItems;
        }

        /// <summary>
        /// Method puts selected items into global var and closes dialog
        /// when OK button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetNewColumns_Click(object sender, EventArgs e)
        {
            selectedItems = getSelectedItems();
            Close();
        }

        /// <summary>
        /// Closes dialog when CANCEL button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Cleares all selected items on button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearAll_Click(object sender, EventArgs e)
        {
            foreach (int i in checkedListBoxColumnsToDisplay.CheckedIndices)
            {
                checkedListBoxColumnsToDisplay.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        /// <summary>
        /// Method to be used outside of this class get list of selected columns.
        /// </summary>
        /// <returns></returns>
        public ArrayList getSelectedColumns()
        {
            return selectedItems;
        }

        /// <summary>
        /// Selects all items on button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            int count = checkedListBoxColumnsToDisplay.Items.Count;
            for (int i = 0; i < checkedListBoxColumnsToDisplay.Items.Count; i++)
            {
                checkedListBoxColumnsToDisplay.SetItemCheckState(i, CheckState.Checked);
            }
        }
    }
}
