namespace TFCalc.Forms.Dialog
{
    partial class NewWeightForm
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
            this.NewWeightName = new System.Windows.Forms.TextBox();
            this.NewWeightAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NewWeightName
            // 
            this.NewWeightName.Location = new System.Drawing.Point(12, 12);
            this.NewWeightName.Name = "NewWeightName";
            this.NewWeightName.Size = new System.Drawing.Size(227, 20);
            this.NewWeightName.TabIndex = 0;
            // 
            // NewWeightAdd
            // 
            this.NewWeightAdd.Location = new System.Drawing.Point(86, 41);
            this.NewWeightAdd.Name = "NewWeightAdd";
            this.NewWeightAdd.Size = new System.Drawing.Size(75, 23);
            this.NewWeightAdd.TabIndex = 1;
            this.NewWeightAdd.Text = "Add";
            this.NewWeightAdd.UseVisualStyleBackColor = true;
            this.NewWeightAdd.Click += new System.EventHandler(this.NewWeightAdd_Click);
            // 
            // NewWeightForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 76);
            this.Controls.Add(this.NewWeightAdd);
            this.Controls.Add(this.NewWeightName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewWeightForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New parameter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NewWeightName;
        private System.Windows.Forms.Button NewWeightAdd;
    }
}