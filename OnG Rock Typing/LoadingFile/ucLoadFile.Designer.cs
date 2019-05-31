namespace OnG_Rock_Typing
{
    partial class ucLoadFile
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelLoadFile = new System.Windows.Forms.Panel();
            this.btnSelectColumns = new System.Windows.Forms.Button();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.labelSelectFile = new System.Windows.Forms.Label();
            this.textFilePath = new System.Windows.Forms.TextBox();
            this.dgvRockDataTable = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panelStatistics = new System.Windows.Forms.Panel();
            this.cbNumberOfGroups = new System.Windows.Forms.ComboBox();
            this.histogramGroupNumberLabel = new System.Windows.Forms.Label();
            this.labelMaxValue = new System.Windows.Forms.Label();
            this.cbSelectVariable = new System.Windows.Forms.ComboBox();
            this.labelTotalSamplesValue = new System.Windows.Forms.Label();
            this.labelMeanValue = new System.Windows.Forms.Label();
            this.labelP90Value = new System.Windows.Forms.Label();
            this.labelMissingValue = new System.Windows.Forms.Label();
            this.labelP50Value = new System.Windows.Forms.Label();
            this.labelMin = new System.Windows.Forms.Label();
            this.labelMax = new System.Windows.Forms.Label();
            this.labelP10Value = new System.Windows.Forms.Label();
            this.labelMean = new System.Windows.Forms.Label();
            this.labelMedianValue = new System.Windows.Forms.Label();
            this.labelMinValue = new System.Windows.Forms.Label();
            this.labelHMeanValue = new System.Windows.Forms.Label();
            this.labelGMeanValue = new System.Windows.Forms.Label();
            this.labelTotalSamples = new System.Windows.Forms.Label();
            this.labelP90 = new System.Windows.Forms.Label();
            this.labelMissing = new System.Windows.Forms.Label();
            this.labelP50 = new System.Windows.Forms.Label();
            this.labelP10 = new System.Windows.Forms.Label();
            this.labelMedian = new System.Windows.Forms.Label();
            this.labelGMean = new System.Windows.Forms.Label();
            this.labelHMean = new System.Windows.Forms.Label();
            this.labelRawStatistics = new System.Windows.Forms.Label();
            this.flowLayoutHistogram = new System.Windows.Forms.FlowLayoutPanel();
            this.panelLoadFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRockDataTable)).BeginInit();
            this.panelStatistics.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLoadFile
            // 
            this.panelLoadFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLoadFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panelLoadFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelLoadFile.Controls.Add(this.btnSelectColumns);
            this.panelLoadFile.Controls.Add(this.btnLoadData);
            this.panelLoadFile.Controls.Add(this.labelSelectFile);
            this.panelLoadFile.Controls.Add(this.textFilePath);
            this.panelLoadFile.Location = new System.Drawing.Point(19, 15);
            this.panelLoadFile.Name = "panelLoadFile";
            this.panelLoadFile.Size = new System.Drawing.Size(1261, 85);
            this.panelLoadFile.TabIndex = 0;
            // 
            // btnSelectColumns
            // 
            this.btnSelectColumns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnSelectColumns.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.btnSelectColumns.Location = new System.Drawing.Point(683, 28);
            this.btnSelectColumns.Name = "btnSelectColumns";
            this.btnSelectColumns.Size = new System.Drawing.Size(169, 45);
            this.btnSelectColumns.TabIndex = 3;
            this.btnSelectColumns.Text = "Select Columns";
            this.btnSelectColumns.UseVisualStyleBackColor = false;
            this.btnSelectColumns.Click += new System.EventHandler(this.btnSelectColumns_Click);
            // 
            // btnLoadData
            // 
            this.btnLoadData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnLoadData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadData.Location = new System.Drawing.Point(528, 28);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(123, 44);
            this.btnLoadData.TabIndex = 2;
            this.btnLoadData.Text = "Load File";
            this.btnLoadData.UseVisualStyleBackColor = false;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // labelSelectFile
            // 
            this.labelSelectFile.AutoSize = true;
            this.labelSelectFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectFile.Location = new System.Drawing.Point(25, 22);
            this.labelSelectFile.Name = "labelSelectFile";
            this.labelSelectFile.Size = new System.Drawing.Size(396, 20);
            this.labelSelectFile.TabIndex = 1;
            this.labelSelectFile.Text = "Please select .csv file that contains rock typing data";
            // 
            // textFilePath
            // 
            this.textFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textFilePath.Location = new System.Drawing.Point(28, 48);
            this.textFilePath.Name = "textFilePath";
            this.textFilePath.Size = new System.Drawing.Size(475, 24);
            this.textFilePath.TabIndex = 0;
            // 
            // dgvRockDataTable
            // 
            this.dgvRockDataTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRockDataTable.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvRockDataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRockDataTable.Location = new System.Drawing.Point(19, 117);
            this.dgvRockDataTable.Name = "dgvRockDataTable";
            this.dgvRockDataTable.RowTemplate.Height = 24;
            this.dgvRockDataTable.Size = new System.Drawing.Size(845, 360);
            this.dgvRockDataTable.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = ".csv";
            // 
            // panelStatistics
            // 
            this.panelStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelStatistics.AutoScroll = true;
            this.panelStatistics.Controls.Add(this.cbNumberOfGroups);
            this.panelStatistics.Controls.Add(this.histogramGroupNumberLabel);
            this.panelStatistics.Controls.Add(this.labelMaxValue);
            this.panelStatistics.Controls.Add(this.cbSelectVariable);
            this.panelStatistics.Controls.Add(this.labelTotalSamplesValue);
            this.panelStatistics.Controls.Add(this.labelMeanValue);
            this.panelStatistics.Controls.Add(this.labelP90Value);
            this.panelStatistics.Controls.Add(this.labelMissingValue);
            this.panelStatistics.Controls.Add(this.labelP50Value);
            this.panelStatistics.Controls.Add(this.labelMin);
            this.panelStatistics.Controls.Add(this.labelMax);
            this.panelStatistics.Controls.Add(this.labelP10Value);
            this.panelStatistics.Controls.Add(this.labelMean);
            this.panelStatistics.Controls.Add(this.labelMedianValue);
            this.panelStatistics.Controls.Add(this.labelMinValue);
            this.panelStatistics.Controls.Add(this.labelHMeanValue);
            this.panelStatistics.Controls.Add(this.labelGMeanValue);
            this.panelStatistics.Controls.Add(this.labelTotalSamples);
            this.panelStatistics.Controls.Add(this.labelP90);
            this.panelStatistics.Controls.Add(this.labelMissing);
            this.panelStatistics.Controls.Add(this.labelP50);
            this.panelStatistics.Controls.Add(this.labelP10);
            this.panelStatistics.Controls.Add(this.labelMedian);
            this.panelStatistics.Controls.Add(this.labelGMean);
            this.panelStatistics.Controls.Add(this.labelHMean);
            this.panelStatistics.Controls.Add(this.labelRawStatistics);
            this.panelStatistics.Location = new System.Drawing.Point(870, 117);
            this.panelStatistics.Name = "panelStatistics";
            this.panelStatistics.Size = new System.Drawing.Size(410, 250);
            this.panelStatistics.TabIndex = 2;
            // 
            // cbNumberOfGroups
            // 
            this.cbNumberOfGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNumberOfGroups.FormattingEnabled = true;
            this.cbNumberOfGroups.Location = new System.Drawing.Point(328, 213);
            this.cbNumberOfGroups.Name = "cbNumberOfGroups";
            this.cbNumberOfGroups.Size = new System.Drawing.Size(61, 24);
            this.cbNumberOfGroups.TabIndex = 53;
            this.cbNumberOfGroups.SelectedIndexChanged += new System.EventHandler(this.cbNumberOfGroups_SelectedIndexChanged);
            // 
            // histogramGroupNumberLabel
            // 
            this.histogramGroupNumberLabel.AutoSize = true;
            this.histogramGroupNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.histogramGroupNumberLabel.Location = new System.Drawing.Point(15, 214);
            this.histogramGroupNumberLabel.Name = "histogramGroupNumberLabel";
            this.histogramGroupNumberLabel.Size = new System.Drawing.Size(278, 18);
            this.histogramGroupNumberLabel.TabIndex = 52;
            this.histogramGroupNumberLabel.Text = "Select number of histogram groups:";
            // 
            // labelMaxValue
            // 
            this.labelMaxValue.AutoSize = true;
            this.labelMaxValue.Location = new System.Drawing.Point(70, 100);
            this.labelMaxValue.Name = "labelMaxValue";
            this.labelMaxValue.Size = new System.Drawing.Size(12, 17);
            this.labelMaxValue.TabIndex = 51;
            this.labelMaxValue.Text = ".";
            // 
            // cbSelectVariable
            // 
            this.cbSelectVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelectVariable.FormattingEnabled = true;
            this.cbSelectVariable.Location = new System.Drawing.Point(34, 40);
            this.cbSelectVariable.Name = "cbSelectVariable";
            this.cbSelectVariable.Size = new System.Drawing.Size(337, 24);
            this.cbSelectVariable.TabIndex = 50;
            this.cbSelectVariable.SelectedIndexChanged += new System.EventHandler(this.cbSelectVariable_SelectedIndexChanged);
            // 
            // labelTotalSamplesValue
            // 
            this.labelTotalSamplesValue.AutoSize = true;
            this.labelTotalSamplesValue.Location = new System.Drawing.Point(218, 171);
            this.labelTotalSamplesValue.Name = "labelTotalSamplesValue";
            this.labelTotalSamplesValue.Size = new System.Drawing.Size(12, 17);
            this.labelTotalSamplesValue.TabIndex = 49;
            this.labelTotalSamplesValue.Text = ".";
            // 
            // labelMeanValue
            // 
            this.labelMeanValue.AutoSize = true;
            this.labelMeanValue.Location = new System.Drawing.Point(81, 117);
            this.labelMeanValue.Name = "labelMeanValue";
            this.labelMeanValue.Size = new System.Drawing.Size(12, 17);
            this.labelMeanValue.TabIndex = 50;
            this.labelMeanValue.Text = ".";
            // 
            // labelP90Value
            // 
            this.labelP90Value.AutoSize = true;
            this.labelP90Value.Location = new System.Drawing.Point(278, 135);
            this.labelP90Value.Name = "labelP90Value";
            this.labelP90Value.Size = new System.Drawing.Size(12, 17);
            this.labelP90Value.TabIndex = 48;
            this.labelP90Value.Text = ".";
            // 
            // labelMissingValue
            // 
            this.labelMissingValue.AutoSize = true;
            this.labelMissingValue.Location = new System.Drawing.Point(303, 153);
            this.labelMissingValue.Name = "labelMissingValue";
            this.labelMissingValue.Size = new System.Drawing.Size(12, 17);
            this.labelMissingValue.TabIndex = 47;
            this.labelMissingValue.Text = ".";
            // 
            // labelP50Value
            // 
            this.labelP50Value.AutoSize = true;
            this.labelP50Value.Location = new System.Drawing.Point(279, 118);
            this.labelP50Value.Name = "labelP50Value";
            this.labelP50Value.Size = new System.Drawing.Size(12, 17);
            this.labelP50Value.TabIndex = 46;
            this.labelP50Value.Text = ".";
            // 
            // labelMin
            // 
            this.labelMin.AutoSize = true;
            this.labelMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMin.Location = new System.Drawing.Point(31, 83);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(38, 17);
            this.labelMin.TabIndex = 30;
            this.labelMin.Text = "Min:";
            // 
            // labelMax
            // 
            this.labelMax.AutoSize = true;
            this.labelMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMax.Location = new System.Drawing.Point(31, 100);
            this.labelMax.Name = "labelMax";
            this.labelMax.Size = new System.Drawing.Size(41, 17);
            this.labelMax.TabIndex = 31;
            this.labelMax.Text = "Max:";
            // 
            // labelP10Value
            // 
            this.labelP10Value.AutoSize = true;
            this.labelP10Value.Location = new System.Drawing.Point(279, 101);
            this.labelP10Value.Name = "labelP10Value";
            this.labelP10Value.Size = new System.Drawing.Size(12, 17);
            this.labelP10Value.TabIndex = 45;
            this.labelP10Value.Text = ".";
            // 
            // labelMean
            // 
            this.labelMean.AutoSize = true;
            this.labelMean.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMean.Location = new System.Drawing.Point(31, 117);
            this.labelMean.Name = "labelMean";
            this.labelMean.Size = new System.Drawing.Size(52, 17);
            this.labelMean.TabIndex = 32;
            this.labelMean.Text = "Mean:";
            // 
            // labelMedianValue
            // 
            this.labelMedianValue.AutoSize = true;
            this.labelMedianValue.Location = new System.Drawing.Point(302, 84);
            this.labelMedianValue.Name = "labelMedianValue";
            this.labelMedianValue.Size = new System.Drawing.Size(12, 17);
            this.labelMedianValue.TabIndex = 44;
            this.labelMedianValue.Text = ".";
            // 
            // labelMinValue
            // 
            this.labelMinValue.AutoSize = true;
            this.labelMinValue.Location = new System.Drawing.Point(67, 83);
            this.labelMinValue.Name = "labelMinValue";
            this.labelMinValue.Size = new System.Drawing.Size(12, 17);
            this.labelMinValue.TabIndex = 41;
            this.labelMinValue.Text = ".";
            // 
            // labelHMeanValue
            // 
            this.labelHMeanValue.AutoSize = true;
            this.labelHMeanValue.Location = new System.Drawing.Point(87, 134);
            this.labelHMeanValue.Name = "labelHMeanValue";
            this.labelHMeanValue.Size = new System.Drawing.Size(12, 17);
            this.labelHMeanValue.TabIndex = 43;
            this.labelHMeanValue.Text = ".";
            // 
            // labelGMeanValue
            // 
            this.labelGMeanValue.AutoSize = true;
            this.labelGMeanValue.Location = new System.Drawing.Point(93, 152);
            this.labelGMeanValue.Name = "labelGMeanValue";
            this.labelGMeanValue.Size = new System.Drawing.Size(12, 17);
            this.labelGMeanValue.TabIndex = 42;
            this.labelGMeanValue.Text = ".";
            // 
            // labelTotalSamples
            // 
            this.labelTotalSamples.AutoSize = true;
            this.labelTotalSamples.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalSamples.Location = new System.Drawing.Point(105, 171);
            this.labelTotalSamples.Name = "labelTotalSamples";
            this.labelTotalSamples.Size = new System.Drawing.Size(116, 17);
            this.labelTotalSamples.TabIndex = 40;
            this.labelTotalSamples.Text = "Total Samples:";
            // 
            // labelP90
            // 
            this.labelP90.AutoSize = true;
            this.labelP90.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelP90.Location = new System.Drawing.Point(240, 135);
            this.labelP90.Name = "labelP90";
            this.labelP90.Size = new System.Drawing.Size(41, 17);
            this.labelP90.TabIndex = 39;
            this.labelP90.Text = "P90:";
            // 
            // labelMissing
            // 
            this.labelMissing.AutoSize = true;
            this.labelMissing.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMissing.Location = new System.Drawing.Point(239, 152);
            this.labelMissing.Name = "labelMissing";
            this.labelMissing.Size = new System.Drawing.Size(67, 17);
            this.labelMissing.TabIndex = 38;
            this.labelMissing.Text = "Missing:";
            // 
            // labelP50
            // 
            this.labelP50.AutoSize = true;
            this.labelP50.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelP50.Location = new System.Drawing.Point(240, 118);
            this.labelP50.Name = "labelP50";
            this.labelP50.Size = new System.Drawing.Size(41, 17);
            this.labelP50.TabIndex = 37;
            this.labelP50.Text = "P50:";
            // 
            // labelP10
            // 
            this.labelP10.AutoSize = true;
            this.labelP10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelP10.Location = new System.Drawing.Point(240, 101);
            this.labelP10.Name = "labelP10";
            this.labelP10.Size = new System.Drawing.Size(41, 17);
            this.labelP10.TabIndex = 36;
            this.labelP10.Text = "P10:";
            // 
            // labelMedian
            // 
            this.labelMedian.AutoSize = true;
            this.labelMedian.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMedian.Location = new System.Drawing.Point(240, 84);
            this.labelMedian.Name = "labelMedian";
            this.labelMedian.Size = new System.Drawing.Size(65, 17);
            this.labelMedian.TabIndex = 35;
            this.labelMedian.Text = "Median:";
            // 
            // labelGMean
            // 
            this.labelGMean.AutoSize = true;
            this.labelGMean.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGMean.Location = new System.Drawing.Point(31, 151);
            this.labelGMean.Name = "labelGMean";
            this.labelGMean.Size = new System.Drawing.Size(64, 17);
            this.labelGMean.TabIndex = 34;
            this.labelGMean.Text = "Gmean:";
            // 
            // labelHMean
            // 
            this.labelHMean.AutoSize = true;
            this.labelHMean.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHMean.Location = new System.Drawing.Point(31, 134);
            this.labelHMean.Name = "labelHMean";
            this.labelHMean.Size = new System.Drawing.Size(63, 17);
            this.labelHMean.TabIndex = 33;
            this.labelHMean.Text = "Hmean:";
            // 
            // labelRawStatistics
            // 
            this.labelRawStatistics.AutoSize = true;
            this.labelRawStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRawStatistics.Location = new System.Drawing.Point(123, 12);
            this.labelRawStatistics.Name = "labelRawStatistics";
            this.labelRawStatistics.Size = new System.Drawing.Size(147, 25);
            this.labelRawStatistics.TabIndex = 29;
            this.labelRawStatistics.Text = "Raw Statistics";
            // 
            // flowLayoutHistogram
            // 
            this.flowLayoutHistogram.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutHistogram.AutoScroll = true;
            this.flowLayoutHistogram.Location = new System.Drawing.Point(870, 373);
            this.flowLayoutHistogram.Name = "flowLayoutHistogram";
            this.flowLayoutHistogram.Size = new System.Drawing.Size(410, 104);
            this.flowLayoutHistogram.TabIndex = 3;
            // 
            // ucLoadFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::OnG_Rock_Typing.Properties.Resources.antelope_canyon;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.flowLayoutHistogram);
            this.Controls.Add(this.panelStatistics);
            this.Controls.Add(this.dgvRockDataTable);
            this.Controls.Add(this.panelLoadFile);
            this.Name = "ucLoadFile";
            this.Size = new System.Drawing.Size(1300, 500);
            this.panelLoadFile.ResumeLayout(false);
            this.panelLoadFile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRockDataTable)).EndInit();
            this.panelStatistics.ResumeLayout(false);
            this.panelStatistics.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLoadFile;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.Label labelSelectFile;
        private System.Windows.Forms.TextBox textFilePath;
        private System.Windows.Forms.DataGridView dgvRockDataTable;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnSelectColumns;
        private System.Windows.Forms.Panel panelStatistics;
        private System.Windows.Forms.Label labelRawStatistics;
        private System.Windows.Forms.ComboBox cbSelectVariable;
        private System.Windows.Forms.Label labelMaxValue;
        private System.Windows.Forms.Label labelTotalSamplesValue;
        private System.Windows.Forms.Label labelMeanValue;
        private System.Windows.Forms.Label labelP90Value;
        private System.Windows.Forms.Label labelMissingValue;
        private System.Windows.Forms.Label labelP50Value;
        private System.Windows.Forms.Label labelMin;
        private System.Windows.Forms.Label labelMax;
        private System.Windows.Forms.Label labelP10Value;
        private System.Windows.Forms.Label labelMean;
        private System.Windows.Forms.Label labelMedianValue;
        private System.Windows.Forms.Label labelMinValue;
        private System.Windows.Forms.Label labelHMeanValue;
        private System.Windows.Forms.Label labelGMeanValue;
        private System.Windows.Forms.Label labelTotalSamples;
        private System.Windows.Forms.Label labelP90;
        private System.Windows.Forms.Label labelMissing;
        private System.Windows.Forms.Label labelP50;
        private System.Windows.Forms.Label labelP10;
        private System.Windows.Forms.Label labelMedian;
        private System.Windows.Forms.Label labelGMean;
        private System.Windows.Forms.Label labelHMean;
        private System.Windows.Forms.ComboBox cbNumberOfGroups;
        private System.Windows.Forms.Label histogramGroupNumberLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutHistogram;
    }
}
