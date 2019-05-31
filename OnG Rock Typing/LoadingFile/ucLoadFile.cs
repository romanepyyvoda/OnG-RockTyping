using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using OnG_Rock_Typing.Graphs;
using OxyPlot.WindowsForms;

namespace OnG_Rock_Typing
{
    /// <summary>
    /// User control to handle loading of the file, displaying loaded table and column selection.
    /// </summary>
    public partial class ucLoadFile : UserControl
    {
        //Member variables
        private ReadWriteCSV readCSV;
        private DataTable dt;
        private static ucLoadFile _instance;
        private const string FILE_TYPE_FILTER = "Rock Data Spreadsheet|*.csv";
        private string[] currentheaders;
        private string[,] currentDataArray;
        string variableName;
        string[] dataColumn;

        //Constructor
        public static ucLoadFile Instance {
            get {
                if (_instance == null)
                    _instance = new ucLoadFile();
                    return _instance; 
            }
        } 

        public ucLoadFile()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This method invokes open file dialog and updates DataGridView with
        /// table from selected CSV file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadData_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = FILE_TYPE_FILTER;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textFilePath.Text = openFileDialog1.FileName;
            }
            else { return; }
            
            dgvRockDataTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvRockDataTable.AutoResizeColumns();

            readCSV = new ReadWriteCSV();
            dt = readCSV.BindDataCSV(textFilePath.Text);
            if (dt == null) { return; }
            dgvRockDataTable.DataSource = readCSV.BindDataCSV(textFilePath.Text);
            //Assigning current array of data to global variable to be accessed for statistics calculation
            currentheaders = readCSV.getAllColumnNames();
            currentDataArray = readCSV.getOriginalDataArray();
            populateStatisticsVariableList(currentheaders);
        }

        /// <summary>
        /// This method invokes column selection dialog and updates newly selected columns
        /// into DataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectColumns_Click(object sender, EventArgs e)
        {
            if (readCSV == null)
            {
                return;
            }
            SelectColumnsDialog scDialog = new SelectColumnsDialog();
            string[] columnNames = readCSV.getAllColumnNames();
            scDialog.setCheckBoxList(columnNames);
            
            scDialog.ShowDialog();
            if (scDialog.getSelectedColumns().Count == 0)
            {
                return;
            }
            else
            {
                dgvRockDataTable.DataSource = getNewDataTable(scDialog.getSelectedColumns());
                dgvRockDataTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                populateStatisticsVariableList(currentheaders);
                if (ucFiltering.Instance != null) { ucFiltering.Instance.populateComboBoxes(); }
            }
            scDialog.Dispose();
        }

        /// <summary>
        /// This method generates new DataTable out of list of selected columns
        /// and original data (saved in instance of ReadWriteCSV class) by
        /// copying columns from original data set that match list of selected header names
        /// into new array.
        /// </summary>
        /// <param name="columnHeaders"></param>
        /// <returns></returns>
        private DataTable getNewDataTable(ArrayList columnHeaders)
        {
            string[,] originalDataArray = readCSV.getOriginalDataArray();
            string[] originalheaders = readCSV.getAllColumnNames();
            
            int newColumnCount = columnHeaders.Count;
            int newRowCount = originalDataArray.GetLength(0);
            string[,] newDataArray = new string [newRowCount, newColumnCount];
            // This portion tranfers selected columns into new smaller string array.
            // Here code iterates over each new column and when selected header name mathches original data - 
            // all rows get tranferred into new array.
            for (int i = 0; i < newColumnCount; i++)
            {                                
                for (int j = 0; j < originalheaders.Length; j++)
                {
                    if (columnHeaders[i].Equals(originalheaders[j]))
                    {
                        for (int k = 0; k < newRowCount; k++)
                        {
                            newDataArray[k, i] = originalDataArray[k,j];
                        }
                    }
                }
            }
            
            // this portion packs new string array into DataTable
            DataTable newdatatable = new DataTable();
            if (newDataArray.Length > 0)
            {
                //first line to create header
                foreach (string headerWord in columnHeaders)
                {
                    newdatatable.Columns.Add(new DataColumn(headerWord));
                }
                //for data
                for (int r = 0; r < newRowCount; r++)
                {
                    //splitting 2D array into series of arrays that contain only one array each
                    string[] dataWords = new string[newColumnCount];
                    for (int k = 0; k < newColumnCount; k++)
                    {
                        dataWords[k] = newDataArray[r,k];
                    }
                    //inserting array into DataRow
                    DataRow dr = newdatatable.NewRow();
                    int columnIndex = 0;
                    foreach (string headerWord in columnHeaders)
                    {
                        dr[headerWord] = dataWords[columnIndex++];
                    }
                    newdatatable.Rows.Add(dr);
                }
            }
            //Assigning current array of data to global variable to be accessed for statistics calculation
            currentheaders = new string[newColumnCount];
            int z = 0;
            foreach (string headerWord in columnHeaders)
            {
                currentheaders[z] = headerWord;
                z++;
            }
            currentDataArray = newDataArray;

            return newdatatable;
        }

        /// <summary>
        /// Method returns variable that stores array of current header names.
        /// </summary>
        /// <returns></returns>
        public string[] getCurrentColumnNames()
        {
            return currentheaders;
        }

        /// <summary>
        /// Method returns variable that stores array of current data array (unfiltered).
        /// </summary>
        /// <returns></returns>
        public string[,] getCurrentDataArray()
        {
            return currentDataArray;
        }

        /// <summary>
        /// Method displays statistics when variable is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbSelectVariable_SelectedIndexChanged(object sender, EventArgs e)
        {
            variableName = cbSelectVariable.SelectedItem.ToString();
            int variableIndex = cbSelectVariable.SelectedIndex;
            dataColumn = getDataColumn(variableIndex, currentDataArray);
            Statistics currentColumnStatistics = new Statistics(variableName, dataColumn);
            
            labelMinValue.Text = currentColumnStatistics.getMin().ToString();
            labelMaxValue.Text = currentColumnStatistics.getMax().ToString();
            labelMeanValue.Text = currentColumnStatistics.getMean().ToString();
            labelHMeanValue.Text = currentColumnStatistics.getHmean().ToString();
            labelGMeanValue.Text = currentColumnStatistics.getGmean().ToString();
            labelMedianValue.Text = currentColumnStatistics.getMedian().ToString();
            labelMissingValue.Text = currentColumnStatistics.getMissing().ToString();
            labelP10Value.Text = currentColumnStatistics.getP10().ToString();
            labelP50Value.Text = currentColumnStatistics.getP50().ToString();
            labelP90Value.Text = currentColumnStatistics.getP90().ToString();
            labelTotalSamplesValue.Text = currentColumnStatistics.getTotalSamples().ToString();
                       
            populateSelectNOfGroupsBox();
        }

        /// <summary>
        /// Supplementary method that puts selected column of 2D array
        /// into 1D array.
        /// </summary>
        /// <param name="columnIndex"></param>
        /// <param name="dataArray"></param>
        /// <returns></returns>
        public string[] getDataColumn(int columnIndex, string[,] dataArray)
        {
            string[] dataColumn = new string[dataArray.GetLength(0)];
            for (int i = 0; i < dataArray.GetLength(0); i++)
            {
                dataColumn[i] = dataArray[i, columnIndex];
            }
            return dataColumn;
        }

        /// <summary>
        /// Populates statistics dropdown list with selected variables (column names).
        /// </summary>
        /// <param name="listOfVariables"></param>
        public void populateStatisticsVariableList(string[] listOfVariables)
        {
            cbSelectVariable.Items.Clear();
            for (int i = 0; i < listOfVariables.Length; i++)
            {
                cbSelectVariable.Items.Add(listOfVariables[i]);
            }
        }

        /// <summary>
        /// Message to be displayed when IO is detected
        /// </summary>
        public void showIOErrorDialog()
        {
            MessageBox.Show("File you're trying to save to is being used by other application!", "Can't save!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Method populates histogram number of groups selection box.
        /// </summary>
        public void populateSelectNOfGroupsBox()
        {
            cbNumberOfGroups.Items.Clear();
            for (int i = 0; i < 50; i++)
            {
                cbNumberOfGroups.Items.Add(i+1);
            }
        }

        /// <summary>
        /// When number of groups is selected method builds a histogram.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbNumberOfGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearPlotFlowLayout();
            int numberOfGroups = cbNumberOfGroups.SelectedIndex + 1;
            Histogram histogram = new Histogram();
            PlotView plot = histogram.getHistogram(dataColumn, numberOfGroups, variableName, "");
            plot.Size = new Size(275, 320);
            flowLayoutHistogram.Controls.Add(plot);
        }

        /// <summary>
        /// Method clears flow layout panel from all contents.
        /// </summary>
        public void clearPlotFlowLayout()
        {
            while (flowLayoutHistogram.Controls.Count > 0) flowLayoutHistogram.Controls.RemoveAt(0);
        }
    }
}
