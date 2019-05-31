using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnG_Rock_Typing
{
    /// <summary>
    /// Class to read/write CSV from/to file.
    /// </summary>
    class ReadWriteCSV
    {   
        /// <summary>
        /// Member variables
        /// </summary>
        private DataTable dt;
        private string[] headerLabels;
        private StringBuilder sb;

        /// <summary>
        /// Method retrieves CSV file and packs it into DataTable.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>DataTable</returns>
        public DataTable BindDataCSV(string filePath)
        {
            
            dt = new DataTable();
            string[] lines = null;
            try
            {
                lines = System.IO.File.ReadAllLines(filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                ucLoadFile.Instance.showIOErrorDialog();
                return null;
            }
            if (lines.Length > 0)
            {
                //first line to create header
                string firstLine = lines[0];
                headerLabels = firstLine.Split(',');

                foreach (string headerWord in headerLabels)
                {
                    dt.Columns.Add(new DataColumn(headerWord));
                }
                
                //for data
                for (int r = 1; r < lines.Length; r++)
                {
                    string[] dataWords = lines[r].Split(',');
                    DataRow dr = dt.NewRow();
                    int columnIndex = 0;
                    foreach (string headerWord in headerLabels)
                    {
                        dr[headerWord] = dataWords[columnIndex++];
                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        /// <summary>
        /// Method generates string array that contains original headers
        /// that will be used to retrieve selected columns.
        /// </summary>
        /// <returns>string array</returns>
        public string[] getAllColumnNames()
        {
            return headerLabels;
        }

        /// <summary>
        /// Method generates string array that contains original data
        /// that will be used to retrieve selected columns.
        /// </summary>
        /// <returns>string 2D array</returns>
        public string[,] getOriginalDataArray()
        {
            int columnsCount = dt.Columns.Count;
            int rowsCount = dt.Rows.Count;
            string[,] dataArray = new string[rowsCount,columnsCount];
            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    dataArray[i, j] = dt.Rows[i][j].ToString();
                }
            }
            return dataArray;
        }

        /// <summary>
        /// Method writes filtered array (or current array if array was never filtered) to file.
        /// </summary>
        /// <param name="path"></param>
        public void writeCSVtoFile(string path)
        {
            string[] headers = ucLoadFile.Instance.getCurrentColumnNames();
            string[,] currentFilteredArray = ucFiltering.Instance.getFilteredData();

            // Get the bounds.
            int num_rows = currentFilteredArray.GetUpperBound(0) + 1;
            int num_cols = currentFilteredArray.GetUpperBound(1) + 1;

            // Convert the array into a CSV string.
            StringBuilder sb = new StringBuilder();

            // Adding headers
            sb.Append(headers[0]);
            // Add the other fields in this row separated by commas.
            for (int col = 1; col < num_cols; col++)
                sb.Append("," + headers[col]);
            sb.AppendLine();

            // Adding body
            for (int row = 0; row < num_rows; row++)
            {
                // Add the first field in this row.
                sb.Append(currentFilteredArray[row, 0]);

                // Add the other fields in this row separated by commas.
                for (int col = 1; col < num_cols; col++)
                    sb.Append("," + currentFilteredArray[row, col]);

                // Move to the next line.
                sb.AppendLine();
            }

            // Return the CSV format string.
            string csv = sb.ToString();

            // Write the CSV file.
            try
            {
                File.WriteAllText(path, csv);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                ucLoadFile.Instance.showIOErrorDialog();
                return;
            }
        }

        /// <summary>
        /// Writing statistics before and after filtering to CSV file.
        /// If array was never filters before and after statistics will match.
        /// </summary>
        /// <param name="path"></param>
        public void writeCSVStatisticstoFile(string path)
        {
            string[] headers = ucLoadFile.Instance.getCurrentColumnNames();
            string[,] currentFilteredArray = ucFiltering.Instance.getFilteredData();
            string[,] unfilteredArray = ucLoadFile.Instance.getCurrentDataArray();
            // Convert the array into a CSV string.
            sb = new StringBuilder();

            appendStatistics(unfilteredArray, headers, "BEFORE");
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine();
            appendStatistics(currentFilteredArray, headers, "AFTER");
            
            // Return the CSV format string.
            string csv = sb.ToString();
            // Write the CSV file.
            try
            {
                File.WriteAllText(path, csv);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                ucLoadFile.Instance.showIOErrorDialog();
                return;
            }
        }

        /// <summary>
        /// Suplementary method to assemble statistics CSV table.
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="headers"></param>
        /// <param name="title"></param>
        public void appendStatistics(string[,] dataTable, string[] headers, string title)
        {
            // Get the bounds.
            int num_cols = dataTable.GetUpperBound(1) + 1;

            // Adding headers
            sb.Append(title);
            // Add the other fields in this row separated by commas.
            for (int col = 0; col < num_cols; col++)
                sb.Append("," + headers[col]);
            sb.AppendLine();

            // Adding body

            // Add MIN
            sb.Append("Min");
            for (int col = 0; col < num_cols; col++)
            {
                string[] dataColumn = ucLoadFile.Instance.getDataColumn(col, dataTable);
                string variableName = headers[col];
                Statistics currentColumnStatistics = new Statistics(variableName, dataColumn);
                string min = currentColumnStatistics.getMin().ToString();
                sb.Append("," + min);
            }
            sb.AppendLine();

            // Add MAX
            sb.Append("Max");
            for (int col = 0; col < num_cols; col++)
            {
                string[] dataColumn = ucLoadFile.Instance.getDataColumn(col, dataTable);
                string variableName = headers[col];
                Statistics currentColumnStatistics = new Statistics(variableName, dataColumn);
                string max = currentColumnStatistics.getMax().ToString();
                sb.Append("," + max);
            }
            sb.AppendLine();

            // Add Mean
            sb.Append("Mean");
            for (int col = 0; col < num_cols; col++)
            {
                string[] dataColumn = ucLoadFile.Instance.getDataColumn(col, dataTable);
                string variableName = headers[col];
                Statistics currentColumnStatistics = new Statistics(variableName, dataColumn);
                string mean = currentColumnStatistics.getMean().ToString();
                sb.Append("," + mean);
            }
            sb.AppendLine();

            // Add HMean
            sb.Append("Hmean");
            for (int col = 0; col < num_cols; col++)
            {
                string[] dataColumn = ucLoadFile.Instance.getDataColumn(col, dataTable);
                string variableName = headers[col];
                Statistics currentColumnStatistics = new Statistics(variableName, dataColumn);
                string hmean = currentColumnStatistics.getHmean().ToString();
                sb.Append("," + hmean);
            }
            sb.AppendLine();

            // Add GMean
            sb.Append("Gmean");
            for (int col = 0; col < num_cols; col++)
            {
                string[] dataColumn = ucLoadFile.Instance.getDataColumn(col, dataTable);
                string variableName = headers[col];
                Statistics currentColumnStatistics = new Statistics(variableName, dataColumn);
                string gmean = currentColumnStatistics.getGmean().ToString();
                sb.Append("," + gmean);
            }
            sb.AppendLine();

            // Add Median
            sb.Append("Median");
            for (int col = 0; col < num_cols; col++)
            {
                string[] dataColumn = ucLoadFile.Instance.getDataColumn(col, dataTable);
                string variableName = headers[col];
                Statistics currentColumnStatistics = new Statistics(variableName, dataColumn);
                string median = currentColumnStatistics.getMedian().ToString();
                sb.Append("," + median);
            }
            sb.AppendLine();

            // Add P10
            sb.Append("P10");
            for (int col = 0; col < num_cols; col++)
            {
                string[] dataColumn = ucLoadFile.Instance.getDataColumn(col, dataTable);
                string variableName = headers[col];
                Statistics currentColumnStatistics = new Statistics(variableName, dataColumn);
                string p10 = currentColumnStatistics.getP10().ToString();
                sb.Append("," + p10);
            }
            sb.AppendLine();

            // Add P50
            sb.Append("P50");
            for (int col = 0; col < num_cols; col++)
            {
                string[] dataColumn = ucLoadFile.Instance.getDataColumn(col, dataTable);
                string variableName = headers[col];
                Statistics currentColumnStatistics = new Statistics(variableName, dataColumn);
                string p50 = currentColumnStatistics.getP50().ToString();
                sb.Append("," + p50);
            }
            sb.AppendLine();

            // Add P90
            sb.Append("P90");
            for (int col = 0; col < num_cols; col++)
            {
                string[] dataColumn = ucLoadFile.Instance.getDataColumn(col, dataTable);
                string variableName = headers[col];
                Statistics currentColumnStatistics = new Statistics(variableName, dataColumn);
                string p90 = currentColumnStatistics.getP90().ToString();
                sb.Append("," + p90);
            }
            sb.AppendLine();

            // Add Missing
            sb.Append("Missing");
            for (int col = 0; col < num_cols; col++)
            {
                string[] dataColumn = ucLoadFile.Instance.getDataColumn(col, dataTable);
                string variableName = headers[col];
                Statistics currentColumnStatistics = new Statistics(variableName, dataColumn);
                string missing = currentColumnStatistics.getMissing().ToString();
                sb.Append("," + missing);
            }
            sb.AppendLine();

            // Add TotalSamples
            sb.Append("Total Samples");
            for (int col = 0; col < num_cols; col++)
            {
                string[] dataColumn = ucLoadFile.Instance.getDataColumn(col, dataTable);
                string variableName = headers[col];
                Statistics currentColumnStatistics = new Statistics(variableName, dataColumn);
                string total = currentColumnStatistics.getTotalSamples().ToString();
                sb.Append("," + total);
            }
            sb.AppendLine();
        }
    }
}
