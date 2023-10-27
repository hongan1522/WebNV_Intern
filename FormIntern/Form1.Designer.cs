namespace FormIntern
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
            uC_Employees1 = new UC_Employees();
            SuspendLayout();
            // 
            // uC_Employees1
            // 
            uC_Employees1.Dock = DockStyle.Fill;
            uC_Employees1.Location = new Point(0, 0);
            uC_Employees1.Name = "uC_Employees1";
            uC_Employees1.Size = new Size(1734, 1196);
            uC_Employees1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1734, 1196);
            Controls.Add(uC_Employees1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manager";
            ResumeLayout(false);
        }

        #endregion

        private UC_Employees uC_Employees1;
    }
}