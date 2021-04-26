using System;
using System.ComponentModel;
using System.Windows.Forms;
using TFCalc.Forms.Dialog;
using TFCalc.Model;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using TFCalc.Enum;

namespace TFCalc
{
    /// <summary>
    /// Class for the main form. Handles all calculations and logic
    /// </summary>
    /// <remarks>
    /// this should be broken in to separate classes.
    /// A MVVM patter should be implemented instead of this
    /// </remarks>
    public partial class MainForm : Form, INotifyPropertyChanged
    {
        public delegate void SettingsDelegate(Settings settings);
        public event PropertyChangedEventHandler PropertyChanged;

        private Settings Settings;
        private BindingList<ServiceModel> ServicesList;
        private FormulaType FormulaType;
        //private RTypes RType;
        //private BindingList<RValues> RTable;
        private string SelectedWeightGroup = Const.MainGroupName;
        private bool UsePQ;
        private DataHolder Data;
        private bool ShowFuzzyResult;
        private double _weightSum;
        private bool _isREnabled;
        /// <summary>
        /// Variable that holds all the relevant calcluation data
        /// </summary>
        private Dictionary<string, GroupData> Groups;
        
        /// <summary>
        /// Filed holding the sum of weights for the currently selected group
        /// </summary>
        public double WeightsSum
        {
            get { return _weightSum; }
            set
            {
                _weightSum = Math.Round(value, 2);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WeightsSum"));
            }
        }
        
        public MainForm()
        {
            InitializeComponent();

            Groups = new Dictionary<string, GroupData>();
            Groups.Add(Const.MainGroupName, new GroupData(Const.MainGroupName));

            LoadSettings();
            LoadRValues();
            LoadDataValues();

            /* Set up bindings */
            WeightSum.DataBindings.Add("Text", this, "WeightsSum");

            AlphaTextBox.Text = Math.Round(AlphaSection.AlphaValue, 2).ToString();
            
            StartServiceNumberBox.TextChanged += StartServiceNumberBox_TextChanged;

            StartFormulaCb.SelectedIndexChanged += delegate
            {
                if (StartFormulaCb.SelectedIndex == 0)
                {
                    WeightTypeCombo.SelectedIndex = 0;
                    WeightTypeCombo.Visible = false;
                    ScoreTypeComboBox.Visible = false;
                    ScoreTypeComboBox.SelectedIndex = 0;
                    FormulaType = FormulaType.LSP;
                    ResultType.SelectedIndex = 0;
                    ResultType.Visible = false;
                    AlphaLbl.Visible = false;
                    AlphaTextBox.Visible = false;
                }
                else
                {
                    WeightTypeCombo.Visible = true;
                    ScoreTypeComboBox.Visible = true;
                    FormulaType = FormulaType.Metod2;
                    ResultType.Visible = true;
                    AlphaLbl.Visible = true;
                    AlphaTextBox.Visible = true;
                    AlphaTextBox.Text = Math.Round(AlphaSection.AlphaValue, 2).ToString();
                }
            };
            switch (FormulaType)
            {
                case FormulaType.LSP:
                    StartFormulaCb.SelectedIndex = 0;
                    break;
                case FormulaType.Metod2:
                    StartFormulaCb.SelectedIndex = 1;
                    break;
                default:
                    StartFormulaCb.SelectedIndex = 0;
                    break;
            }

            //we only use the r table now
            //RDataGrid.DataSource = new BindingSource(RList, null);

            // DataGrid field AutoGenerateColumns can only be set from code.
            // It is missing in the designer
            RGroupDataGrid.AutoGenerateColumns = false;

            WeightDataGrid.AutoGenerateColumns = false;
            WeightDataGrid.DataSource = new BindingSource(Groups[Const.MainGroupName].Weights, null);
            WeightDataGrid.CellValueChanged += WeightDataGrid_CellValueChanged;

            ServicesDataGrid.AutoGenerateColumns = false;
            ServicesDataGrid.DataSource = new BindingSource(ServicesList, null);
            ServicesDataGrid.CellValueChanged += delegate
            {
                //regenerate the score datagrid every time we change the service name
                GenerateScoreData();
            };

            ScoreDataGrid.DataError += ScoreDataGrid_DataError;
            
            ScoreTypeComboBox.SelectedIndexChanged += delegate
            {
                switch (ScoreTypeComboBox.SelectedIndex)
                {
                    case 0:
                        Groups[SelectedWeightGroup].ScoreType = NumberType.Krisp;
                        break;
                    case 1:
                        Groups[SelectedWeightGroup].ScoreType = NumberType.Fuzzy;
                        break;
                }
                GenerateScoreData();
            };
            ScoreTypeComboBox.SelectedIndex = 0;

            WeightTypeCombo.SelectedIndex = 0;
            WeightTypeCombo.SelectedIndexChanged += delegate 
            {
                //update the group field every time we update the weight type
                switch (WeightTypeCombo.SelectedIndex)
                {
                    case 0:
                        Groups[SelectedWeightGroup].WeightType = NumberType.Krisp;
                        //WeightType = NumberType.Krisp;
                        ScoreTypeComboBox.SelectedIndex = 0;
                        ScoreTypeComboBox.Visible = false;
                        break;
                    case 1:
                        Groups[SelectedWeightGroup].WeightType = NumberType.Fuzzy;
                        //WeightType = NumberType.Fuzzy;
                        ScoreTypeComboBox.Visible = true;
                        break;
                }
                RefreshWeightGrid();
            };
            RefreshWeightGrid();

            ResultType.SelectedIndex = 0;
            ResultType.SelectedIndexChanged += delegate
            {
                if (ResultType.SelectedIndex == 0)
                {
                    ShowFuzzyResult = false;
                }
                else
                {
                    ShowFuzzyResult = true;
                }
                FillResultGrid();
            };

            AlphaTextBox.TextChanged += delegate
            {
                double alpha = 0.0;
                if (double.TryParse(AlphaTextBox.Text, out alpha))
                {
                    AlphaSection.AlphaValue = alpha;
                }
            };

            WeightGroupCb.Items.Clear();
            WeightGroupCb.Items.AddRange(Groups.Keys.ToArray());
            WeightGroupCb.SelectedIndex = 0;
            WeightGroupCb.SelectedIndexChanged += delegate
            {
                CollectScores();
                SelectedWeightGroup = (string)WeightGroupCb.SelectedItem;
                RefreshWeightGrid();
                GenerateScoreData();
                
                switch (Groups[SelectedWeightGroup].WeightType)
                {
                    case NumberType.Krisp:
                        WeightTypeCombo.SelectedIndex = 0;
                        break;
                    case NumberType.Fuzzy:
                        WeightTypeCombo.SelectedIndex = 1;
                        break;
                }
                switch (Groups[SelectedWeightGroup].ScoreType)
                {
                    case NumberType.Krisp:
                        ScoreTypeComboBox.SelectedIndex = 0;
                        break;
                    case NumberType.Fuzzy:
                        ScoreTypeComboBox.SelectedIndex = 1;
                        break;
                }
            };

            ScoreDataGrid.CellValueChanged += (sender, e) =>
            {
                var value = ScoreDataGrid[e.ColumnIndex, e.RowIndex].Value as string;
                if (value != null)
                {
                    value = value.Replace('.', ',');
                    double val = 0.0;
                    if (double.TryParse(value, out val))
                    {
                        ScoreDataGrid[e.ColumnIndex, e.RowIndex].Value = Math.Round(val, 4);
                    }
                    else
                    {
                        ScoreDataGrid[e.ColumnIndex, e.RowIndex].Value = 0.0;
                    }
                }
            };
        }

