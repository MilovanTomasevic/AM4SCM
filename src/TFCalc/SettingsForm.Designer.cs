namespace TFCalc
{
    partial class SettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.SettingsGrainCombo = new System.Windows.Forms.ComboBox();
            this.SettingsDataGrid = new System.Windows.Forms.DataGridView();
            this.SettingsLoadDefault = new System.Windows.Forms.Button();
            this.SettingsSave = new System.Windows.Forms.Button();
            this.SettingsGrainLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SettingsGrainValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Grain";
            // 
            // SettingsGrainCombo
            // 
            this.SettingsGrainCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SettingsGrainCombo.FormattingEnabled = true;
            this.SettingsGrainCombo.Items.AddRange(new object[] {
            "1-5",
            "1-10"});
            this.SettingsGrainCombo.Location = new System.Drawing.Point(94, 6);
            this.SettingsGrainCombo.Name = "SettingsGrainCombo";
            this.SettingsGrainCombo.Size = new System.Drawing.Size(94, 21);
            this.SettingsGrainCombo.TabIndex = 1;
            // 
            // SettingsDataGrid
            // 
            this.SettingsDataGrid.AllowUserToAddRows = false;
            this.SettingsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SettingsDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SettingsGrainLevel,
            this.SettingsGrainValue});
            this.SettingsDataGrid.Location = new System.Drawing.Point(15, 33);
            this.SettingsDataGrid.Name = "SettingsDataGrid";
            this.SettingsDataGrid.RowHeadersVisible = false;
            this.SettingsDataGrid.Size = new System.Drawing.Size(254, 145);
            this.SettingsDataGrid.TabIndex = 2;
            // 
            // SettingsLoadDefault
            // 
            this.SettingsLoadDefault.Location = new System.Drawing.Point(15, 263);
            this.SettingsLoadDefault.Name = "SettingsLoadDefault";
            this.SettingsLoadDefault.Size = new System.Drawing.Size(122, 36);
            this.SettingsLoadDefault.TabIndex = 3;
            this.SettingsLoadDefault.Text = "Load defaults";
            this.SettingsLoadDefault.UseVisualStyleBackColor = true;
            // 
            // SettingsSave
            // 
            this.SettingsSave.Location = new System.Drawing.Point(147, 263);
            this.SettingsSave.Name = "SettingsSave";
            this.SettingsSave.Size = new System.Drawing.Size(122, 36);
            this.SettingsSave.TabIndex = 4;
            this.SettingsSave.Text = "Save";
            this.SettingsSave.UseVisualStyleBackColor = true;
            this.SettingsSave.Click += new System.EventHandler(this.SettingsSave_Click);
            // 
            // SettingsGrainLevel
            // 
            this.SettingsGrainLevel.DataPropertyName = "Name";
            this.SettingsGrainLevel.Frozen = true;
            this.SettingsGrainLevel.HeaderText = "Level";
            this.SettingsGrainLevel.Name = "SettingsGrainLevel";
            this.SettingsGrainLevel.ReadOnly = true;
            // 
            // SettingsGrainValue
            // 
            this.SettingsGrainValue.DataPropertyName = "Value";
            this.SettingsGrainValue.HeaderText = "Value";
            this.SettingsGrainValue.Name = "SettingsGrainValue";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 311);
            this.Controls.Add(this.SettingsSave);
            this.Controls.Add(this.SettingsLoadDefault);
            this.Controls.Add(this.SettingsDataGrid);
            this.Controls.Add(this.SettingsGrainCombo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.SettingsDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox SettingsGrainCombo;
        private System.Windows.Forms.DataGridView SettingsDataGrid;
        private System.Windows.Forms.Button SettingsLoadDefault;
        private System.Windows.Forms.Button SettingsSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn SettingsGrainLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn SettingsGrainValue;
    }
}