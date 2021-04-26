using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFCalc.Forms.Dialog
{
    public partial class NewWeightForm : Form, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _newWeight;

        public string NewWeight
        {
            get { return _newWeight; }
            set
            {
                _newWeight = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NewWeight"));
            }
        }

        public NewWeightForm()
        {
            InitializeComponent();
            //var binding = new Binding("Text", this, "NewWeight");
            //NewWeightName.DataBindings.Add(binding);
            NewWeightName.DataBindings.Add("Text", this, "NewWeight");
        }

        private void NewWeightAdd_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(NewWeight);
            Close();
        }
    }
}
