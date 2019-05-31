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
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using OxyPlot.WindowsForms;
using OnG_Rock_Typing.Graphs;

namespace OnG_Rock_Typing
{
    /// <summary>
    /// User control to handle filtering and modeling.
    /// </summary>
    public partial class ucFiltering : UserControl
    {
        // Member variables
        private int filterCounter;
        private ArrayList filterIds = new ArrayList();
        private string[,] filteredDataArray;
        private static ucFiltering _instance;
        private int plotSAcrollPosition;
        private const string FILE_TYPE_FILTER = "Rock Data Spreadsheet|*.csv";
        private const string FILE_TYPE_FILTER_STATS = "Rock Data Statistics(Before and After)|*.csv";
        private bool plotFlag = false;

        public static ucFiltering Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucFiltering();
                return _instance;
            }
        }
        public ucFiltering()
        {
            InitializeComponent();
            filterCounter = 0;
            populateComboBoxes();
            plotSAcrollPosition = 0;
            filteredDataArray = ucLoadFile.Instance.getCurrentDataArray();
        }

        /// <summary>
        /// Adding new filter on click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addFilterButton_Click(object sender, EventArgs e)
        {
            ucFilter newFilter = new ucFilter(filterCounter);
            newFilter.Name = filterCounter.ToString();
            flowLayoutFilters.Controls.Add(newFilter);
            filterIds.Add(filterCounter);
            filterCounter++;
        }

        /// <summary>
        /// Delete selected filter on click
        /// </summary>
        /// <param name="id"></param>
        public void deleteFilter(int id)
        {
            int currentLength = flowLayoutFilters.Controls.Find(id.ToString(), true).Count();
            ucFilter currentFilter = flowLayoutFilters.Controls.Find(id.ToString(), true).First() as ucFilter;
            if (currentFilter.getFilterId() == id && currentFilter != null)
            {
                flowLayoutFilters.Controls.Remove(currentFilter);
                currentFilter.Dispose();
                filterIds.Remove(id);
            }
        }

        /// <summary>
        /// Method puts initial array through selected filters and puts 
        /// filtered array into member variable.
        /// </summary>
        public void getFilteredArray()
        {
            string[,] transitionalArray1 = ucLoadFile.Instance.getCurrentDataArray();
            string[,] transitionalArray2;
            foreach (int filterId in filterIds)
            {
                ucFilter currentFilter = flowLayoutFilters.Controls.Find(filterId.ToString(), true).First() as ucFilter;
                transitionalArray2 = currentFilter.filterOUT(transitionalArray1);
                transitionalArray1 = transitionalArray2;
                if (currentFilter.isEmpty()) { return; }
            }
            filteredDataArray = transitionalArray1;
            displayFilteredOutPercentage();
        }

        /// <summary>
        /// Method displays percentage of filtered out data
        /// </summary>
        private void displayFilteredOutPercentage()
        {
            float filteredRows = filteredDataArray.GetLength(0);
            float unFilteredRows = ucLoadFile.Instance.getCurrentDataArray().GetLength(0);
            float filteredOutPercentage = 100 - (filteredRows / unFilteredRows) * 100;
            labelFilteredOutValue.Text = Math.Round(filteredOutPercentage, 2).ToString() + "%";
            labelFilteredOutValue.Refresh();
        }

        /// <summary>
        /// Handles click of FILTER button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFilter_Click(object sender, EventArgs e)
        {
            getFilteredArray();
        }

        /// <summary>
        /// Method clears flowLayoutPlot panel, checks for erroes
        /// and inserts a new set of plots.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPlot_Click(object sender, EventArgs e)
        {
            string[,] unFilteredArray = ucLoadFile.Instance.getCurrentDataArray();
            clearPlotFlowLayout();

            // Error handling
            if (plotErrorCheck() || unFilteredArray == null || filteredDataArray == null)
            {
                MessageBox.Show("ERROR: Both axises must be selected.", "Missing your input!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // reading selected axises
            int xColumn = cbSelectXAxis.SelectedIndex;
            int yColumn = cbSelectYAxis.SelectedIndex;
            int regressionIndex = cbRegression.SelectedIndex;
            int colorColumn;
            if (cbColorGrouping.SelectedIndex == 0 || cbColorGrouping.SelectedIndex == -1)
            { colorColumn = -1; }
            else { colorColumn = cbColorGrouping.SelectedIndex - 1; }
            
            //int
            // scattered plots
            PlotView plotBefore = new ScatterPlot().getScatteredPlot(unFilteredArray, "Before", xColumn, yColumn, colorColumn, regressionIndex, checkBoxLogX.Checked, checkBoxLogY.Checked);
            PlotView plotAfter = new ScatterPlot().getScatteredPlot(filteredDataArray, "After", xColumn, yColumn, colorColumn, regressionIndex, checkBoxLogX.Checked, checkBoxLogY.Checked);
            plotBefore.Name = "plotBefore";
            plotAfter.Name = "plotAfter";
            plotBefore.Size = new Size(900,350);
            plotAfter.Size = new Size(900,350);
            flowLayoutPlots.Controls.Add(plotBefore);
            flowLayoutPlots.Controls.Add(plotAfter);

            // histograms
            int numberOfGroups = cbHistogramGroups.SelectedIndex;
            if (numberOfGroups != -1 && numberOfGroups != 0)
            {
                string[] dataColumnXBefore = ucLoadFile.Instance.getDataColumn(xColumn, unFilteredArray);
                string[] dataColumnYBefore = ucLoadFile.Instance.getDataColumn(yColumn, unFilteredArray);
                string[] dataColumnXAfter = ucLoadFile.Instance.getDataColumn(xColumn, filteredDataArray);
                string[] dataColumnYAfter = ucLoadFile.Instance.getDataColumn(yColumn, filteredDataArray);
                string xName = ucLoadFile.Instance.getCurrentColumnNames()[xColumn];
                string yName = ucLoadFile.Instance.getCurrentColumnNames()[yColumn];
                PlotView histXBefore = new Histogram().getHistogram(dataColumnXBefore, numberOfGroups, xName, "Before");
                PlotView histXAfter = new Histogram().getHistogram(dataColumnXAfter, numberOfGroups, xName, "After");
                PlotView histYBefore = new Histogram().getHistogram(dataColumnYBefore, numberOfGroups, yName, "Before");
                PlotView histYAfter = new Histogram().getHistogram(dataColumnYAfter, numberOfGroups, yName, "After");
                histXBefore.Name = "histXBefore";
                histXAfter.Name = "histXAfter";
                histYBefore.Name = "histYBefore";
                histYAfter.Name = "histYAfter";
                histXBefore.Size = new Size(800, 300);
                histXAfter.Size = new Size(800, 300);
                histYBefore.Size = new Size(800, 300);
                histYAfter.Size = new Size(800, 300);
                flowLayoutPlots.Controls.Add(histXBefore);
                flowLayoutPlots.Controls.Add(histXAfter);
                flowLayoutPlots.Controls.Add(histYBefore);
                flowLayoutPlots.Controls.Add(histYAfter);
                // Statistics
                flowLayoutPlots.Controls.Add(new ucStatistics(xColumn, unFilteredArray, "Before"));
                flowLayoutPlots.Controls.Add(new ucStatistics(xColumn, filteredDataArray, "After"));
                flowLayoutPlots.Controls.Add(new ucStatistics(yColumn, unFilteredArray, "Before"));
                flowLayoutPlots.Controls.Add(new ucStatistics(yColumn, filteredDataArray, "After"));
            }
                // flagging existance of plots to save
                plotFlag = true;
        }

        /// <summary>
        /// Method populates axis selection boxes that are used to
        /// build plots.
        /// </summary>
        public void populateComboBoxes()
        {
            cbSelectXAxis.Items.Clear();
            cbSelectYAxis.Items.Clear();
            cbColorGrouping.Items.Clear();
            cbHistogramGroups.Items.Clear();

            string[] listOfVariables = ucLoadFile.Instance.getCurrentColumnNames();
            // populating axises and coloring boxes           
            cbSelectXAxis.Text = "Select x axis";
            cbSelectYAxis.Text = "Select y axis";
            cbColorGrouping.Items.Add("");
            for (int i = 0; i < listOfVariables.Length; i++)
            {
                cbSelectXAxis.Items.Add(listOfVariables[i]);
                cbSelectYAxis.Items.Add(listOfVariables[i]);
                cbColorGrouping.Items.Add(listOfVariables[i]);
            }
            // populating histogram groups box
            cbHistogramGroups.Items.Add("");
            for (int i = 0; i < 50; i++)
            {
                cbHistogramGroups.Items.Add(i + 1);
            }
            // populating regression box
            cbRegression.Items.Add("");
            cbRegression.Items.Add("Power");
            cbRegression.Items.Add("Linear");
        }

        /// <summary>
        /// Error handling before plots are built
        /// </summary>
        /// <returns></returns>
        private bool plotErrorCheck()
        {
            bool errorFlag = false;

            if(cbSelectXAxis.SelectedIndex == -1  || cbSelectYAxis.SelectedIndex == -1)
            {
                errorFlag = true;
            }
            return errorFlag;
        }

        /// <summary>
        /// Clearing flowLayoutPlots befor reinserting new graphs
        /// </summary>
        public void clearPlotFlowLayout()
        {
            while (flowLayoutPlots.Controls.Count > 0) flowLayoutPlots.Controls.RemoveAt(0);
        }

        // Beginning: scroll controll in flowLayoutPlots
        private void flowLayoutPlots_MouseHover(object sender, EventArgs e)
        {
            flowLayoutPlots.AutoScroll = true;
        }
        private void flowLayoutPlots_MouseLeave(object sender, EventArgs e)
        {
            plotSAcrollPosition = flowLayoutPlots.VerticalScroll.Value;
            flowLayoutPlots.AutoScroll = false;
            flowLayoutPlots.VerticalScroll.Value = plotSAcrollPosition;
        }
        // End: scroll controll in flowLayoutPlots

        /// <summary>
        /// Handling of saving of filtered data CSV file.
        /// </summary>
        public void saveCSVFile()
        {
            string filepath;
            saveCSVDialog.Filter = FILE_TYPE_FILTER;
            if (saveCSVDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filepath = saveCSVDialog.FileName;
            }
            else { return; }
            ReadWriteCSV writeCSV = new ReadWriteCSV();
            writeCSV.writeCSVtoFile(filepath);
        }

        /// <summary>
        /// Makes filtered array accesible outside of this class.
        /// </summary>
        /// <returns></returns>
        public string[,] getFilteredData()
        {
            getFilteredArray();
            return filteredDataArray;
        }

        /// <summary>
        /// Handling of saving of statistics CSV file.
        /// </summary>
        public void saveCSVStatistics()
        {
            string filepath;
            saveCSVDialog.Filter = FILE_TYPE_FILTER_STATS;
            if (saveCSVDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filepath = saveCSVDialog.FileName;
            }
            else { return; }
            ReadWriteCSV writeCSV = new ReadWriteCSV();
            writeCSV.writeCSVStatisticstoFile(filepath);
        }

        /// <summary>
        /// Handling of saving of plots into PNG file.
        /// </summary>
        public void saveGraphs()
        {
            // Check for existanse of plots
            if (!plotFlag)
            {
                MessageBox.Show("In order to save graphs you have to generate them first!", "Can't save nothing!",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Dialog that gets path to a folder where plots to be saved to
            string folderpath;
            folderBrowserDialog.Description = "Select/create folder to save your plots";
            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                folderpath = folderBrowserDialog.SelectedPath;
            }
            else { return; }
            // Getting scatter plots from flow layout panel
            PlotView plot1 = flowLayoutPlots.Controls.Find("plotBefore", true).First() as PlotView;
            PlotView plot2 = flowLayoutPlots.Controls.Find("plotAfter", true).First() as PlotView;
            int width = 1000;
            int height = 800;

            string filepath1 = folderpath + "\\" + plot1.Name.ToString() + ".png";
            var pngExporter1 = new PngExporter { Width = width, Height = height, Background = OxyColors.White };
            string filepath2 = folderpath + "\\" + plot2.Name.ToString() + ".png";
            var pngExporter2 = new PngExporter { Width = width, Height = height, Background = OxyColors.White };
            // Writing scatter plots to file
            try {
                pngExporter1.ExportToFile(plot1.Model, filepath1);
                pngExporter2.ExportToFile(plot2.Model, filepath2);
            }
            catch (Exception e) { plotSaveErrorMsg(); return; }
            // Getting histograms from flow layout panel if exist
            if (flowLayoutPlots.Controls.ContainsKey("histXBefore"))
            {
                PlotView plot3 = flowLayoutPlots.Controls.Find("histXBefore", true).First() as PlotView;
                PlotView plot4 = flowLayoutPlots.Controls.Find("histXAfter", true).First() as PlotView;
                PlotView plot5 = flowLayoutPlots.Controls.Find("histYBefore", true).First() as PlotView;
                PlotView plot6 = flowLayoutPlots.Controls.Find("histYAfter", true).First() as PlotView;

                string filepath3 = folderpath + "\\" + plot3.Name.ToString() + ".png";
                var pngExporter3 = new PngExporter { Width = width, Height = height, Background = OxyColors.White };
                string filepath4 = folderpath + "\\" + plot4.Name.ToString() + ".png";
                var pngExporter4 = new PngExporter { Width = width, Height = height, Background = OxyColors.White };
                string filepath5 = folderpath + "\\" + plot5.Name.ToString() + ".png";
                var pngExporter5 = new PngExporter { Width = width, Height = height, Background = OxyColors.White };
                string filepath6 = folderpath + "\\" + plot6.Name.ToString() + ".png";
                var pngExporter6 = new PngExporter { Width = width, Height = height, Background = OxyColors.White };
                // Writing histograms to file
                try {
                    pngExporter3.ExportToFile(plot3.Model, filepath3);
                    pngExporter4.ExportToFile(plot4.Model, filepath4);
                    pngExporter5.ExportToFile(plot5.Model, filepath5);
                    pngExporter6.ExportToFile(plot6.Model, filepath6);
                }
                catch (Exception e) { plotSaveErrorMsg(); return; }
            }
        }

        /// <summary>
        /// Error message when there're issues with saving plots
        /// </summary>
        public void plotSaveErrorMsg()
        {
            MessageBox.Show("ERROR: Something went wrong with your folder, please repeat process carefully.", "Create your folder properly!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
