using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnG_Rock_Typing.Graphs
{
    /// <summary>
    /// Building histogram plot view (OxyPlot)
    /// </summary>
    class Histogram
    {

        public PlotView getHistogram(string[] dataColumn, int numberOfGroups, string variableTitle, string plotTitle)
        {

            var model = new PlotModel { Title = plotTitle };
            double[] dataColumnDouble = parseDataArrayToDouble(dataColumn);
            Array.Sort(dataColumnDouble);
            // Determining step size according to selected number of groups
            double step = (dataColumnDouble.Max() - dataColumnDouble.Min()) / numberOfGroups;

            // Counting quantity of data points in each group
            List<ColumnItem> itemsSource = new List<ColumnItem>();
            double currentStep = step;
            int starIndex = 0;
            for (int i = 0; i < numberOfGroups; i++)
            {
                int count = 0;
                for (int j = starIndex; j < dataColumnDouble.Length; j++)
                {
                    if (dataColumnDouble[j] > currentStep + dataColumnDouble.Min())
                    {
                        break;
                    }
                    count++;
                }
                starIndex += count;
                currentStep += step;
                itemsSource.Add(new ColumnItem { Value = count });
            }
            // Label placement and formatting
            var columnSeries = new ColumnSeries();
            columnSeries.ItemsSource = itemsSource;
            columnSeries.LabelPlacement = LabelPlacement.Outside;
            columnSeries.LabelFormatString = "Qty {0:.}";
            model.Series.Add(columnSeries);
            
            // Populating category items with range margins for each separate group
            List<string> categoryItems = new List<string>();
            double from = 0;
            double to = step;
            for (int i = 0; i < numberOfGroups; i++)
            {
                categoryItems.Add(from.ToString()+"-"+ to.ToString());
                from += step;
                to += step;
            }
            // Axises settings
            model.Axes.Add(new CategoryAxis
            {
                Position = AxisPosition.Bottom,
                Key = variableTitle,
                ItemsSource = categoryItems,
                IsZoomEnabled = true,
                Title = "Groups  |  " + variableTitle
            });
            model.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                MinimumPadding = 0,
                AbsoluteMinimum = 0,
                Title = "Quantity"
            });

            PlotView plotView = new PlotView();
            // Adding assembled model into plot view
            plotView.Model = model;

            return plotView;
        }

        /// <summary>
        /// Supplementary method that parses string array to double array.
        /// </summary>
        /// <param name="dataArray"></param>
        /// <returns></returns>
        public double[] parseDataArrayToDouble(string[] dataArray)
        {
            int newArrayLegth = dataArray.Length - Missing(dataArray);
            double[] doubleArray = new double[newArrayLegth];
            int j = 0;
            for (int i = 0; i < dataArray.Length; i++)
            {
                if (!String.IsNullOrEmpty(dataArray[i]))
                {
                    double currentNumber = 0;
                    bool isNumber = double.TryParse(dataArray[i], out currentNumber);
                    if (isNumber)
                    {
                        doubleArray[j] = currentNumber;
                        j++;
                    }
                    else
                    {
                        for (int k = 0; k < newArrayLegth; k++)
                        {
                            doubleArray[k] = 0;
                        }
                        return doubleArray;
                    }
                }
            }
            return doubleArray;
        }

        /// <summary>
        /// Supplementary method that removed missing data from array for consistency of calculations.
        /// </summary>
        /// <param name="dataArray"></param>
        /// <returns></returns>
        public int Missing(string[] dataArray)
        {
            int counter = 0;
            for (int i = 0; i < dataArray.Length; i++)
            {
                if (String.IsNullOrEmpty(dataArray[i]))
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
