namespace Ex1_ModelPerson
{
    partial class FrmPerson
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
            btnTestPerson = new Button();
            txtDebug = new TextBox();
            txtFilter = new TextBox();
            label1 = new Label();
            txtResults = new TextBox();
            btnClear = new Button();
            SuspendLayout();
            // 
            // btnTestPerson
            // 
            btnTestPerson.Location = new Point(15, 15);
            btnTestPerson.Margin = new Padding(6, 6, 6, 6);
            btnTestPerson.Name = "btnTestPerson";
            btnTestPerson.Size = new Size(236, 49);
            btnTestPerson.TabIndex = 0;
            btnTestPerson.Text = "Generate People";
            btnTestPerson.UseVisualStyleBackColor = true;
            btnTestPerson.Click += btnTestPerson_Click;
            // 
            // txtDebug
            // 
            txtDebug.Location = new Point(15, 87);
            txtDebug.Margin = new Padding(6, 6, 6, 6);
            txtDebug.Multiline = true;
            txtDebug.Name = "txtDebug";
            txtDebug.ScrollBars = ScrollBars.Both;
            txtDebug.Size = new Size(593, 651);
            txtDebug.TabIndex = 3;
            // 
            // txtFilter
            // 
            txtFilter.Location = new Point(715, 174);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new Size(305, 39);
            txtFilter.TabIndex = 4;
            txtFilter.KeyPress += txtFilter_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(642, 174);
            label1.Name = "label1";
            label1.Size = new Size(67, 32);
            label1.TabIndex = 5;
            label1.Text = "Filter";
            // 
            // txtResults
            // 
            txtResults.Location = new Point(620, 229);
            txtResults.Margin = new Padding(6);
            txtResults.Multiline = true;
            txtResults.Name = "txtResults";
            txtResults.ScrollBars = ScrollBars.Both;
            txtResults.Size = new Size(593, 326);
            txtResults.TabIndex = 6;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(1034, 170);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(49, 46);
            btnClear.TabIndex = 7;
            btnClear.Text = "X";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // FrmPerson
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1579, 753);
            Controls.Add(btnClear);
            Controls.Add(txtResults);
            Controls.Add(label1);
            Controls.Add(txtFilter);
            Controls.Add(txtDebug);
            Controls.Add(btnTestPerson);
            Margin = new Padding(6, 6, 6, 6);
            Name = "FrmPerson";
            Text = "FrmPerson";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnTestPerson;
        private TextBox txtDebug;
        private TextBox txtFilter;
        private Label label1;
        private TextBox txtResults;
        private Button btnClear;
    }
}