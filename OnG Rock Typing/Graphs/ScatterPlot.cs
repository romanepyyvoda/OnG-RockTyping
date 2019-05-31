using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnG_Rock_Typing.Graphs
{
/// <summary>
/// Building scatter plot view (OxyPlot)
/// </summary>
    class ScatterPlot
    {
        double a = 0;
        double b = 0;
        double r = 0;
        public PlotView getScatteredPlot(string[,] dataArray, string title, int xColumn, int yColumn, int colorColumn, int regressionIndex,bool logX, bool logY)
        {
            string xTitle = ucLoadFile.Instance.getCurrentColumnNames()[xColumn];
            string yTitle = ucLoadFile.Instance.getCurrentColumnNames()[yColumn];
            string colorTitle = "No grouping selected";
            if (colorColumn != -1) { colorTitle = ucLoadFile.Instance.getCurrentColumnNames()[colorColumn]; }
            // Getting unique group names when color grouping required and groups are strings
            ArrayList groupNames = getGroupNames(dataArray,colorColumn);

            //Populating scatter plot with data from selected columns
            var model = new PlotModel { Title = title };
            var scatterSeries = new ScatterSeries { MarkerType = MarkerType.Circle };
            for (int r = 0; r < dataArray.GetLength(0); r++)
            {   // x axis
                double xDouble = 0;
                bool isNumberX = double.TryParse(dataArray[r, xColumn], out xDouble);
                var x = xDouble;
                // y axis
                double yDouble = 0;
                bool isNumberY = double.TryParse(dataArray[r, yColumn], out yDouble);
                var y = yDouble;
                // color grouping
                double colorValue = 0;
                bool isNumberColor = true;
                if (colorColumn != -1)
                {
                    double colorDouble = 0;
                    isNumberColor = double.TryParse(dataArray[r, colorColumn], out colorDouble);
                    colorValue = colorDouble;
                }
                var size = 3;
                if (!isNumberColor && !String.IsNullOrEmpty(dataArray[r, colorColumn]))
                { scatterSeries.Points.Add(new ScatterPoint(x, y, size, groupNames.IndexOf(dataArray[r, colorColumn]))); }
                else { scatterSeries.Points.Add(new ScatterPoint(x, y, size, colorValue)); }
            }
            // Handling of selection of axis scaling
            if (logX && !logY)
            {
                var logAxisX = new LogarithmicAxis() { Position = AxisPosition.Bottom, Title = xTitle + ", Log(x)", UseSuperExponentialFormat = false, Base = 10, MajorGridlineStyle = LineStyle.Dot, MajorGridlineColor = OxyColors.Gray };
                var linearAxisY = new LinearAxis() { Position = AxisPosition.Left, Title = yTitle, UseSuperExponentialFormat = false, MajorGridlineStyle = LineStyle.Dot, MajorGridlineColor = OxyColors.Gray };
                model.Axes.Add(logAxisX);
                model.Axes.Add(linearAxisY);
            }
            else if (!logX  && logY)
            {
                var linearAxisX = new LinearAxis() { Position = AxisPosition.Bottom, Title = xTitle, UseSuperExponentialFormat = false, MajorGridlineStyle = LineStyle.Dot, MajorGridlineColor = OxyColors.Gray };
                var logAxisY = new LogarithmicAxis() { Position = AxisPosition.Left, Title = yTitle + ", Log(y)", UseSuperExponentialFormat = false, Base = 10, MajorGridlineStyle = LineStyle.Dot, MajorGridlineColor = OxyColors.Gray };
                model.Axes.Add(linearAxisX);
                model.Axes.Add(logAxisY);
            }
            else if (logX && logY)
            {
                var logAxisX = new LogarithmicAxis() { Position = AxisPosition.Bottom, Title = xTitle + ", Log(x)", UseSuperExponentialFormat = false, Base = 10, MajorGridlineStyle = LineStyle.Dot, MajorGridlineColor = OxyColors.Gray };
                var logAxisY = new LogarithmicAxis() { Position = AxisPosition.Left, Title = yTitle + ", Log(y)", UseSuperExponentialFormat = false, Base = 10, MajorGridlineStyle = LineStyle.Dot, MajorGridlineColor = OxyColors.Gray };
                model.Axes.Add(logAxisY);
                model.Axes.Add(logAxisX);
            }
            else
            {
                var linearAxisX = new LinearAxis() { Position = AxisPosition.Bottom, Title = xTitle, UseSuperExponentialFormat = false , MajorGridlineStyle = LineStyle.Dot, MajorGridlineColor = OxyColors.Gray };
                var linearAxisY = new LinearAxis() { Position = AxisPosition.Left, Title = yTitle, UseSuperExponentialFormat = false, MajorGridlineStyle = LineStyle.Dot, MajorGridlineColor = OxyColors.Gray };
                model.Axes.Add(linearAxisX);
                model.Axes.Add(linearAxisY);
            }

            model.Series.Clear();
            model.Annotations.Clear();
            model.Series.Add(scatterSeries);
            // Adding regression graph when selected
            if (regressionIndex == 1)
            {
                double[] xClmn = parseDataArrayToDouble(ucLoadFile.Instance.getDataColumn(xColumn, dataArray));
                Func<double, double> pwr = getPowerRegression(dataArray, xColumn, yColumn);
                string label = "pwr rgssn y=" + Math.Round(a, 3).ToString() + "*" + "x pwr" + Math.Round(b, 3).ToString() + ", r=" + Math.Round(r, 2).ToString();
                FunctionSeries fsPwrRegression = new FunctionSeries(pwr, xClmn.Min()-0.1, xClmn.Max(), 0.01, label);
                fsPwrRegression.Color = OxyColors.DeepSkyBlue;
                model.Series.Add(fsPwrRegression);
            }
            if (regressionIndex == 2)
            {
                double[] xClmn = parseDataArrayToDouble(ucLoadFile.Instance.getDataColumn(xColumn, dataArray));
                Func<double, double> lnr = getLinearRegression(dataArray, xColumn, yColumn);
                string bstring = Math.Round(b, 3).ToString();
                if (b <= 0.0009) { bstring = Math.Round(b * 1000000, 3).ToString() + "m"; }
                string label = "lnr rgssn y=" + Math.Round(a, 3).ToString() + "+" + bstring + "*x, r=" + Math.Round(r, 2).ToString();
                FunctionSeries fsLinearRegression = new FunctionSeries(lnr, xClmn.Min() - 0.1, xClmn.Max(), 0.01, label);
                fsLinearRegression.Color = OxyColors.DeepSkyBlue;
                model.Series.Add(fsLinearRegression);
            }
            // Adding special axis for color coding
            model.Axes.Add(new LinearColorAxis
            {
                Position = AxisPosition.Top,
                Palette = OxyPalettes.Rainbow(200),
                Title = colorTitle,
                TitlePosition = 0.2,
                
            });

            PlotView plotView = new PlotView();
            // Adding assembled model into plot view
            plotView.Model = model;

            return plotView;
        }

        /// <summary>
        /// Method assemles array list of unique group names for color grouping
        /// when group names are strings.
        /// </summary>
        /// <param name="dataArray"></param>
        /// <param name="columnToParse"></param>
        /// <returns></returns>
        private ArrayList getGroupNames(string[,] dataArray, int columnToParse)
        {
            if (columnToParse == -1) { return null; }
            ArrayList groupNames = new ArrayList();
            
            for (int r = 0; r < dataArray.GetLength(0); r++)
            {
                if (groupNames.Contains(dataArray[r, columnToParse]) == false)
                {
                    groupNames.Add(dataArray[r, columnToParse]);
                }
            }
            return groupNames;
        }

        /// <summary>
        /// Assembling function that will be used to build power regressoin model.
        /// Calculates all needed coeficients.
        /// </summary>
        /// <param name="dataArray"></param>
        /// <param name="xAxis"></param>
        /// <param name="yAxis"></param>
        /// <returns></returns>
        private Func<double, double> getPowerRegression(string[,] dataArray, int xAxis, int yAxis)
        {
            //double[,] dataArray = 
            //Math.Log(argX)
            double sumax = 0;
            double sumay = 0;
            for (int r = 0; r < dataArray.GetLength(0); r++)
            {
                // x axis
                double xDouble = 0;
                bool isNumberX = double.TryParse(dataArray[r, xAxis], out xDouble);
                // y axis
                double yDouble = 0;
                bool isNumberY = double.TryParse(dataArray[r, yAxis], out yDouble);

                //double tempx = sumax + Math.Log(xDouble);
                //double tempy = sumax + Math.Log(yDouble);
                sumax = sumax + Math.Log(xDouble);
                //sumax = tempx;
                //sumay = tempy;
                sumay = sumay + Math.Log(yDouble);
                ///Console.WriteLine("xDouble = " + Math.Log(xDouble) + "; yDouble = " + Math.Log(yDouble));
                Console.WriteLine(r+". sumax: "+sumax);
                Console.WriteLine(r + ". sumay: " + sumay);
            }
            Console.WriteLine(dataArray.GetLength(0));
            double length = dataArray.GetLength(0);
            double ax = sumax / length;
            double ay = sumay / dataArray.GetLength(0);

            double sumsx = 0;
            double sumsy = 0;
            double sumyy = 0;
            for (int r = 0; r < dataArray.GetLength(0); r++)
            {
                // x axis
                double xDouble = 0;
                bool isNumberX = double.TryParse(dataArray[r, xAxis], out xDouble);
                // y axis
                double yDouble = 0;
                bool isNumberY = double.TryParse(dataArray[r, yAxis], out yDouble);

                sumsx += Math.Log(xDouble) * Math.Log(xDouble); 
                sumyy += Math.Log(yDouble) * Math.Log(yDouble);
                sumsy += Math.Log(xDouble) * Math.Log(yDouble);
                //Console.WriteLine("xDouble = "+ Math.Log(xDouble)+"; yDouble = "+ Math.Log(yDouble));
            }
            double sxx = sumsx / dataArray.GetLength(0) - ax * ax;
            double syy = sumyy / dataArray.GetLength(0) - ay * ay;
            double sxy = sumsy / dataArray.GetLength(0) - ax * ay;

            b = sxy / sxx;
            a = Math.Exp(ay - b * ax);
            r = sxy / (Math.Sqrt(sxx) * Math.Sqrt(syy));

            Func<double, double> pwrRegression = (x) => a * Math.Pow(x, b);

            return pwrRegression;
        }

        //private Func<double, double> getPowerRegression(string[,] dataArray, int xAxis, int yAxis)

        //{

        //    //Math.Log(argX)

        //    double sumax = 0;

        //    double sumay = 0;

        //    for (int r = 0; r<dataArray.GetLength(0); r++)

        //    {

        //        // x axis

        //        double xDouble = 0;

        //        bool isNumberX = double.TryParse(dataArray[r, xAxis], out xDouble);

        //        // y axis

        //        double yDouble = 0;

        //        bool isNumberY = double.TryParse(dataArray[r, yAxis], out yDouble);



        //        sumax += Math.Log(xDouble);

        //        sumay += Math.Log(yDouble);

        //    }

        //    double ax = sumax / dataArray.GetLength(0);

        //    double ay = sumay / dataArray.GetLength(0);



        //    double sumsx = 0;

        //    double sumsy = 0;

        //    for (int r = 0; r<dataArray.GetLength(0); r++)

        //    {

        //        // x axis

        //        double xDouble = 0;

        //        bool isNumberX = double.TryParse(dataArray[r, xAxis], out xDouble);

        //        // y axis

        //        double yDouble = 0;

        //        bool isNumberY = double.TryParse(dataArray[r, yAxis], out yDouble);



        //        sumsx += Math.Pow((Math.Log(xDouble) - ax), 2);

        //        sumsy += (Math.Log(xDouble) * Math.Log(yDouble));

        //    }

        //    double sxx = sumsx / dataArray.GetLength(0);

        //    double sxy = sumsy / dataArray.GetLength(0) - ax * ay;



        //    double b = sxy / sxx;

        //    double a = Math.Exp(ay - b * ax);



        //    Func<double, double> pwrRegression = (x) => a * Math.Pow(x, b);



        //    return pwrRegression;

        //}

        /// <summary>
        /// Assembling function that will be used to build linear regressoin model.
        /// Calculates all needed coeficients.
        /// </summary>
        /// <param name="dataArray"></param>
        /// <param name="xAxis"></param>
        /// <param name="yAxis"></param>
        /// <returns></returns>
        private Func<double, double> getLinearRegression(string[,] dataArray, int xAxis, int yAxis)
        {
            double sumx = 0;
            double sumy = 0;
            double sumxy = 0;
            double sumxsq = 0;
            double sumysq = 0;
            for (int r = 0; r < dataArray.GetLength(0); r++)
            {
                // x axis
                double xDouble = 0;
                bool isNumberX = double.TryParse(dataArray[r, xAxis], out xDouble);
                // y axis
                double yDouble = 0;
                bool isNumberY = double.TryParse(dataArray[r, yAxis], out yDouble);

                sumx += xDouble;
                sumy += yDouble;
                sumxy += xDouble * yDouble;
                sumxsq += xDouble * xDouble;
                sumysq += yDouble * yDouble;
            }

            a = (sumy*sumxsq - sumx*sumxy) / (dataArray.GetLength(0)*sumxsq - sumx*sumx);
            b = (dataArray.GetLength(0)*sumxy - sumx*sumy) / (dataArray.GetLength(0) * sumxsq - sumx * sumx);
            r = (dataArray.GetLength(0)*sumxy - sumx*sumy) / (Math.Sqrt(dataArray.GetLength(0)*sumxsq - sumx*sumx)* Math.Sqrt(dataArray.GetLength(0) * sumysq - sumy * sumy));

            Func<double, double> linearRegression = (x) => a + b*x;
            return linearRegression;
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
