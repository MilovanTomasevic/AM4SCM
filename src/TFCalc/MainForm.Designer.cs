namespace TFCalc
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.FormulaTabsControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.StartSettings = new System.Windows.Forms.Button();
            this.StartSave = new System.Windows.Forms.Button();
            this.StartLoad = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.AlphaLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.StartServiceNumberBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.StartFormulaCb = new System.Windows.Forms.ComboBox();
            this.AlphaTextBox = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.ServicesDataGrid = new System.Windows.Forms.DataGridView();
            this.ServiceIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ScoreCalculate = new System.Windows.Forms.Button();
            this.ScoreTypeComboBox = new System.Windows.Forms.ComboBox();
            this.ScoreDataGrid = new System.Windows.Forms.DataGridView();
            this.RGroupDataGrid = new System.Windows.Forms.DataGridView();
            this.Checked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WeightGroupCb = new System.Windows.Forms.ComboBox();
            this.WeightTypeCombo = new System.Windows.Forms.ComboBox();
            this.WeightRemove = new System.Windows.Forms.Button();
            this.WeightAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.WeightErrorLbl = new System.Windows.Forms.Label();
            this.WeightSum = new System.Windows.Forms.Label();
            this.WeightSumLbl = new System.Windows.Forms.Label();
            this.WeightDataGrid = new System.Windows.Forms.DataGridView();
            this.WName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Left = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Middle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Right = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.ResultType = new System.Windows.Forms.ComboBox();
            this.ResultSaveData = new System.Windows.Forms.Button();
            this.ResultSave = new System.Windows.Forms.Button();
            this.ResultGridView = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.FormulaTabsControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServicesDataGrid)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScoreDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGroupDataGrid)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WeightDataGrid)).BeginInit();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultGridView)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // FormulaTabsControl
            // 
            this.FormulaTabsControl.Controls.Add(this.tabPage1);
            this.FormulaTabsControl.Controls.Add(this.tabPage4);
            this.FormulaTabsControl.Controls.Add(this.tabPage3);
            this.FormulaTabsControl.Controls.Add(this.tabPage6);
            this.FormulaTabsControl.Controls.Add(this.tabPage5);
            this.FormulaTabsControl.Location = new System.Drawing.Point(4, 3);
            this.FormulaTabsControl.Name = "FormulaTabsControl";
            this.FormulaTabsControl.SelectedIndex = 0;
            this.FormulaTabsControl.Size = new System.Drawing.Size(1263, 415);
            this.FormulaTabsControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.StartSettings);
            this.tabPage1.Controls.Add(this.StartSave);
            this.tabPage1.Controls.Add(this.StartLoad);
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1255, 389);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Start";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // StartSettings
            // 
            this.StartSettings.Location = new System.Drawing.Point(248, 6);
            this.StartSettings.Name = "StartSettings";
            this.StartSettings.Size = new System.Drawing.Size(116, 39);
            this.StartSettings.TabIndex = 3;
            this.StartSettings.Text = "Settings";
            this.StartSettings.UseVisualStyleBackColor = true;
            this.StartSettings.Click += new System.EventHandler(this.StartSettings_Click);
            // 
            // StartSave
            // 
            this.StartSave.Location = new System.Drawing.Point(126, 344);
            this.StartSave.Name = "StartSave";
            this.StartSave.Size = new System.Drawing.Size(116, 39);
            this.StartSave.TabIndex = 2;
            this.StartSave.Text = "Save data";
            this.StartSave.UseVisualStyleBackColor = true;
            this.StartSave.Click += new System.EventHandler(this.StartSave_Click);
            // 
            // StartLoad
            // 
            this.StartLoad.Location = new System.Drawing.Point(6, 344);
            this.StartLoad.Name = "StartLoad";
            this.StartLoad.Size = new System.Drawing.Size(116, 39);
            this.StartLoad.TabIndex = 1;
            this.StartLoad.Text = "Load previous";
            this.StartLoad.UseVisualStyleBackColor = true;
            this.StartLoad.Click += new System.EventHandler(this.StartLoad_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.AlphaLbl, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.StartServiceNumberBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.StartFormulaCb, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.AlphaTextBox, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(236, 139);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // AlphaLbl
            // 
            this.AlphaLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AlphaLbl.AutoSize = true;
            this.AlphaLbl.Location = new System.Drawing.Point(3, 114);
            this.AlphaLbl.Name = "AlphaLbl";
            this.AlphaLbl.Size = new System.Drawing.Size(34, 13);
            this.AlphaLbl.TabIndex = 6;
            this.AlphaLbl.Text = "Alpha";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "No. services";
            // 
            // StartServiceNumberBox
            // 
            this.StartServiceNumberBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.StartServiceNumberBox.Location = new System.Drawing.Point(80, 41);
            this.StartServiceNumberBox.Name = "StartServiceNumberBox";
            this.StartServiceNumberBox.Size = new System.Drawing.Size(121, 20);
            this.StartServiceNumberBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Formula";
            // 
            // StartFormulaCb
            // 
            this.StartFormulaCb.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.StartFormulaCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StartFormulaCb.FormattingEnabled = true;
            this.StartFormulaCb.Items.AddRange(new object[] {
            "LSP",
            "FAM4QS"});
            this.StartFormulaCb.Location = new System.Drawing.Point(80, 6);
            this.StartFormulaCb.Name = "StartFormulaCb";
            this.StartFormulaCb.Size = new System.Drawing.Size(121, 21);
            this.StartFormulaCb.TabIndex = 3;
            // 
            // AlphaTextBox
            // 
            this.AlphaTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AlphaTextBox.Location = new System.Drawing.Point(80, 110);
            this.AlphaTextBox.Name = "AlphaTextBox";
            this.AlphaTextBox.Size = new System.Drawing.Size(121, 20);
            this.AlphaTextBox.TabIndex = 7;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.ServicesDataGrid);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1255, 389);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Services";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // ServicesDataGrid
            // 
            this.ServicesDataGrid.AllowUserToAddRows = false;
            this.ServicesDataGrid.AllowUserToDeleteRows = false;
            this.ServicesDataGrid.AllowUserToResizeColumns = false;
            this.ServicesDataGrid.AllowUserToResizeRows = false;
            this.ServicesDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ServicesDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ServiceIndex,
            this.ServiceName});
            this.ServicesDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.ServicesDataGrid.Location = new System.Drawing.Point(6, 6);
            this.ServicesDataGrid.Name = "ServicesDataGrid";
            this.ServicesDataGrid.RowHeadersVisible = false;
            this.ServicesDataGrid.Size = new System.Drawing.Size(166, 165);
            this.ServicesDataGrid.TabIndex = 0;
            // 
            // ServiceIndex
            // 
            this.ServiceIndex.DataPropertyName = "Index";
            this.ServiceIndex.Frozen = true;
            this.ServiceIndex.HeaderText = "No.";
            this.ServiceIndex.Name = "ServiceIndex";
            this.ServiceIndex.ReadOnly = true;
            this.ServiceIndex.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ServiceIndex.Width = 60;
            // 
            // ServiceName
            // 
            this.ServiceName.DataPropertyName = "Name";
            this.ServiceName.HeaderText = "Name";
            this.ServiceName.Name = "ServiceName";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ScoreCalculate);
            this.tabPage3.Controls.Add(this.ScoreTypeComboBox);
            this.tabPage3.Controls.Add(this.ScoreDataGrid);
            this.tabPage3.Controls.Add(this.RGroupDataGrid);
            this.tabPage3.Controls.Add(this.WeightGroupCb);
            this.tabPage3.Controls.Add(this.WeightTypeCombo);
            this.tabPage3.Controls.Add(this.WeightRemove);
            this.tabPage3.Controls.Add(this.WeightAdd);
            this.tabPage3.Controls.Add(this.panel1);
            this.tabPage3.Controls.Add(this.WeightDataGrid);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1255, 389);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Values (w, e, r)";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ScoreCalculate
            // 
            this.ScoreCalculate.Location = new System.Drawing.Point(886, 344);
            this.ScoreCalculate.Name = "ScoreCalculate";
            this.ScoreCalculate.Size = new System.Drawing.Size(116, 39);
            this.ScoreCalculate.TabIndex = 10;
            this.ScoreCalculate.Text = "Calculate";
            this.ScoreCalculate.UseVisualStyleBackColor = true;
            this.ScoreCalculate.Click += new System.EventHandler(this.ScoreCalculate_Click);
            // 
            // ScoreTypeComboBox
            // 
            this.ScoreTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ScoreTypeComboBox.FormattingEnabled = true;
            this.ScoreTypeComboBox.Items.AddRange(new object[] {
            "Crisp e",
            "Fuzzy e"});
            this.ScoreTypeComboBox.Location = new System.Drawing.Point(729, 354);
            this.ScoreTypeComboBox.Name = "ScoreTypeComboBox";
            this.ScoreTypeComboBox.Size = new System.Drawing.Size(154, 21);
            this.ScoreTypeComboBox.TabIndex = 9;
            // 
            // ScoreDataGrid
            // 
            this.ScoreDataGrid.AllowUserToAddRows = false;
            this.ScoreDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ScoreDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.ScoreDataGrid.Location = new System.Drawing.Point(478, 34);
            this.ScoreDataGrid.MultiSelect = false;
            this.ScoreDataGrid.Name = "ScoreDataGrid";
            this.ScoreDataGrid.RowHeadersVisible = false;
            this.ScoreDataGrid.Size = new System.Drawing.Size(405, 307);
            this.ScoreDataGrid.TabIndex = 8;
            // 
            // RGroupDataGrid
            // 
            this.RGroupDataGrid.AllowUserToAddRows = false;
            this.RGroupDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RGroupDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Checked,
            this.Naziv,
            this.Value});
            this.RGroupDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.RGroupDataGrid.Location = new System.Drawing.Point(886, 34);
            this.RGroupDataGrid.Name = "RGroupDataGrid";
            this.RGroupDataGrid.RowHeadersVisible = false;
            this.RGroupDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RGroupDataGrid.Size = new System.Drawing.Size(363, 307);
            this.RGroupDataGrid.TabIndex = 7;
            // 
            // Checked
            // 
            this.Checked.DataPropertyName = "IsSelected";
            this.Checked.FalseValue = "false";
            this.Checked.HeaderText = "Select";
            this.Checked.Name = "Checked";
            this.Checked.TrueValue = "true";
            this.Checked.Width = 50;
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Name";
            this.Naziv.HeaderText = "Description";
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            this.Naziv.Width = 180;
            // 
            // Value
            // 
            this.Value.DataPropertyName = "Value";
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            // 
            // WeightGroupCb
            // 
            this.WeightGroupCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WeightGroupCb.FormattingEnabled = true;
            this.WeightGroupCb.Location = new System.Drawing.Point(7, 6);
            this.WeightGroupCb.Name = "WeightGroupCb";
            this.WeightGroupCb.Size = new System.Drawing.Size(234, 21);
            this.WeightGroupCb.TabIndex = 6;
            // 
            // WeightTypeCombo
            // 
            this.WeightTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WeightTypeCombo.FormattingEnabled = true;
            this.WeightTypeCombo.Items.AddRange(new object[] {
            "Crisp w",
            "Fuzzy w"});
            this.WeightTypeCombo.Location = new System.Drawing.Point(314, 354);
            this.WeightTypeCombo.Name = "WeightTypeCombo";
            this.WeightTypeCombo.Size = new System.Drawing.Size(161, 21);
            this.WeightTypeCombo.TabIndex = 5;
            // 
            // WeightRemove
            // 
            this.WeightRemove.Location = new System.Drawing.Point(128, 344);
            this.WeightRemove.Name = "WeightRemove";
            this.WeightRemove.Size = new System.Drawing.Size(116, 39);
            this.WeightRemove.TabIndex = 4;
            this.WeightRemove.Text = "Remove parameter";
            this.WeightRemove.UseVisualStyleBackColor = true;
            this.WeightRemove.Click += new System.EventHandler(this.WeightRemove_Click);
            // 
            // WeightAdd
            // 
            this.WeightAdd.Location = new System.Drawing.Point(6, 344);
            this.WeightAdd.Name = "WeightAdd";
            this.WeightAdd.Size = new System.Drawing.Size(116, 39);
            this.WeightAdd.TabIndex = 3;
            this.WeightAdd.Text = "Add parameter";
            this.WeightAdd.UseVisualStyleBackColor = true;
            this.WeightAdd.Click += new System.EventHandler(this.WeightAdd_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.WeightErrorLbl);
            this.panel1.Controls.Add(this.WeightSum);
            this.panel1.Controls.Add(this.WeightSumLbl);
            this.panel1.Location = new System.Drawing.Point(314, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(161, 22);
            this.panel1.TabIndex = 1;
            // 
            // WeightErrorLbl
            // 
            this.WeightErrorLbl.AutoEllipsis = true;
            this.WeightErrorLbl.AutoSize = true;
            this.WeightErrorLbl.ForeColor = System.Drawing.Color.Red;
            this.WeightErrorLbl.Location = new System.Drawing.Point(107, 0);
            this.WeightErrorLbl.Name = "WeightErrorLbl";
            this.WeightErrorLbl.Size = new System.Drawing.Size(29, 13);
            this.WeightErrorLbl.TabIndex = 2;
            this.WeightErrorLbl.Text = "Error";
            this.WeightErrorLbl.Visible = false;
            // 
            // WeightSum
            // 
            this.WeightSum.AutoSize = true;
            this.WeightSum.Location = new System.Drawing.Point(44, 0);
            this.WeightSum.Name = "WeightSum";
            this.WeightSum.Size = new System.Drawing.Size(35, 13);
            this.WeightSum.TabIndex = 1;
            this.WeightSum.Text = "label5";
            // 
            // WeightSumLbl
            // 
            this.WeightSumLbl.AutoSize = true;
            this.WeightSumLbl.Location = new System.Drawing.Point(3, 0);
            this.WeightSumLbl.Name = "WeightSumLbl";
            this.WeightSumLbl.Size = new System.Drawing.Size(40, 13);
            this.WeightSumLbl.TabIndex = 0;
            this.WeightSumLbl.Text = "w sum:";
            // 
            // WeightDataGrid
            // 
            this.WeightDataGrid.AllowUserToAddRows = false;
            this.WeightDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WeightDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WName,
            this.WWeight,
            this.Left,
            this.Middle,
            this.Right});
            this.WeightDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.WeightDataGrid.Location = new System.Drawing.Point(6, 34);
            this.WeightDataGrid.Name = "WeightDataGrid";
            this.WeightDataGrid.RowHeadersVisible = false;
            this.WeightDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.WeightDataGrid.Size = new System.Drawing.Size(469, 307);
            this.WeightDataGrid.TabIndex = 0;
            // 
            // WName
            // 
            this.WName.DataPropertyName = "Name";
            this.WName.Frozen = true;
            this.WName.HeaderText = "Name";
            this.WName.Name = "WName";
            this.WName.ReadOnly = true;
            // 
            // WWeight
            // 
            this.WWeight.DataPropertyName = "Weight";
            this.WWeight.HeaderText = "Weight";
            this.WWeight.Name = "WWeight";
            this.WWeight.Width = 90;
            // 
            // Left
            // 
            this.Left.DataPropertyName = "Left";
            this.Left.HeaderText = "Left";
            this.Left.Name = "Left";
            this.Left.Width = 90;
            // 
            // Middle
            // 
            this.Middle.DataPropertyName = "Middle";
            this.Middle.HeaderText = "Middle";
            this.Middle.Name = "Middle";
            this.Middle.Width = 90;
            // 
            // Right
            // 
            this.Right.DataPropertyName = "Right";
            this.Right.HeaderText = "Right";
            this.Right.Name = "Right";
            this.Right.Width = 90;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.ResultType);
            this.tabPage6.Controls.Add(this.ResultSaveData);
            this.tabPage6.Controls.Add(this.ResultSave);
            this.tabPage6.Controls.Add(this.ResultGridView);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1255, 389);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Results";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // ResultType
            // 
            this.ResultType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ResultType.FormattingEnabled = true;
            this.ResultType.Items.AddRange(new object[] {
            "Crisp E",
            "Fuzzy E"});
            this.ResultType.Location = new System.Drawing.Point(6, 353);
            this.ResultType.Name = "ResultType";
            this.ResultType.Size = new System.Drawing.Size(126, 21);
            this.ResultType.TabIndex = 7;
            // 
            // ResultSaveData
            // 
            this.ResultSaveData.Location = new System.Drawing.Point(314, 343);
            this.ResultSaveData.Name = "ResultSaveData";
            this.ResultSaveData.Size = new System.Drawing.Size(116, 39);
            this.ResultSaveData.TabIndex = 6;
            this.ResultSaveData.Text = "Save data";
            this.ResultSaveData.UseVisualStyleBackColor = true;
            this.ResultSaveData.Click += new System.EventHandler(this.ResultSaveData_Click);
            // 
            // ResultSave
            // 
            this.ResultSave.Location = new System.Drawing.Point(436, 343);
            this.ResultSave.Name = "ResultSave";
            this.ResultSave.Size = new System.Drawing.Size(116, 39);
            this.ResultSave.TabIndex = 5;
            this.ResultSave.Text = "Save results";
            this.ResultSave.UseVisualStyleBackColor = true;
            this.ResultSave.Click += new System.EventHandler(this.ResultSave_Click);
            // 
            // ResultGridView
            // 
            this.ResultGridView.AllowUserToAddRows = false;
            this.ResultGridView.AllowUserToDeleteRows = false;
            this.ResultGridView.AllowUserToResizeRows = false;
            this.ResultGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultGridView.Location = new System.Drawing.Point(6, 6);
            this.ResultGridView.MultiSelect = false;
            this.ResultGridView.Name = "ResultGridView";
            this.ResultGridView.ReadOnly = true;
            this.ResultGridView.RowHeadersVisible = false;
            this.ResultGridView.Size = new System.Drawing.Size(1243, 331);
            this.ResultGridView.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.label4);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1255, 389);
            this.tabPage5.TabIndex = 6;
            this.tabPage5.Text = "Help";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(570, 52);
            this.label4.TabIndex = 0;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 419);
            this.Controls.Add(this.FormulaTabsControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "FAM4QS PhD Milovan Tomašević";
            this.FormulaTabsControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ServicesDataGrid)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScoreDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGroupDataGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WeightDataGrid)).EndInit();
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ResultGridView)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl FormulaTabsControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button StartSettings;
        private System.Windows.Forms.Button StartSave;
        private System.Windows.Forms.Button StartLoad;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox StartFormulaCb;
        private System.Windows.Forms.TextBox StartServiceNumberBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.DataGridView WeightDataGrid;
        private System.Windows.Forms.Button WeightRemove;
        private System.Windows.Forms.Button WeightAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label WeightErrorLbl;
        private System.Windows.Forms.Label WeightSum;
        private System.Windows.Forms.Label WeightSumLbl;
        private System.Windows.Forms.DataGridView ServicesDataGrid;
        private System.Windows.Forms.Button ResultSaveData;
        private System.Windows.Forms.Button ResultSave;
        private System.Windows.Forms.DataGridView ResultGridView;
        private System.Windows.Forms.ComboBox WeightTypeCombo;
        private System.Windows.Forms.ComboBox ResultType;
        private System.Windows.Forms.Label AlphaLbl;
        private System.Windows.Forms.TextBox AlphaTextBox;
        private System.Windows.Forms.ComboBox WeightGroupCb;
        private System.Windows.Forms.DataGridView RGroupDataGrid;
        private System.Windows.Forms.DataGridView ScoreDataGrid;
        private System.Windows.Forms.ComboBox ScoreTypeComboBox;
        private System.Windows.Forms.Button ScoreCalculate;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Checked;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn WName;
        private System.Windows.Forms.DataGridViewTextBoxColumn WWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Left;
        private System.Windows.Forms.DataGridViewTextBoxColumn Middle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Right;
    }
}

