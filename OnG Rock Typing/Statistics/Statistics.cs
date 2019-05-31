using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnG_Rock_Typing
{
    class Statistics
    {
        private string variableName;
        private double min;
        private double max;
        private double mean;
        private double hmean;
        private double gmean;
        private double median;
        private int missing;
        private double p10;
        private double p50;
        private double p90;
        private int totalSamples;
        private double[] dataArray;
        public Statistics(string variableName, string[] dataArray)
        {
            this.dataArray = parseDataArrayToDouble(dataArray);
            this.variableName = variableName;
            this.min = Min(this.dataArray);
            this.max = Max(this.dataArray);
            this.mean = Mean(this.dataArray);
            this.hmean = Hmean(this.dataArray);
            this.gmean = Gmean(this.dataArray);
            this.missing = Missing(dataArray);
            this.median = Median(this.dataArray);
            this.p10 = getItemByPercentile(10, this.dataArray);
            this.p50 = getItemByPercentile(50, this.dataArray);
            this.p90 = getItemByPercentile(90, this.dataArray);
            this.totalSamples = TotalSamples(dataArray);
        }
        // Getter methods (BEGINNING)
        public string getVariableName()
        {
            return this.variableName; 
        }
        public double getMin()
        {
            return this.min;
        }
        public double getMax()
        {
            return this.max;
        }
        public double getMean()
        {
            return this.mean;
        }
        public double getHmean()
        {
            return this.hmean;
        }
        public double getGmean()
        {
            return this.gmean;
        }
        public double getMedian()
        {
            return this.median;
        }
        public int getMissing()
        {
            return this.missing;
        }
        public double getP10()
        {
            return this.p10;
        }
        public double getP50()
        {
            return this.p50;
        }
        public double getP90()
        {
            return this.p90;
        }
        public int getTotalSamples()
        {
            return this.totalSamples;
        }
        // Getter methods (END)

        /// <summary>
        /// Method converts string data array to double array.
        /// </summary>
        /// <param name="dataArray"></param>column of data
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
        /// Method gets min value from data column.
        /// </summary>
        /// <param name="dataArray"></param>column of data
        /// <returns></returns>
        public double Min(double[] dataArray)
        {
            return dataArray.Min();
        }

        /// <summary>
        /// Method gets max value from data column.
        /// </summary>
        /// <param name="dataArray"></param>column of data
        /// <returns></returns>
        public double Max(double[] dataArray)
        {
            return dataArray.Max();
        }

        /// <summary>
        /// Method gets mean value from data column.
        /// </summary>
        /// <param name="dataArray"></param>column of data
        /// <returns></returns>
        public double Mean(double[] dataArray)
        {
            double sum = 0;
            for (int i = 0; i < dataArray.Length; i++)
            {
                sum += dataArray[i];
            }
            return sum/dataArray.Length;
        }

        /// <summary>
        /// Method gets harmonic mean value from data column.
        /// </summary>
        /// <param name="dataArray"></param>column of data
        /// <returns></returns>
        public double Hmean(double[] dataArray)
        {
            double hSum = 0;
            for (int i = 0; i < dataArray.Length; i++)
            {
                hSum += 1/dataArray[i];
            }
            return dataArray.Length/hSum;
        }

        /// <summary>
        /// Method gets geometric mean value from data column.
        /// </summary>
        /// <param name="dataArray"></param>column of data
        /// <returns></returns>
        public double Gmean(double[] dataArray)
        {
            double multiplied = 1;
            for (int i = 0; i < dataArray.Length; i++)
            {
                multiplied *= dataArray[i];
            }
            return Math.Pow(multiplied, (1/dataArray.Length));
        }

        /// <summary>
        /// Method gets median value from data column.
        /// </summary>
        /// <param name="dataArray"></param>column of data
        /// <returns></returns>
        public double Median(double[] dataArray)
        {
            double[] sortedDataArray = dataArray;
            double median;
            Array.Sort(sortedDataArray);
            int arrayLength = sortedDataArray.Length;
            int mid = arrayLength / 2;
            if (arrayLength % 2 == 0)
            {
                median = (sortedDataArray[mid - 1] + sortedDataArray[mid]) / 2;
            }
            else
            {
                median = sortedDataArray[mid];
            }
            return median;
        }


        /// <summary>
        /// Method gets count of empty cells(values) from data column.
        /// </summary>
        /// <param name="dataArray"></param>column of data
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

        /// <summary>
        /// Method gets value from data column by percentile.
        /// </summary>
        /// <param name="rank"></param>percentile rank
        /// <param name="dataArray"></param>column of data
        /// <returns></returns>
        public double getItemByPercentile(int rank, double[] dataArray)
        {
            double[] sortedDataArray = dataArray;
            Array.Sort(sortedDataArray);
            int quantityOdDataPoints = sortedDataArray.Length;
            int dataPointPosition = (rank * quantityOdDataPoints) / 100;
            return sortedDataArray[dataPointPosition];
        }
               
        public int TotalSamples(string[] dataArray)
        {
            return dataArray.Length;
        }
    }
}