        /// <summary>
        /// Re-load the Weight and R data grids, and toggle column visibility
        /// </summary>
        private void RefreshWeightGrid()
        {
            WeightDataGrid.DataSource = new BindingSource(Groups[SelectedWeightGroup].Weights, null);
            RGroupDataGrid.DataSource = new BindingSource(Groups[SelectedWeightGroup].RList, null);
            switch (Groups[SelectedWeightGroup].WeightType)
            {
                case NumberType.Krisp:
                    WeightDataGrid.Columns["WWeight"].Visible = true;
                    WeightDataGrid.Columns["Left"].Visible = false;
                    WeightDataGrid.Columns["Middle"].Visible = false;
                    WeightDataGrid.Columns["Right"].Visible = false;
                    break;
                case NumberType.Fuzzy:
                    WeightDataGrid.Columns["WWeight"].Visible = false;
                    WeightDataGrid.Columns["Left"].Visible = true;
                    WeightDataGrid.Columns["Middle"].Visible = true;
                    WeightDataGrid.Columns["Right"].Visible = true;
                    break;
                default:
                    break;
            }
        }

        private void ScoreDataGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Console.WriteLine(e.Exception.StackTrace);
        }

        /// <summary>
        /// Load data from backup location
        /// </summary>
        private void LoadDataValues()
        {
            ServicesList = Tools.LoadObject<BindingList<ServiceModel>>(Tools.ServicesPath);
            if (ServicesList == null)
            {
                ServicesList = new BindingList<ServiceModel>();
            }
        }

