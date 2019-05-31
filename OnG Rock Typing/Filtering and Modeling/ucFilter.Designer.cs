namespace OnG_Rock_Typing
{
    partial class ucFilter
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
            this.cbSelectVariable = new System.Windows.Forms.ComboBox();
            this.cbSelectAction = new System.Windows.Forms.ComboBox();
            this.textBoxEnterValue = new System.Windows.Forms.TextBox();
            this.closeFilterButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.closeFilterButton)).BeginInit();
            this.SuspendLayout();
            // 
            // cbSelectVariable
            // 
            this.cbSelectVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelectVariable.FormattingEnabled = true;
            this.cbSelectVariable.Location = new System.Drawing.Point(14, 16);
            this.cbSelectVariable.Name = "cbSelectVariable";
            this.cbSelectVariable.Size = new System.Drawing.Size(196, 24);
            this.cbSelectVariable.TabIndex = 1;
            this.cbSelectVariable.SelectedValueChanged += new System.EventHandler(this.cbSelectVariable_SelectedValueChanged);
            // 
            // cbSelectAction
            // 
            this.cbSelectAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelectAction.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbSelectAction.FormattingEnabled = true;
            this.cbSelectAction.Location = new System.Drawing.Point(216, 16);
            this.cbSelectAction.Name = "cbSelectAction";
            this.cbSelectAction.Size = new System.Drawing.Size(178, 24);
            this.cbSelectAction.TabIndex = 2;
            this.cbSelectAction.SelectedIndexChanged += new System.EventHandler(this.cbSelectAction_SelectedIndexChanged);
            // 
            // textBoxEnterValue
            // 
            this.textBoxEnterValue.Location = new System.Drawing.Point(400, 17);
            this.textBoxEnterValue.Name = "textBoxEnterValue";
            this.textBoxEnterValue.Size = new System.Drawing.Size(189, 22);
            this.textBoxEnterValue.TabIndex = 3;
            this.textBoxEnterValue.TextChanged += new System.EventHandler(this.textBoxEnterValue_TextChanged);
            this.textBoxEnterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // closeFilterButton
            // 
            this.closeFilterButton.Image = global::OnG_Rock_Typing.Properties.Resources.close_button_2_512;
            this.closeFilterButton.Location = new System.Drawing.Point(606, 15);
            this.closeFilterButton.Name = "closeFilterButton";
            this.closeFilterButton.Size = new System.Drawing.Size(33, 27);
            this.closeFilterButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.closeFilterButton.TabIndex = 8;
            this.closeFilterButton.TabStop = false;
            this.closeFilterButton.Click += new System.EventHandler(this.closeFilterButton_Click);
            // 
            // ucFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.closeFilterButton);
            this.Controls.Add(this.textBoxEnterValue);
            this.Controls.Add(this.cbSelectAction);
            this.Controls.Add(this.cbSelectVariable);
            this.MaximumSize = new System.Drawing.Size(668, 67);
            this.Name = "ucFilter";
            this.Size = new System.Drawing.Size(668, 57);
            ((System.ComponentModel.ISupportInitialize)(this.closeFilterButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbSelectVariable;
        private System.Windows.Forms.ComboBox cbSelectAction;
        private System.Windows.Forms.TextBox textBoxEnterValue;
        private System.Windows.Forms.PictureBox closeFilterButton;
    }
}
