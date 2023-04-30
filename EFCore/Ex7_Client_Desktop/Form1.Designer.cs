namespace Ex7_Client_Desktop
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnListStudents = new Button();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // btnListStudents
            // 
            btnListStudents.Location = new Point(339, 327);
            btnListStudents.Name = "btnListStudents";
            btnListStudents.Size = new Size(118, 43);
            btnListStudents.TabIndex = 0;
            btnListStudents.Text = "List Students";
            btnListStudents.UseVisualStyleBackColor = true;
            btnListStudents.Click += btnListStudents_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(296, 24);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(216, 283);
            textBox1.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox1);
            Controls.Add(btnListStudents);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnListStudents;
        private TextBox textBox1;
    }
}