        /// <summary>
        /// Event triggered when the value of the weight grid cell changes value.
        /// This is when we calculate the sum of w
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WeightDataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            WeightsSum = 0.0;
            foreach (var item in Groups[SelectedWeightGroup].Weights)
            {
                WeightsSum += item.Weight;
            }
            if (WeightsSum > 1)
            {
                WeightErrorLbl.Text = "Weights sum must be less than 1!!";
                WeightErrorLbl.Visible = true;
            }
            else
            {
                WeightErrorLbl.Visible = false;
            }
        }

        /// <summary>
        /// Event invoked when the service number changes.
        /// Here, we update the ServicesList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartServiceNumberBox_TextChanged(object sender, EventArgs e)
        {
            int sNumber = ServicesList.Count;
            if (int.TryParse(StartServiceNumberBox.Text, out sNumber))
            {
                if (sNumber != ServicesList.Count)
                {
                    if (ServicesList.Count < sNumber)
                    {
                        while (ServicesList.Count < sNumber)
                        {
                            ServicesList.Add(new ServiceModel
                            {
                                Index = ServicesList.Count + 1,
                                Name = $"servis {ServicesList.Count + 1}"
                            });
                        }
                    }
                    else
                    {
                        while (ServicesList.Count > sNumber)
                        {
                            ServicesList.RemoveAt(ServicesList.Count - 1);
                        }
                    }
                }
            }
            GenerateScoreData();
        }

        /// <summary>
        /// Generate the score DataGrid, and fill it with available values
        /// </summary>
        private void GenerateScoreData()
        {
            ScoreDataGrid.Columns.Clear();
            DataGridViewColumn col = new DataGridViewColumn();
            DataGridViewCell cell = new DataGridViewTextBoxCell();
            col.CellTemplate = cell;
            col.HeaderText = "Parametar";
            ScoreDataGrid.Columns.Add(CreateTextBoxColumn("Parametar", "weightName", true, true));

            if (Groups[SelectedWeightGroup].ScoreType == NumberType.Krisp)
            {
                //Only use 1 column per service if Crisp
                foreach (var item in ServicesList)
                {
                    item.Key = $"service_{item.Index}";
                    //ScoreDataGrid.Columns.Add(CreateComboBoxColumn(item.Name, item.Key, scores));
                    ScoreDataGrid.Columns.Add(CreateTextBoxColumn(item.Name, item.Key));
                }
                //foreach (var item in WeightGroups[SelectedWeightGroup])
                foreach (var weight in Groups[SelectedWeightGroup].Weights)
                {
                    var parameters = new List<object>();
                    parameters.Add(weight.Name);

                    foreach (var service in ServicesList)
                    {
                        try
                        {
                            //var value = Calculations[score.Key].Scores[item.Name].Middle;
                            var value = Groups[SelectedWeightGroup].Services[service.Key].Score[weight.Name].Middle;
                            parameters.Add(value);
                        }
                        catch
                        {
                            parameters.Add("");
                        }
                    }

                    ScoreDataGrid.Rows.Add(parameters.ToArray());
                }
            }
            else
            {
                //Use multiple columns for each service (3) if Fuzzy
                foreach (var item in ServicesList)
                {
                    item.Key = $"service_{item.Index}";
                    var key = item.Key + "_l";
                    var name = item.Name + " L";
                    //ScoreDataGrid.Columns.Add(CreateComboBoxColumn(name, key, scores));
                    ScoreDataGrid.Columns.Add(CreateTextBoxColumn(name, key));
                    key = item.Key + "_m";
                    name = item.Name + " M";
                    //ScoreDataGrid.Columns.Add(CreateComboBoxColumn(name, key, scores));
                    ScoreDataGrid.Columns.Add(CreateTextBoxColumn(name, key));
                    key = item.Key + "_r";
                    name = item.Name + " R";
                    //ScoreDataGrid.Columns.Add(CreateComboBoxColumn(name, key, scores));
                    ScoreDataGrid.Columns.Add(CreateTextBoxColumn(name, key));
                }
                foreach (var weight in Groups[SelectedWeightGroup].Weights)
                {
                    var parameters = new List<object>();
                    parameters.Add(weight.Name);

                    foreach (var service in ServicesList)
                    {
                        //var value = Calculations[score.Key].Scores[item.Name];
                        try
                        {
                            //var value = Tools.FindStringValue(scores, Calculations[score.Key].Scores[item.Name].Left);
                            //var value = Calculations[score.Key].Scores[weight.Name].Left;
                            var value = Groups[SelectedWeightGroup].Services[service.Key].Score[weight.Name].Left;
                            parameters.Add(value);
                        }
                        catch (Exception e)
                        {
                            //parameters.Add(Settings.Scores[0].Value);
                            parameters.Add("");
                        }
                        try
                        {
                            //var value = Tools.FindStringValue(scores, Calculations[score.Key].Scores[item.Name].Middle);
                            //var value = Calculations[service.Key].Scores[weight.Name].Middle;
                            var value = Groups[SelectedWeightGroup].Services[service.Key].Score[weight.Name].Middle;
                            parameters.Add(value);
                        }
                        catch (Exception e)
                        {
                            //parameters.Add(Settings.Scores[0].Value);
                            parameters.Add("");
                        }
                        try
                        {
                            //var value = Tools.FindStringValue(scores, Calculations[score.Key].Scores[item.Name].Right);
                            //var value = Calculations[service.Key].Scores[weight.Name].Right;
                            var value = Groups[SelectedWeightGroup].Services[service.Key].Score[weight.Name].Right;
                            parameters.Add(value);
                        }
                        catch (Exception e)
                        {
                            //parameters.Add(Settings.Scores[0].Value);
                            parameters.Add("");
                        }
                    }

                    ScoreDataGrid.Rows.Add(parameters.ToArray());
                }
            }
        }

        /// <summary>
        /// Generate the result DataGrid, and fill it with calculations
        /// </summary>
        private void FillResultGrid() {
            //clear previous data
            ResultGridView.Columns.Clear();
            ResultGridView.Columns.Add(CreateTextBoxColumn("Index", "r_values", true, true, 50));
            //create headers
            var header = "P*";
            foreach (var weight in Groups[Const.MainGroupName].Weights)
            {
                header += "; " + weight.Name;
            }

            ResultGridView.Columns.Add(CreateTextBoxColumn(header, "r_values", true, true));
            foreach (var service in ServicesList)
            {
                if (service.Key == null)
                    service.Key = $"service_{service.Index}";
                ResultGridView.Columns.Add(CreateTextBoxColumn(service.Name, service.Key, false, true));
            }
            
            var mainGroup = Groups[Const.MainGroupName];
            var isAlpha = mainGroup.Services.FirstOrDefault().Value.IsAlphaSection;
            int index = 1;
            if (isAlpha)
            {
                var rKeys = mainGroup.Services.FirstOrDefault().Value.FuzzyCalculations.Select(x => x.Key);
                foreach (var rKey in rKeys)
                {
                    var parameters = new List<object>();
                    parameters.Add(index++);
                    parameters.Add(rKey);
                    foreach (var service in mainGroup.Services.Values)
                    {
                        string value = "";
                        var calc = service.FuzzyCalculations[rKey];
                        value = $"[{calc.Start}, {calc.End}]";
                        parameters.Add(value);
                    }
                    ResultGridView.Rows.Add(parameters.ToArray());
                }
            }
            else
            {
                var rKeys = mainGroup.Services.FirstOrDefault().Value.KrispCalculation.Select(x => x.Key);
                foreach (var rKey in rKeys)
                {
                    var parameters = new List<object>();
                    parameters.Add(index++);
                    parameters.Add(rKey);
                    foreach (var service in mainGroup.Services.Values)
                    {
                        string value = "";
                        var calc = service.KrispCalculation[rKey];
                        if (ShowFuzzyResult)
                        {
                            value = $"({calc.Left}, {calc.Middle}, {calc.Right})";
                        }
                        else
                        {
                            var average = (calc.Left + calc.Middle + calc.Right) / 3.0;
                            value = $"{average}";
                        }
                        //value = $"[{calc.Start}, {calc.End}]";
                        parameters.Add(value);
                    }
                    ResultGridView.Rows.Add(parameters.ToArray());
                }
            }
            
        }

        /// <summary>
        /// Create an empty textbox column for a DataGrid
        /// </summary>
        /// <param name="header"></param>
        /// <param name="name"></param>
        /// <param name="frozen"></param>
        /// <param name="readOnly"></param>
        /// <returns></returns>
        public DataGridViewColumn CreateTextBoxColumn(string header, string name, bool frozen = false, bool readOnly = false, int width = 0)
        {
            DataGridViewColumn col = new DataGridViewColumn();
            DataGridViewCell cell = new DataGridViewTextBoxCell();
            col.CellTemplate = cell;
            col.HeaderText = header;
            col.Name = name;
            col.Frozen = frozen;
            col.ReadOnly = readOnly;
            if (width > 0)
                col.Width = width;
            return col;
        }

        /// <summary>
        /// Create an empty combobox column for the DataGrid
        /// </summary>
        /// <param name="header"></param>
        /// <param name="name"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public DataGridViewColumn CreateComboBoxColumn(string header, string name, List<string> values)
        {
            DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
            col.HeaderText = header;
            col.Name = name;
            col.DataSource = values;
            col.Width = 100;
            return col;
        }

        private void LoadRValues()
        {
            //CHANGED not in use because we only use the RTable
            //RList = Tools.LoadObject<BindingList<RValues>>(Tools.RPath);
        }

        /// <summary>
        /// Load settings from a default location
        /// </summary>
        private void LoadSettings()
        {
            Settings = Tools.LoadSettings();
            if (Settings == null)
            {
                Settings = new Settings();
            }
        }

        /// <summary>
        /// Event invoked when the user clicks the settings button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartSettings_Click(object sender, EventArgs e)
        {
            using (var settingsForm = new SettingsForm())
            {
                var del = new SettingsDelegate(settingsForm.SettingsData);
                del(Settings);
                settingsForm.ShowDialog();
            }
        }

        private void RSave_Click(object sender, EventArgs e)
        {
            //CHANGED no need to save R, since we always use the RTable
            //using (SaveFileDialog saveDialog = new SaveFileDialog())
            //{
            //    saveDialog.Filter = "TFCalc R list|*.tfcr";
            //    saveDialog.Title = "Save R list to file";
            //    saveDialog.ShowDialog();

            //    //if (saveDialog.FileName != null)
            //    if (!string.IsNullOrEmpty(saveDialog.FileName))
            //    {
            //        var fs = (FileStream)saveDialog.OpenFile();
            //        Tools.SaveObject(RList, fs);
            //        fs.Close();
            //    }
            //}
        }

        private void RLoad_Click(object sender, EventArgs e)
        {
            //CHANGED using RTable instead
            //Stream myStream = null;
            //OpenFileDialog openDialog = new OpenFileDialog();

            //openDialog.InitialDirectory = "c:\\";
            //openDialog.Filter = "TFCalc R list|*.tfcr";
            //openDialog.FilterIndex = 2;
            //openDialog.RestoreDirectory = true;

            //if (openDialog.ShowDialog() == DialogResult.OK)
            //{
            //    try
            //    {
            //        if ((myStream = openDialog.OpenFile()) != null)
            //        {
            //            using (myStream)
            //            {
            //                var list = Tools.LoadObject<BindingList<RValues>>(myStream);
            //                RList.Clear();
            //                Tools.AddAll(list, RList);
            //                StartRNumberBox.Text = RList.Count.ToString();
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            //    }
            //}
        }

        /// <summary>
        /// Event invoked when the user clicks the Add weight (w) button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WeightAdd_Click(object sender, EventArgs e)
        {
            using (var newWeight = new NewWeightForm())
            {
                //show the dialog
                newWeight.ShowDialog();
                //execution will continue after the dialog is closed
                if (!string.IsNullOrEmpty(newWeight.NewWeight))
                { 
                    var newWeightName = newWeight.NewWeight;
                    Console.WriteLine(newWeightName);
                    if (SelectedWeightGroup.Equals(Const.MainGroupName))
                    {
                        Groups.Add(newWeightName, new GroupData(newWeightName));
                        Groups[Const.MainGroupName].Weights.Add(new WeightModel { Name = newWeightName, Weight = 0.0 });
                        
                        WeightGroupCb.Items.Add(newWeightName);
                    }
                    else
                    {
                        Groups[SelectedWeightGroup].Weights.Add(new WeightModel { Name = newWeightName, Weight = 0.0 });
                    }
                }
            }
            //regenerate the score table, so it includes the new weight we just added
            GenerateScoreData();
        }

        /// <summary>
        /// Event invoked when the user clicks the remove weight button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WeightRemove_Click(object sender, EventArgs e)
        {
            if (WeightDataGrid.SelectedCells.Count > 0)
            {
                var selected = WeightDataGrid.SelectedCells[0];
                if (!SelectedWeightGroup.Equals(Const.MainGroupName))
                {
                    Groups[SelectedWeightGroup].Weights.RemoveAt(selected.RowIndex);
                }
                else
                {

                    var name = Groups[SelectedWeightGroup].Weights[selected.RowIndex].Name;

                    Groups.Remove(name);
                    Groups[Const.MainGroupName].Weights.RemoveAt(selected.RowIndex);

                    WeightGroupCb.Items.Remove(name);
                }
            }
        }

        /// <summary>
        /// Event incoked when the user clicks the Calculate button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScoreCalculate_Click(object sender, EventArgs e)
        {
            //List<CalculationModel> calculations = new List<CalculationModel>();
            //Dictionary<string, CalculationModel> calculationDictionary = new Dictionary<string, CalculationModel>();

            //CHANGED all calculations are kept in separate groups
            //if (Calculations == null)
            //{
            //    Calculations = new Dictionary<string, CalculationModel>();
            //}

            //if (FormulaType == FormulaType.LSP)
            //{
            //    CalculateLSP();
            //}
            //else
            //{
            //CHANGED we only do the FAM4QS
                CalculateFAM4QS();
            //}

            FillResultGrid();
        }

        /// <summary>
        /// Collects scores from the Score DataGrid that the user has inputed.
        /// </summary>
        private void CollectScores()
        {
            //loop through all the rows of the DataGrid
            foreach (DataGridViewRow row in ScoreDataGrid.Rows)
            {
                Console.WriteLine($"** row: {row.Index} **");
                var str = "";
                var weightName = "";
                //loop through the cells in a row
                foreach (DataGridViewCell cell in row.Cells)
                {
                    str += $"{cell.Value}, ";
                    var weightNames = Groups[SelectedWeightGroup].Weights.Select(x => { return x.Name; });
                    if (!weightNames.Contains(cell.Value))
                    {
                        if (Groups[SelectedWeightGroup].ScoreType == NumberType.Krisp)
                        {
                            //if score type is crisp, use only the middle value from the score list
                            var serviceName = ScoreDataGrid.Columns[cell.ColumnIndex].Name;
                            if (!Groups[SelectedWeightGroup].Services.ContainsKey(serviceName))
                            {
                                Groups[SelectedWeightGroup].Services.Add(serviceName, new ServiceData(serviceName));
                            }
                            double score = 0.0;
                            if (cell.Value is double)
                            {
                                score = (double)cell.Value;
                            }
                            else
                            {
                                double.TryParse((string)cell.Value, out score);
                            }
                            Groups[SelectedWeightGroup].Services[serviceName].Score[weightName] = new FuzzyNumber(middle: score);
                        }
                        else
                        {
                            //if fuzzy, use all three values
                            var serviceName = ScoreDataGrid.Columns[cell.ColumnIndex].Name;
                            var fuzzyId = serviceName[serviceName.Length - 1];
                            serviceName = serviceName.Substring(0, serviceName.Length - 2);

                            var service = ServicesList.FirstOrDefault(x => x.Key.Equals(serviceName));
                            var serviceKey = service?.Key;
                            if (!Groups[SelectedWeightGroup].Services.ContainsKey(serviceKey))
                            {
                                Groups[SelectedWeightGroup].Services.Add(serviceKey, new ServiceData(serviceKey));
                            }

                            double score = 0.0;
                            if (cell.Value is double)
                            {
                                score = (double)cell.Value;
                            }
                            else
                            {
                                double.TryParse((string)cell.Value, out score);
                            }

                            if (!Groups[SelectedWeightGroup].Services[serviceKey].Score.ContainsKey(weightName))
                            {
                                Groups[SelectedWeightGroup].Services[serviceKey].Score[weightName] = new FuzzyNumber();
                            }

                            switch (fuzzyId)
                            {
                                case 'l':
                                    Groups[SelectedWeightGroup].Services[serviceKey].Score[weightName].Left = score;
                                    break;
                                case 'm':
                                    Groups[SelectedWeightGroup].Services[serviceKey].Score[weightName].Middle = score;
                                    break;
                                case 'r':
                                    Groups[SelectedWeightGroup].Services[serviceKey].Score[weightName].Right = score;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        weightName = (string)cell.Value;
                    }
                }
                Console.WriteLine($"data: {str}");
            }
        }

        /// <summary>
        /// Calculates using the FAM4QS method
        /// </summary>
        private void CalculateFAM4QS()
        {
            CollectScores();
            var subgroups = Groups.Keys.Where(x => !x.Equals(Const.MainGroupName)).ToList();
            foreach (var subgroupName in subgroups)
            {
                var subgroup = Groups[subgroupName];
                var selectedR = subgroup.RList.Where(x => x.IsSelected).ToList();
                if (selectedR.Count <= 0)
                {
                    //We must have at least one r selected for every subgroup and for the main group
                    //If there are any missing, we will show an error message to the user, and cancel further calculation
                    string message = $"No R selected for {subgroupName}";
                    string caption = "Error";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, caption, buttons);
                    return;
                }

                var services = subgroup.Services;
                foreach (var service in services.Values)
                {
                    //clear any previous data
                    service.KrispCalculation.Clear();
                    service.FuzzyCalculations.Clear();
                    foreach (var r in selectedR)
                    {
                        //if (WeightType == NumberType.Krisp)
                        if (subgroup.WeightType == NumberType.Krisp)
                        {
                            KrispWeightCalc(service, r, subgroup.Weights);
                        }
                        else
                        {
                            FuzzyWeightCalc(service, r, subgroup.Weights, subgroup.ScoreType);
                        }
                    }
                }
            }
            
            var main = Groups[Const.MainGroupName];

            //Generate combinations for all selected r-s, for all services
            List<List<string>> combinations = new List<List<string>>();
            foreach (var group in Groups.Values)
            {
                combinations.Add(group.RList.Where(x => x.IsSelected).Select(x => x.DisplayName).ToList());
            }
            Console.WriteLine(combinations);
            var product = combinations.CartesianProduct();

            var mainGroup = Groups[Const.MainGroupName];
            foreach (var item in mainGroup.Services.Values)
            {
                //clear previous data
                item.KrispCalculation.Clear();
                item.FuzzyCalculations.Clear();
                
                //collect scores
                foreach (var p1 in product)
                {
                    string fullKey = "";
                    string mainRKey = "";
                    for (int i = 0; i < Groups.Values.Count; i++)
                    {
                        var group = Groups.Values.ToList()[i];
                        var key = p1.ToList()[i];
                        fullKey += key;
                        if (i != Groups.Values.Count - 1)
                        {
                            fullKey += ";";
                        }
                        if (group.Name.Equals(Const.MainGroupName)) {
                            //there is no score for the main group
                            //it is just a holder for all main groups
                            mainRKey = key;
                            continue;
                        }
                        var service = group.Services[item.ServiceKey];
                        if (service.IsAlphaSection)
                        {
                            item.FuzzyScore[mainGroup.Weights[i - 1].Name] = group.Services[item.ServiceKey].FuzzyCalculations[key];
                            mainGroup.Weights[i - 1].IsAlphaScore = true;
                        }
                        else
                        {
                            item.Score[mainGroup.Weights[i - 1].Name] = group.Services[item.ServiceKey].KrispCalculation[key];
                            mainGroup.Weights[i - 1].IsAlphaScore = false;
                        }
                    }

                    //find r
                    var r = main.RList.FirstOrDefault(x => x.IsSelected && x.DisplayName.Equals(mainRKey));
                    if (r != null)
                    {
                        //calculate for the main groups, and save using the combined r keys
                        FuzzyWeightCalc(item, r, mainGroup.Weights, mainGroup.ScoreType, fullKey);
                    }
                    
                }
            }

            Console.WriteLine(mainGroup);

        }

        /// <summary>
        /// Calculate fuzzy values, using service as ServiceData class
        /// </summary>
        /// <param name="service"></param>
        /// <param name="r"></param>
        /// <param name="weights"></param>
        /// <param name="scoreType"></param>
        /// <param name="fullRKey"></param>
        private void FuzzyWeightCalc(ServiceData service, RValues r, BindingList<WeightModel> weights, NumberType scoreType, string fullRKey = null)
        {
            if (scoreType == NumberType.Krisp)
            {
                //if score is crisp, the end result will be as fuzzy number (or regular number, but then we only use the Middle value of the fuzzy number)
                var sum = new FuzzyNumber();
                foreach (var w in weights)
                {
                    sum += w.FuzzyWeight * Math.Pow(service.Score[w.Name].Middle, r.Value);
                }
                var calculation = new FuzzyNumber();
                calculation = sum ^ (1.0 / r.Value);

                if (fullRKey == null)
                {
                    service.KrispCalculation.Add(r.DisplayName, calculation);
                }
                else
                {
                    service.KrispCalculation.Add(fullRKey, calculation);
                }
                service.IsAlphaSection = false;
            }
            else
            {
                //If score is fuzzy, that must mean that the weight is also fuzzy. The result must be an Alpha Section
                var sum = new AlphaSection();
                foreach (var w in weights)
                {
                    if (!w.IsAlphaScore)
                    {
                        FuzzyNumber powered = service.Score[w.Name] ^ r.Value;
                        AlphaSection product = w.FuzzyWeight * powered;
                        sum += product;
                    }
                    else
                    {
                        AlphaSection powered = service.FuzzyScore[w.Name] ^ r.Value;
                        AlphaSection product = w.FuzzyWeight * powered;
                        sum += product;
                    }
                }

                var calculation = new AlphaSection();
                calculation = sum ^ (1.0 / r.Value);

                if (fullRKey == null)
                {
                    service.FuzzyCalculations.Add(r.DisplayName, calculation);
                }
                else
                {
                    service.FuzzyCalculations.Add(fullRKey, calculation);
                }
                service.IsAlphaSection = true;
            }
        }

        /// <summary>
        /// Fuzzy calculation using service as CalculationModel class
        /// NOT IN USE
        /// </summary>
        /// <param name="service"></param>
        /// <param name="r"></param>
        /// <param name="scoreType"></param>
        /// <param name="weights"></param>
        private void FuzzyWeightCalc(CalculationModel service, RValues r, NumberType scoreType, BindingList<WeightModel> weights = null)
        {
            BindingList<WeightModel> weightList = weights;
            if (weightList == null)
            {
                weightList = Groups[SelectedWeightGroup].Weights;
            }

            if (scoreType == NumberType.Krisp)
            {
                FuzzyNumber sum = new FuzzyNumber();
                //TODO fix this
                foreach (var w in weightList)
                {
                    //if (IsREnabled)
                    //{
                        if (UsePQ)
                        {
                            //Tools.FuzzySumAdd(ref sum, w.FuzzyWeight, service.Scores[w.Name], r.PValue);
                            sum += w.FuzzyWeight * Math.Pow(service.Scores[w.Name].Middle, r.PValue);
                        }
                        else
                        {
                            //Tools.FuzzySumAdd(ref sum, w.FuzzyWeight, service.Scores[w.Name], r.Value);
                            sum += w.FuzzyWeight * Math.Pow(service.Scores[w.Name].Middle, r.Value);
                        }
                    //}
                    //else
                    //{
                    //    //Tools.FuzzySumAdd(ref sum, w.FuzzyWeight, service.Scores[w.Name], 1);
                    //    sum += w.FuzzyWeight * service.Scores[w.Name].Middle;
                    //}
                }
                FuzzyNumber calc = new FuzzyNumber();
                //if (IsREnabled)
                //{
                    if (UsePQ)
                    {
                        //Tools.FuzzyPow(ref calc, sum, (1.0 / r.QValue));
                        calc = sum ^ (1.0 / r.QValue);
                    }
                    else
                    {
                        //Tools.FuzzyPow(ref calc, sum, (1.0 / r.Value));
                        calc = sum ^ (1.0 / r.Value);
                    }
                //}
                //else
                //{
                //    calc = sum;
                //}
                service.Calculations.Add(calc);
                service.IsAlphaSection = false;
            }
            else
            {
                AlphaSection sum = new AlphaSection();
                //TODO fix this
                foreach (var w in weightList)
                {
                    //var fW = w.FuzzyWeight;
                    //var aW = AlphaSection.FromFuzzy(fW);
                    //var fE = service.Scores[w.Name];
                    //var aE = AlphaSection.FromFuzzy(fE);
                    //if (IsREnabled)
                    //{
                        FuzzyNumber powered;
                        if (UsePQ)
                        {
                            powered = service.Scores[w.Name] ^ r.PValue;
                        }
                        else
                        {
                            powered = service.Scores[w.Name] ^ r.Value;
                        }
                        AlphaSection product = w.FuzzyWeight * powered;
                        sum += product;
                    //}
                    //else
                    //{
                    //    var product = w.FuzzyWeight * service.Scores[w.Name];
                    //    sum += product;
                    //}
                }
                AlphaSection calc = new AlphaSection();
                //if (IsREnabled)
                //{
                    if (UsePQ)
                    {
                        calc = sum ^ (1.0 / r.QValue);
                    }
                    else
                    {
                        calc = sum ^ (1.0 / r.Value);
                    }
                //}
                //else
                //{
                //    calc = sum;
                //}
                service.FuzzyCalculations.Add(calc);
                service.IsAlphaSection = true;
            }
        }

        /// <summary>
        /// Crisp value calculation, using service as ServiceData class
        /// </summary>
        /// <param name="service"></param>
        /// <param name="r"></param>
        /// <param name="weights"></param>
        /// <param name="fullRKey"></param>
        private void KrispWeightCalc(ServiceData service, RValues r, BindingList<WeightModel> weights, string fullRKey = null)
        {
            double sum = 0.0;
            foreach (var w in weights)
            {
                sum += w.Weight * Math.Pow(service.Score[w.Name].Middle, r.Value);
            }
            double calculation = 0.0;
            calculation = Math.Pow(sum, (1.0 / r.Value));

            if (fullRKey == null)
            {
                service.KrispCalculation.Add(r.DisplayName, new FuzzyNumber(middle: calculation));
            }
            else
            {
                service.KrispCalculation.Add(fullRKey, new FuzzyNumber(middle: calculation));
            }
            service.IsAlphaSection = false;
        }

        /// <summary>
        /// Crisp value calculation, using service as CalculationModel
        /// NOT IN USE
        /// </summary>
        /// <param name="service"></param>
        /// <param name="r"></param>
        /// <param name="weights"></param>
        private void KrispWeightCalc(CalculationModel service, RValues r, BindingList<WeightModel> weights = null)
        {
            double sum = 0.0;
            //TODO change this
            var weightList = weights;
            if (weightList == null)
            {
                weightList = Groups[SelectedWeightGroup].Weights;
            }

            foreach (var w in weightList)
            {
                //if (IsREnabled)
                //{
                    if (UsePQ)
                    {
                        sum += w.Weight * Math.Pow(service.Scores[w.Name].Middle, r.PValue);
                    }
                    else
                    {
                        sum += w.Weight * Math.Pow(service.Scores[w.Name].Middle, r.Value);
                    }
                //}
                //else
                //{
                //    sum += w.Weight * service.Scores[w.Name].Middle;
                //}
            }
            double calc = 0.0;
            //if (IsREnabled)
            //{
                if (UsePQ)
                {
                    calc = Math.Pow(sum, (1.0 / r.QValue));
                }
                else
                {
                    calc = Math.Pow(sum, (1.0 / r.Value));
                }
            //}
            //else
            //{
            //    calc = sum;
            //}
            service.Calculations.Add(new FuzzyNumber { Middle = calc });
            service.IsAlphaSection = false;
        }

        private void CalculateLSP()
        {
            //CHANGED we will not be using the LSP for now
            //CollectScores();
            //foreach (var service in Calculations.Values)
            //{
            //    service.Calculations.Clear();
            //    foreach (var r in RList)
            //    {
            //        //double r = RList[i].Value;
            //        double sum = 0.0;
            //        //TODO change this
            //        foreach (var w in WeightGroups[SelectedWeightGroup])
            //        {
            //            sum += w.Weight * Math.Pow(service.Scores[w.Name].Middle, r.Value);
            //        }
            //        var calc = Math.Pow(sum, (1.0 / r.Value));
            //        service.Calculations.Add(new FuzzyNumber { Middle = calc });
            //    }
            //}

            //foreach (var item in Calculations.Values)
            //{
            //    Console.WriteLine($"** service {item.ServiceName} calculations **");
            //    for (int i = 0; i < item.Calculations.Count; i++)
            //    {
            //        Console.WriteLine($"R({i}) = {item.Calculations[i].Middle}");
            //    }
            //}
        }

        /// <summary>
        /// Event invoked when the user clicks the save data button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResultSaveData_Click(object sender, EventArgs e)
        {
            //fill the data holder object
            Data = new DataHolder();
            Data.Settings = Settings;
            //Data.RList = RList;
            //Data.WeightList = WeightList;
            //Data.WeightGroups = WeightGroups;
            Data.ServicesList = ServicesList;
            //Data.Calculations = Calculations;
            //Data.WeightType = WeightType;
            //Data.ScoreType = ScoreType;
            Data.FormulaType = FormulaType;
            Data.Groups = Groups;
            Data.Alpha = AlphaSection.AlphaValue;

            //show the save dialog, so the user can choose where to save the file
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "FAM4QS Data|*.tfcd";
                saveDialog.Title = "Save data to file";
                saveDialog.ShowDialog();

                //if (saveDialog.FileName != null)
                if (!string.IsNullOrEmpty(saveDialog.FileName))
                {
                    //if location is valid, save data as blob
                    var fs = (FileStream)saveDialog.OpenFile();
                    Tools.SaveObject(Data, fs);
                    fs.Close();
                }
            }
        }

        /// <summary>
        /// Event invoked when the user clicks the save button on the start tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartSave_Click(object sender, EventArgs e)
        {
            ResultSaveData_Click(sender, e);
        }

        /// <summary>
        /// Event invojed when the user clicks the load button on the start tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartLoad_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openDialog = new OpenFileDialog();

            openDialog.InitialDirectory = "c:\\";
            openDialog.Filter = "FAM4QS Data|*.tfcd";
            openDialog.FilterIndex = 2;
            openDialog.RestoreDirectory = true;

            //show the open file dialog so the user can select the file from their system
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openDialog.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            //Load the data from the file in to the DataHolder, and fill all necesarry fields
                            Data = Tools.LoadObject<DataHolder>(myStream);
                            Settings = Data.Settings;
                            //RList = Data.RList;
                            //ServicesList = Data.ServicesList;
                            //WeightList = Data.WeightList;
                            //Calculations = Data.Calculations;
                            //RList.Clear();
                            //Tools.AddAll(Data.RList, RList);
                            ServicesList.Clear();
                            Tools.AddAll(Data.ServicesList, ServicesList);
                            //WeightList.Clear();
                            //Tools.AddAll(Data.WeightList, WeightList);
                            //WeightGroups = Data.WeightGroups;
                            Groups = Data.Groups;
                            
                            WeightGroupCb.Items.Clear();
                            WeightGroupCb.Items.AddRange(Groups.Keys.ToArray());
                            WeightGroupCb.SelectedIndex = 0;

                            RefreshWeightGrid();
                            //CHANGED we only use the R table
                            //StartRNumberBox.Text = RList.Count.ToString();
                            StartServiceNumberBox.Text = ServicesList.Count.ToString();
                            FormulaType = Data.FormulaType;
                            switch (FormulaType)
                            {
                                case FormulaType.LSP:
                                    StartFormulaCb.SelectedIndex = 0;
                                    break;
                                case FormulaType.Metod2:
                                    StartFormulaCb.SelectedIndex = 1;
                                    break;
                            }
                            //WeightType = Data.WeightType;
                            //switch (WeightType)
                            //{
                            //    case NumberType.Krisp:
                            //        WeightTypeCombo.SelectedIndex = 0;
                            //        break;
                            //    case NumberType.Fuzzy:
                            //        WeightTypeCombo.SelectedIndex = 1;
                            //        break;
                            //}
                            //ScoreType = Data.ScoreType;
                            //switch (ScoreType)
                            //{
                            //    case NumberType.Krisp:
                            //        ScoreTypeComboBox.SelectedIndex = 0;
                            //        break;
                            //    case NumberType.Fuzzy:
                            //        ScoreTypeComboBox.SelectedIndex = 1;
                            //        break;
                            //}
                            AlphaSection.AlphaValue = Data.Alpha;
                            AlphaTextBox.Text = AlphaSection.AlphaValue.ToString();
                            GenerateScoreData();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Event invoked when the user clicks the Save result button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResultSave_Click(object sender, EventArgs e)
        {
            var results = new List<string>();
            foreach (var service in ServicesList)
            {
                results.Add(service.Name);

                var serviceData = Groups[Const.MainGroupName].Services[service.Key];
                if (serviceData.IsAlphaSection)
                {
                    foreach (var item in serviceData.FuzzyCalculations.Values)
                    {
                        results.Add($"{item.Start}, {item.End}");
                    }
                }
                else
                {
                    foreach (var item in serviceData.KrispCalculation.Values)
                    {
                        if (Groups[Const.MainGroupName].WeightType == NumberType.Krisp)
                        {
                            results.Add($"{item.Middle}");
                        }
                        else
                        {
                            results.Add("Fuzzy");
                            results.Add($"{item.Left}, {item.Middle}, {item.Right}");
                            results.Add("Averaged");
                            var average = (item.Left + item.Middle + item.Right) / 3.0;
                            results.Add($"{average}");
                        }
                    }
                }

                //var calcs = Calculations[service.Key];
                //var calcs = Groups[SelectedWeightGroup].Services[service.Key];
                //if (calcs.IsAlphaSection)
                //{
                //    foreach (var item in calcs.FuzzyCalculations.Values)
                //    {
                //        results.Add($"{item.Start}, {item.End}");
                //    }
                //}
                //else
                //{
                //    foreach (var item in calcs.KrispCalculation.Values)
                //    {
                //        if (FormulaType == FormulaType.LSP)
                //        {
                //            results.Add($"{item.Middle}");
                //        }
                //        else
                //        {
                //            if (ShowFuzzyResult)
                //                results.Add($"{item.Left}, {item.Middle}, {item.Right}");
                //            else
                //            {
                //                var average = (item.Left + item.Middle + item.Right) / 3.0;
                //                //value = $"{average}";
                //                results.Add($"{average}");
                //            }
                //            results.Add("Middle");

                //            //TODO fix this
                //            if (WeightType == NumberType.Krisp)
                //            {
                //                results.Add($"{item.Middle}");
                //            }
                //            else
                //            {
                //                results.Add("Fuzzy");
                //                results.Add($"{item.Left}, {item.Middle}, {item.Right}");
                //                results.Add("Averaged");
                //                var average = (item.Left + item.Middle + item.Right) / 3.0;
                //                results.Add($"{average}");
                //            }
                //        }
                //    }
                //}
                results.Add("");
            }

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Text file|*.txt";
                saveDialog.Title = "Save results to file";
                saveDialog.ShowDialog();
                
                if (!string.IsNullOrEmpty(saveDialog.FileName))
                {
                    using (var fs = (FileStream)saveDialog.OpenFile())
                    using (var writter = new StreamWriter(fs))
                    {
                        foreach (var item in results)
                        {
                            writter.WriteLine(item);
                        }
                    }
                }
            }
        }
    }
}
