using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnG_Rock_Typing
{
    /// <summary>
    /// Class performs filtering on array of data.
    /// </summary>
    public partial class ucFilter : UserControl
    {
        // Member variables
        private int filterId;
        private string variableName;
        private int variableNameIndex;
        private int filteringOperator;
        private double passedValueNumber;
        private string passedValueText;
        private string[] listOfVariables;
        private bool someFieldIsEmpty;
        private bool isAllowedToEnterNumber;
        private bool isAllowToEnterText;
        
        // Constructor, default values.
        public ucFilter(int filterId)
        {
            this.listOfVariables = ucLoadFile.Instance.getCurrentColumnNames();
            this.filterId = filterId;
            this.variableName = "";
            this.variableNameIndex = 999;
            this.filteringOperator = -1;
            this.passedValueNumber = -9999;
            InitializeComponent();

            cbSelectVariable.Text = "Select Variable";
            for (int i = 0; i < listOfVariables.Length; i++)
            {
                cbSelectVariable.Items.Add(listOfVariables[i]);
            }
            cbSelectAction.Text = "Select Action";
            cbSelectAction.Items.Add(">"); //case 1
            cbSelectAction.Items.Add("≥"); //case 2
            cbSelectAction.Items.Add("<"); //case 3
            cbSelectAction.Items.Add("≤"); //case 4
            cbSelectAction.Items.Add("Delete Missing Data"); //case 5
            cbSelectAction.Items.Add("Include all that ="); //case 6
        }

        // Method gets filter ID
        public int getFilterId()
        {
            return this.filterId;
        }

        /// <summary>
        /// Closing filter when close button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeFilterButton_Click(object sender, EventArgs e)
        {
            ucFiltering.Instance.deleteFilter(this.filterId);
        }
         
        /// <summary>
        /// Input validator for input field (text box). Will allow only numbers, breakspace and dot.
        /// Will not allow dot as first character.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            int dotCount = textBoxEnterValue.Text.Count(f => f == '.');
            if (!isAllowToEnterText)
            {
                if ((dotCount == 0 && textBoxEnterValue.Text.Length == 0 && e.KeyChar == '.') || dotCount > 0)
                {
                    //allows backspace and delete keys
                    if (e.KeyChar != '\b')
                    {
                        //allows just number keys
                        e.Handled = !char.IsNumber(e.KeyChar);
                    }
                }
                else
                {
                    //allows backspace and delete keys and dot
                    if (e.KeyChar != '\b' && e.KeyChar != '.')
                    {
                        //allows just number keys
                        e.Handled = !char.IsNumber(e.KeyChar);
                    }
                }
            }
        }

        /// <summary>
        /// Method renders fields active/inactive denending on selected action in dropdown.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbSelectAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Console.WriteLine(cbSelectAction.SelectedIndex);
            this.filteringOperator = cbSelectAction.SelectedIndex + 1;
            if (filteringOperator == 5) { textBoxEnterValue.Enabled = false; isAllowedToEnterNumber = false; }
            else if (filteringOperator == 6) { textBoxEnterValue.Enabled = true; isAllowToEnterText = true; isAllowedToEnterNumber = false; }
            else
            {   if (isAllowToEnterText) { textBoxEnterValue.Clear(); }
                isAllowToEnterText = false; textBoxEnterValue.Enabled = true; isAllowedToEnterNumber = true; }
        }

        /// <summary>
        /// Method gets variable name and index when selected in dropdown.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbSelectVariable_SelectedValueChanged(object sender, EventArgs e)
        {
            this.variableName = cbSelectVariable.SelectedItem.ToString();
            variableNameIndex = cbSelectVariable.SelectedIndex;
        }

        /// <summary>
        /// Method check what type of input comes from text box, -
        /// if number - result inserted into double variable,
        /// if text - string variable.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxEnterValue_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxEnterValue.Text))
            {
                double i = 0;
                bool isNumber = double.TryParse(textBoxEnterValue.Text, out i);
                if (isNumber && !isAllowToEnterText)
                {
                    Console.WriteLine(i);
                    passedValueNumber = i;
                }
                else { Console.WriteLine("Not a number!"); passedValueText = textBoxEnterValue.Text; }
            }
            else { passedValueNumber = -999; }
        }

        /// <summary>
        /// Method filters out selected range out of array.
        /// Case 6 includes only value that has been specifiied and deletes everytyhing else.
        /// </summary>
        /// <param name="unfilteredArray"></param>
        /// <returns></returns>
        public string[,] filterOUT(string[,] unfilteredArray)
        {
            someFieldIsEmpty = false;
            checkForEmptyFields();
            if (this.isEmpty()) { return null; }

            string[,] filteredArray = null;
            int count = 0;
            switch (filteringOperator)
            {
                case 1: //var > value
                    for (int r = 0; r < unfilteredArray.GetLength(0); r++)
                    {
                        double currentNumber1 = 0;
                        bool isNumber1 = double.TryParse(unfilteredArray[r, variableNameIndex], out currentNumber1);
                        if ((isNumber1 && (currentNumber1 <= passedValueNumber)) || !isNumber1)
                        { count++; }
                    }
                    filteredArray = new string[count, listOfVariables.Length];
                    int newRowIndex1 = 0;
                    for (int r = 0; r < unfilteredArray.GetLength(0); r++)
                    {
                        double currentNumber2 = 0;
                        bool isNumber2 = double.TryParse(unfilteredArray[r, variableNameIndex], out currentNumber2);
                        if ((isNumber2 && (currentNumber2 <= passedValueNumber)) || !isNumber2)
                        {
                            for (int k = 0; k < listOfVariables.Length; k++)
                            {
                                filteredArray[newRowIndex1, k] = unfilteredArray[r, k];
                            }
                            newRowIndex1++;
                        }
                    }
                    break;

                case 2: // var >= value
                    for (int r = 0; r < unfilteredArray.GetLength(0); r++)
                    {
                        double currentNumber1 = 0;
                        bool isNumber1 = double.TryParse(unfilteredArray[r, variableNameIndex], out currentNumber1);
                        if ((isNumber1 && (currentNumber1 < passedValueNumber)) || !isNumber1)
                        { count++; }
                    }
                    filteredArray = new string[count, listOfVariables.Length];
                    int newRowIndex2 = 0;
                    for (int r = 0; r < unfilteredArray.GetLength(0); r++)
                    {
                        double currentNumber2 = 0;
                        bool isNumber2 = double.TryParse(unfilteredArray[r, variableNameIndex], out currentNumber2);
                        if ((isNumber2 && (currentNumber2 < passedValueNumber)) || !isNumber2)
                        {
                            for (int k = 0; k < listOfVariables.Length; k++)
                            {
                                filteredArray[newRowIndex2, k] = unfilteredArray[r, k];
                            }
                            newRowIndex2++;
                        }
                    }
                    break;

                case 3: // var < value
                    for (int r = 0; r < unfilteredArray.GetLength(0); r++)
                    {
                        double currentNumber1 = 0;
                        bool isNumber1 = double.TryParse(unfilteredArray[r, variableNameIndex], out currentNumber1);
                        if ((isNumber1 && (currentNumber1 >= passedValueNumber)) || !isNumber1)
                        { count++; }
                    }
                    filteredArray = new string[count, listOfVariables.Length];
                    int newRowIndex3 = 0;
                    for (int r = 0; r < unfilteredArray.GetLength(0); r++)
                    {
                        double currentNumber2 = 0;
                        bool isNumber2 = double.TryParse(unfilteredArray[r, variableNameIndex], out currentNumber2);
                        if ((isNumber2 && (currentNumber2 >= passedValueNumber)) || !isNumber2)
                        {
                            for (int k = 0; k < listOfVariables.Length; k++)
                            {
                                filteredArray[newRowIndex3, k] = unfilteredArray[r, k];
                            }
                            newRowIndex3++;
                        }
                    }
                    break;

                case 4: // var <= value
                    for (int r = 0; r < unfilteredArray.GetLength(0); r++)
                    {
                        double currentNumber1 = 0;
                        bool isNumber1 = double.TryParse(unfilteredArray[r, variableNameIndex], out currentNumber1);
                        if ((isNumber1 && (currentNumber1 > passedValueNumber)) || !isNumber1)
                        { count++; }
                    }
                    filteredArray = new string[count, listOfVariables.Length];
                    int newRowIndex4 = 0;
                    for (int r = 0; r < unfilteredArray.GetLength(0); r++)
                    {
                        double currentNumber2 = 0;
                        bool isNumber2 = double.TryParse(unfilteredArray[r, variableNameIndex], out currentNumber2);
                        if ((isNumber2 && (currentNumber2 > passedValueNumber)) || !isNumber2)
                        {
                            for (int k = 0; k < listOfVariables.Length; k++)
                            {
                                filteredArray[newRowIndex4, k] = unfilteredArray[r, k];
                            }
                            newRowIndex4++;
                        }
                    }
                    break;

                case 5: // missing value
                    for (int r = 0; r < unfilteredArray.GetLength(0); r++)
                    {
                        double currentNumber1 = 0;
                        bool isNumber1 = double.TryParse(unfilteredArray[r, variableNameIndex], out currentNumber1);
                        if (!String.IsNullOrEmpty(unfilteredArray[r, variableNameIndex]) || (isNumber1 && (currentNumber1 == -999.25)))
                        { 
                            count++;
                        }
                    }
                    filteredArray = new string[count, listOfVariables.Length];
                    int newRowIndex5 = 0;
                    for (int r = 0; r < unfilteredArray.GetLength(0); r++)
                    {
                        double currentNumber2 = 0;
                        bool isNumber2 = double.TryParse(unfilteredArray[r, variableNameIndex], out currentNumber2);
                        if (!String.IsNullOrEmpty(unfilteredArray[r, variableNameIndex]) || (isNumber2 && (currentNumber2 == -999.25)))
                        {
                            for (int k = 0; k < listOfVariables.Length; k++)
                            {
                                filteredArray[newRowIndex5, k] = unfilteredArray[r, k];
                            }
                            newRowIndex5++;
                        }
                    }
                    break;
                case 6: // var = value
                    for (int r = 0; r < unfilteredArray.GetLength(0); r++)
                    {
                        string currentValue = unfilteredArray[r, variableNameIndex];
                        if (passedValueText.Equals(currentValue, StringComparison.InvariantCultureIgnoreCase))
                        {
                            count++;
                        }
                    }
                    filteredArray = new string[count, listOfVariables.Length];
                    int newRowIndex6 = 0;
                    for (int r = 0; r < unfilteredArray.GetLength(0); r++)
                    {
                        string currentValue = unfilteredArray[r, variableNameIndex];
                        if (passedValueText.Equals(currentValue, StringComparison.InvariantCultureIgnoreCase))
                        {
                            for (int k = 0; k < listOfVariables.Length; k++)
                            {
                                filteredArray[newRowIndex6, k] = unfilteredArray[r, k];
                            }
                            newRowIndex6++;
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }

            return filteredArray;
        }

        /// <summary>
        /// Method checks for empty fields before filtering is commenced.
        /// </summary>
        public void checkForEmptyFields()
        {
            if (variableNameIndex == 999 || filteringOperator == -1 || (passedValueNumber == -9999 && isAllowedToEnterNumber) || (String.IsNullOrEmpty(passedValueText) && isAllowToEnterText))
            {
                someFieldIsEmpty = true;
                MessageBox.Show("ERROR: One or more filter fields are empty!", "Missing your input!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Method lets to know outside of this class that filtering can't be done because
        /// some field is empty.
        /// </summary>
        /// <returns></returns>
        public bool isEmpty() { return someFieldIsEmpty; }
    }
}
