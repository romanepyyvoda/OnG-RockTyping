namespace OnG_Rock_Typing
{
    partial class ucFiltering
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
            this.flowLayoutFilters = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label = new System.Windows.Forms.Label();
            this.labelFilteredOutValue = new System.Windows.Forms.Label();
            this.labelFilteredOut = new System.Windows.Forms.Label();
            this.labelVariableName = new System.Windows.Forms.Label();
            this.labelAction = new System.Windows.Forms.Label();
            this.labelValue = new System.Windows.Forms.Label();
            this.addFilterButton = new System.Windows.Forms.PictureBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.panelAxisControls = new System.Windows.Forms.Panel();
            this.cbHistogramGroups = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbRegression = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbColorGrouping = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxLogY = new System.Windows.Forms.CheckBox();
            this.checkBoxLogX = new System.Windows.Forms.CheckBox();
            this.cbSelectYAxis = new System.Windows.Forms.ComboBox();
            this.cbSelectXAxis = new System.Windows.Forms.ComboBox();
            this.labelYAxis = new System.Windows.Forms.Label();
            this.labelXAxis = new System.Windows.Forms.Label();
            this.buttonPlot = new System.Windows.Forms.Button();
            this.flowLayoutPlots = new System.Windows.Forms.FlowLayoutPanel();
            this.saveCSVDialog = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addFilterButton)).BeginInit();
            this.panelAxisControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutFilters
            // 
            this.flowLayoutFilters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutFilters.AutoScroll = true;
            this.flowLayoutFilters.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutFilters.ForeColor = System.Drawing.SystemColors.ControlText;
            this.flowLayoutFilters.Location = new System.Drawing.Point(10, 80);
            this.flowLayoutFilters.Name = "flowLayoutFilters";
            this.flowLayoutFilters.Size = new System.Drawing.Size(680, 380);
            this.flowLayoutFilters.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label);
            this.panel1.Controls.Add(this.labelFilteredOutValue);
            this.panel1.Controls.Add(this.labelFilteredOut);
            this.panel1.Controls.Add(this.labelVariableName);
            this.panel1.Controls.Add(this.labelAction);
            this.panel1.Controls.Add(this.labelValue);
            this.panel1.Controls.Add(this.addFilterButton);
            this.panel1.Location = new System.Drawing.Point(10, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(680, 63);
            this.panel1.TabIndex = 2;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label.Location = new System.Drawing.Point(4, 5);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(249, 17);
            this.label.TabIndex = 6;
            this.label.Text = "* Select Data To Be Filtered OUT";
            // 
            // labelFilteredOutValue
            // 
            this.labelFilteredOutValue.AutoSize = true;
            this.labelFilteredOutValue.Font = new System.Drawing.Font("Lucida Console", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFilteredOutValue.ForeColor = System.Drawing.Color.Red;
            this.labelFilteredOutValue.Location = new System.Drawing.Point(520, 35);
            this.labelFilteredOutValue.Name = "labelFilteredOutValue";
            this.labelFilteredOutValue.Size = new System.Drawing.Size(40, 24);
            this.labelFilteredOutValue.TabIndex = 5;
            this.labelFilteredOutValue.Text = "0%";
            this.labelFilteredOutValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFilteredOut
            // 
            this.labelFilteredOut.AutoSize = true;
            this.labelFilteredOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFilteredOut.Location = new System.Drawing.Point(514, 11);
            this.labelFilteredOut.Name = "labelFilteredOut";
            this.labelFilteredOut.Size = new System.Drawing.Size(101, 18);
            this.labelFilteredOut.TabIndex = 4;
            this.labelFilteredOut.Text = "Filtered Out:";
            // 
            // labelVariableName
            // 
            this.labelVariableName.AutoSize = true;
            this.labelVariableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVariableName.Location = new System.Drawing.Point(25, 33);
            this.labelVariableName.Name = "labelVariableName";
            this.labelVariableName.Size = new System.Drawing.Size(117, 18);
            this.labelVariableName.TabIndex = 3;
            this.labelVariableName.Text = "Variable Name";
            // 
            // labelAction
            // 
            this.labelAction.AutoSize = true;
            this.labelAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAction.Location = new System.Drawing.Point(228, 33);
            this.labelAction.Name = "labelAction";
            this.labelAction.Size = new System.Drawing.Size(55, 18);
            this.labelAction.TabIndex = 2;
            this.labelAction.Text = "Action";
            // 
            // labelValue
            // 
            this.labelValue.AutoSize = true;
            this.labelValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValue.Location = new System.Drawing.Point(413, 33);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(49, 18);
            this.labelValue.TabIndex = 1;
            this.labelValue.Text = "Value";
            // 
            // addFilterButton
            // 
            this.addFilterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addFilterButton.Image = global::OnG_Rock_Typing.Properties.Resources.add_09_512;
            this.addFilterButton.Location = new System.Drawing.Point(634, 18);
            this.addFilterButton.Name = "addFilterButton";
            this.addFilterButton.Size = new System.Drawing.Size(39, 38);
            this.addFilterButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.addFilterButton.TabIndex = 0;
            this.addFilterButton.TabStop = false;
            this.addFilterButton.Click += new System.EventHandler(this.addFilterButton_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.Location = new System.Drawing.Point(10, 466);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(680, 30);
            this.btnFilter.TabIndex = 6;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // panelAxisControls
            // 
            this.panelAxisControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelAxisControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panelAxisControls.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelAxisControls.Controls.Add(this.cbHistogramGroups);
            this.panelAxisControls.Controls.Add(this.label7);
            this.panelAxisControls.Controls.Add(this.label6);
            this.panelAxisControls.Controls.Add(this.cbRegression);
            this.panelAxisControls.Controls.Add(this.label5);
            this.panelAxisControls.Controls.Add(this.cbColorGrouping);
            this.panelAxisControls.Controls.Add(this.label4);
            this.panelAxisControls.Controls.Add(this.flowLayoutPanel1);
            this.panelAxisControls.Controls.Add(this.label3);
            this.panelAxisControls.Controls.Add(this.label2);
            this.panelAxisControls.Controls.Add(this.label1);
            this.panelAxisControls.Controls.Add(this.checkBoxLogY);
            this.panelAxisControls.Controls.Add(this.checkBoxLogX);
            this.panelAxisControls.Controls.Add(this.cbSelectYAxis);
            this.panelAxisControls.Controls.Add(this.cbSelectXAxis);
            this.panelAxisControls.Controls.Add(this.labelYAxis);
            this.panelAxisControls.Controls.Add(this.labelXAxis);
            this.panelAxisControls.Location = new System.Drawing.Point(696, 9);
            this.panelAxisControls.Name = "panelAxisControls";
            this.panelAxisControls.Size = new System.Drawing.Size(587, 63);
            this.panelAxisControls.TabIndex = 8;
            // 
            // cbHistogramGroups
            // 
            this.cbHistogramGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHistogramGroups.FormattingEnabled = true;
            this.cbHistogramGroups.Location = new System.Drawing.Point(1054, 29);
            this.cbHistogramGroups.Name = "cbHistogramGroups";
            this.cbHistogramGroups.Size = new System.Drawing.Size(121, 24);
            this.cbHistogramGroups.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1006, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(219, 17);
            this.label7.TabIndex = 21;
            this.label7.Text = "Number of Histogram Groups";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(974, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 38);
            this.label6.TabIndex = 20;
            this.label6.Text = "|";
            // 
            // cbRegression
            // 
            this.cbRegression.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRegression.FormattingEnabled = true;
            this.cbRegression.Location = new System.Drawing.Point(820, 29);
            this.cbRegression.Name = "cbRegression";
            this.cbRegression.Size = new System.Drawing.Size(139, 24);
            this.cbRegression.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(843, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "Regression";
            // 
            // cbColorGrouping
            // 
            this.cbColorGrouping.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColorGrouping.FormattingEnabled = true;
            this.cbColorGrouping.Location = new System.Drawing.Point(590, 29);
            this.cbColorGrouping.Name = "cbColorGrouping";
            this.cbColorGrouping.Size = new System.Drawing.Size(180, 24);
            this.cbColorGrouping.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(782, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 38);
            this.label4.TabIndex = 16;
            this.label4.Text = "|";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(511, 61);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanel1.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(590, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Color Grouping Variable";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(550, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 38);
            this.label2.TabIndex = 13;
            this.label2.Text = "|";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(266, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 38);
            this.label1.TabIndex = 12;
            this.label1.Text = "|";
            // 
            // checkBoxLogY
            // 
            this.checkBoxLogY.AutoSize = true;
            this.checkBoxLogY.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxLogY.Location = new System.Drawing.Point(497, 22);
            this.checkBoxLogY.Name = "checkBoxLogY";
            this.checkBoxLogY.Size = new System.Drawing.Size(57, 21);
            this.checkBoxLogY.TabIndex = 11;
            this.checkBoxLogY.Text = "Log";
            this.checkBoxLogY.UseVisualStyleBackColor = true;
            // 
            // checkBoxLogX
            // 
            this.checkBoxLogX.AutoSize = true;
            this.checkBoxLogX.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxLogX.Location = new System.Drawing.Point(214, 21);
            this.checkBoxLogX.Name = "checkBoxLogX";
            this.checkBoxLogX.Size = new System.Drawing.Size(57, 21);
            this.checkBoxLogX.TabIndex = 10;
            this.checkBoxLogX.Text = "Log";
            this.checkBoxLogX.UseVisualStyleBackColor = true;
            // 
            // cbSelectYAxis
            // 
            this.cbSelectYAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelectYAxis.FormattingEnabled = true;
            this.cbSelectYAxis.Location = new System.Drawing.Point(347, 19);
            this.cbSelectYAxis.Name = "cbSelectYAxis";
            this.cbSelectYAxis.Size = new System.Drawing.Size(142, 24);
            this.cbSelectYAxis.TabIndex = 6;
            // 
            // cbSelectXAxis
            // 
            this.cbSelectXAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelectXAxis.FormattingEnabled = true;
            this.cbSelectXAxis.Location = new System.Drawing.Point(65, 19);
            this.cbSelectXAxis.Name = "cbSelectXAxis";
            this.cbSelectXAxis.Size = new System.Drawing.Size(142, 24);
            this.cbSelectXAxis.TabIndex = 5;
            // 
            // labelYAxis
            // 
            this.labelYAxis.AutoSize = true;
            this.labelYAxis.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelYAxis.Location = new System.Drawing.Point(291, 22);
            this.labelYAxis.Name = "labelYAxis";
            this.labelYAxis.Size = new System.Drawing.Size(52, 17);
            this.labelYAxis.TabIndex = 3;
            this.labelYAxis.Text = "Y Axis";
            // 
            // labelXAxis
            // 
            this.labelXAxis.AutoSize = true;
            this.labelXAxis.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelXAxis.Location = new System.Drawing.Point(16, 22);
            this.labelXAxis.Name = "labelXAxis";
            this.labelXAxis.Size = new System.Drawing.Size(44, 20);
            this.labelXAxis.TabIndex = 2;
            this.labelXAxis.Text = "X Axis";
            this.labelXAxis.UseCompatibleTextRendering = true;
            // 
            // buttonPlot
            // 
            this.buttonPlot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPlot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.buttonPlot.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlot.Location = new System.Drawing.Point(696, 467);
            this.buttonPlot.Name = "buttonPlot";
            this.buttonPlot.Size = new System.Drawing.Size(587, 30);
            this.buttonPlot.TabIndex = 12;
            this.buttonPlot.Text = "Plot";
            this.buttonPlot.UseVisualStyleBackColor = false;
            this.buttonPlot.Click += new System.EventHandler(this.buttonPlot_Click);
            // 
            // flowLayoutPlots
            // 
            this.flowLayoutPlots.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPlots.Location = new System.Drawing.Point(696, 80);
            this.flowLayoutPlots.Name = "flowLayoutPlots";
            this.flowLayoutPlots.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.flowLayoutPlots.Size = new System.Drawing.Size(587, 380);
            this.flowLayoutPlots.TabIndex = 13;
            this.flowLayoutPlots.MouseLeave += new System.EventHandler(this.flowLayoutPlots_MouseLeave);
            this.flowLayoutPlots.MouseHover += new System.EventHandler(this.flowLayoutPlots_MouseHover);
            // 
            // ucFiltering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::OnG_Rock_Typing.Properties.Resources.antelope_canyon;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.flowLayoutPlots);
            this.Controls.Add(this.buttonPlot);
            this.Controls.Add(this.panelAxisControls);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutFilters);
            this.Name = "ucFiltering";
            this.Size = new System.Drawing.Size(1300, 500);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addFilterButton)).EndInit();
            this.panelAxisControls.ResumeLayout(false);
            this.panelAxisControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutFilters;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelFilteredOutValue;
        private System.Windows.Forms.Label labelFilteredOut;
        private System.Windows.Forms.Label labelVariableName;
        private System.Windows.Forms.Label labelAction;
        private System.Windows.Forms.Label labelValue;
        private System.Windows.Forms.PictureBox addFilterButton;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Panel panelAxisControls;
        private System.Windows.Forms.Label labelYAxis;
        private System.Windows.Forms.Label labelXAxis;
        private System.Windows.Forms.ComboBox cbSelectYAxis;
        private System.Windows.Forms.ComboBox cbSelectXAxis;
        private System.Windows.Forms.CheckBox checkBoxLogX;
        private System.Windows.Forms.CheckBox checkBoxLogY;
        private System.Windows.Forms.Button buttonPlot;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPlots;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbRegression;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbColorGrouping;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbHistogramGroups;
        private System.Windows.Forms.SaveFileDialog saveCSVDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}
