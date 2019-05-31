namespace OnG_Rock_Typing
{
    partial class SelectColumnsDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectColumnsDialog));
            this.checkedListBoxColumnsToDisplay = new System.Windows.Forms.CheckedListBox();
            this.labelSelectColumnsDialog = new System.Windows.Forms.Label();
            this.btnSetNewColumns = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkedListBoxColumnsToDisplay
            // 
            this.checkedListBoxColumnsToDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxColumnsToDisplay.CheckOnClick = true;
            this.checkedListBoxColumnsToDisplay.ColumnWidth = 250;
            this.checkedListBoxColumnsToDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBoxColumnsToDisplay.FormattingEnabled = true;
            this.checkedListBoxColumnsToDisplay.Location = new System.Drawing.Point(12, 75);
            this.checkedListBoxColumnsToDisplay.MultiColumn = true;
            this.checkedListBoxColumnsToDisplay.Name = "checkedListBoxColumnsToDisplay";
            this.checkedListBoxColumnsToDisplay.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkedListBoxColumnsToDisplay.Size = new System.Drawing.Size(595, 268);
            this.checkedListBoxColumnsToDisplay.TabIndex = 0;
            // 
            // labelSelectColumnsDialog
            // 
            this.labelSelectColumnsDialog.AutoSize = true;
            this.labelSelectColumnsDialog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelSelectColumnsDialog.Location = new System.Drawing.Point(12, 28);
            this.labelSelectColumnsDialog.Name = "labelSelectColumnsDialog";
            this.labelSelectColumnsDialog.Size = new System.Drawing.Size(474, 25);
            this.labelSelectColumnsDialog.TabIndex = 1;
            this.labelSelectColumnsDialog.Text = "Please select data columns you want to be displayed:";
            // 
            // btnSetNewColumns
            // 
            this.btnSetNewColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetNewColumns.Location = new System.Drawing.Point(539, 374);
            this.btnSetNewColumns.Name = "btnSetNewColumns";
            this.btnSetNewColumns.Size = new System.Drawing.Size(68, 34);
            this.btnSetNewColumns.TabIndex = 2;
            this.btnSetNewColumns.Text = "OK";
            this.btnSetNewColumns.UseVisualStyleBackColor = true;
            this.btnSetNewColumns.Click += new System.EventHandler(this.btnSetNewColumns_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(458, 374);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 35);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClearAll.Location = new System.Drawing.Point(12, 373);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(78, 35);
            this.btnClearAll.TabIndex = 4;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAll.Location = new System.Drawing.Point(96, 373);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(98, 35);
            this.btnSelectAll.TabIndex = 5;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // SelectColumnsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 421);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSetNewColumns);
            this.Controls.Add(this.labelSelectColumnsDialog);
            this.Controls.Add(this.checkedListBoxColumnsToDisplay);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SelectColumnsDialog";
            this.Text = "OnG Rock Typing";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxColumnsToDisplay;
        private System.Windows.Forms.Label labelSelectColumnsDialog;
        private System.Windows.Forms.Button btnSetNewColumns;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnSelectAll;
    }
}