using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFCalc
{
    public partial class SettingsForm : Form
    {
        private Settings _settings;

        public Settings Settings
        {
            get { return _settings; }
        }

        public SettingsForm()
        {
            InitializeComponent();
            SettingsGrainCombo.SelectedIndexChanged += SettingsGrainCombo_SelectedIndexChanged;
            SettingsDataGrid.AutoGenerateColumns = false;
        }

        private void SettingsGrainCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SettingsGrainCombo.SelectedIndex == 0)
            {
                if (Settings.Grain != ScoreGrain.Coarse)
                {
                    Settings.Grain = ScoreGrain.Coarse;
                    Settings.LoadCoarseDefault();
                }
            }
            else if (SettingsGrainCombo.SelectedIndex == 1)
            {
                if (Settings.Grain != ScoreGrain.Fine)
                {
                    Settings.Grain = ScoreGrain.Fine;
                    Settings.LoadFineDefault();
                }
            }



            //SettingsDataGrid.Rows.Clear();
            //foreach (var item in Settings.Scores)
            //{
            //    SettingsDataGrid.Rows.Add(item.Name, item.Value);
            //}
            //SettingsDataGrid.Refresh();
        }

        public void SettingsData(Settings settings)
        {
            _settings = settings;
            switch (settings.Grain)
            {
                case ScoreGrain.Coarse:
                    SettingsGrainCombo.SelectedIndex = 0;
                    break;
                case ScoreGrain.Fine:
                    SettingsGrainCombo.SelectedIndex = 1;
                    break;
            }
            var source = new BindingSource(_settings.Scores, null);
            SettingsDataGrid.DataSource = source;
        }

        private void SettingsSave_Click(object sender, EventArgs e)
        {
            //foreach (var item in SettingsDataGrid.Rows)
            //{
            //    var row = item as DataGridViewRow;
                
            //}
            Tools.SaveSettings(Settings);
            this.Close();
        }
    }
}
