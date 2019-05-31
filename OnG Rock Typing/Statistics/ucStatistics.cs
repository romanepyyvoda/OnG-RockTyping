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
    /// User control to display statistics after building histograms
    /// </summary>
    public partial class ucStatistics : UserControl
    {
        public ucStatistics(int columnIndex, string[,] dataArray, string title)
        {
            InitializeComponent();
            string[] dataColumn = ucLoadFile.Instance.getDataColumn(columnIndex, dataArray);
            string variableName = ucLoadFile.Instance.getCurrentColumnNames()[columnIndex];
            Statistics currentColumnStatistics = new Statistics(variableName, dataColumn);

            labelVariableName.Text = currentColumnStatistics.getVariableName();
            labelTitle.Text = title;
            labelMinValue.Text = currentColumnStatistics.getMin().ToString();
            labelMaxValue.Text = currentColumnStatistics.getMax().ToString();
            labelMeanValue.Text = currentColumnStatistics.getMean().ToString();
            labelHMeanValue.Text = currentColumnStatistics.getHmean().ToString();
            labelGMeanValue.Text = currentColumnStatistics.getGmean().ToString();
            labelMeadianValue.Text = currentColumnStatistics.getMedian().ToString();
            labelMissingValue.Text = currentColumnStatistics.getMissing().ToString();
            labelP10Value.Text = currentColumnStatistics.getP10().ToString();
            labelP50Value.Text = currentColumnStatistics.getP50().ToString();
            labelP90Value.Text = currentColumnStatistics.getP90().ToString();
            labelTotalSamplesValue.Text = currentColumnStatistics.getTotalSamples().ToString();
        }

    }
}
