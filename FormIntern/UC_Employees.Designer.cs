namespace FormIntern
{
    partial class UC_Employees
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            tableLayoutPanel1 = new TableLayoutPanel();
            dgvEmp = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Name_Emp = new DataGridViewTextBoxColumn();
            Birthday = new DataGridViewTextBoxColumn();
            Position = new DataGridViewTextBoxColumn();
            Phone = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            Address = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            cbPosition = new ComboBox();
            dtpBd = new DateTimePicker();
            label7 = new Label();
            label6 = new Label();
            txtName = new TextBox();
            label2 = new Label();
            txtId = new TextBox();
            label1 = new Label();
            panel2 = new Panel();
            txtAddress = new TextBox();
            label5 = new Label();
            txtEmail = new TextBox();
            label4 = new Label();
            txtPhone = new TextBox();
            label3 = new Label();
            panel3 = new Panel();
            btnExportEmp = new Button();
            btnImportEmp = new Button();
            btnDeleteEmp = new Button();
            btnUpdateEmp = new Button();
            btnRefreshEmp = new Button();
            btnAddEmp = new Button();
            employeeBindingSource = new BindingSource(components);
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmp).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)employeeBindingSource).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35.440834F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 37.0649643F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.5522041F));
            tableLayoutPanel1.Controls.Add(dgvEmp, 0, 0);
            tableLayoutPanel1.Controls.Add(panel1, 0, 1);
            tableLayoutPanel1.Controls.Add(panel2, 1, 1);
            tableLayoutPanel1.Controls.Add(panel3, 2, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 66.6666641F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Size = new Size(1734, 1196);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvEmp
            // 
            dgvEmp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmp.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvEmp.BackgroundColor = SystemColors.ButtonHighlight;
            dgvEmp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmp.Columns.AddRange(new DataGridViewColumn[] { ID, Name_Emp, Birthday, Position, Phone, Email, Address });
            tableLayoutPanel1.SetColumnSpan(dgvEmp, 3);
            dgvEmp.Location = new Point(3, 3);
            dgvEmp.Name = "dgvEmp";
            dgvEmp.RowHeadersWidth = 82;
            dgvEmp.RowTemplate.Height = 41;
            dgvEmp.ScrollBars = ScrollBars.Vertical;
            dgvEmp.Size = new Size(1728, 791);
            dgvEmp.TabIndex = 0;
            dgvEmp.SelectionChanged += DgvEmp_SelectionChanged;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.HeaderText = "ID";
            ID.MinimumWidth = 10;
            ID.Name = "ID";
            // 
            // Name_Emp
            // 
            Name_Emp.DataPropertyName = "Name";
            Name_Emp.HeaderText = "Name";
            Name_Emp.MinimumWidth = 10;
            Name_Emp.Name = "Name_Emp";
            // 
            // Birthday
            // 
            Birthday.DataPropertyName = "Birthday";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            Birthday.DefaultCellStyle = dataGridViewCellStyle1;
            Birthday.HeaderText = "Birthday";
            Birthday.MinimumWidth = 10;
            Birthday.Name = "Birthday";
            // 
            // Position
            // 
            Position.DataPropertyName = "Position";
            Position.HeaderText = "Position";
            Position.MinimumWidth = 10;
            Position.Name = "Position";
            // 
            // Phone
            // 
            Phone.DataPropertyName = "Phone";
            Phone.HeaderText = "Phone Number";
            Phone.MinimumWidth = 10;
            Phone.Name = "Phone";
            // 
            // Email
            // 
            Email.DataPropertyName = "Email";
            Email.HeaderText = "Email";
            Email.MinimumWidth = 10;
            Email.Name = "Email";
            // 
            // Address
            // 
            Address.DataPropertyName = "Address";
            Address.HeaderText = "Address";
            Address.MinimumWidth = 10;
            Address.Name = "Address";
            // 
            // panel1
            // 
            panel1.Controls.Add(cbPosition);
            panel1.Controls.Add(dtpBd);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(txtName);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtId);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 800);
            panel1.Name = "panel1";
            panel1.Size = new Size(608, 393);
            panel1.TabIndex = 1;
            // 
            // cbPosition
            // 
            cbPosition.FormattingEnabled = true;
            cbPosition.Items.AddRange(new object[] { "Teamlead", "Backend", "Frontend" });
            cbPosition.Location = new Point(147, 309);
            cbPosition.Name = "cbPosition";
            cbPosition.Size = new Size(435, 40);
            cbPosition.TabIndex = 4;
            // 
            // dtpBd
            // 
            dtpBd.CustomFormat = "dd/MM/yyyy";
            dtpBd.Location = new Point(147, 222);
            dtpBd.Name = "dtpBd";
            dtpBd.Size = new Size(435, 39);
            dtpBd.TabIndex = 3;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(26, 309);
            label7.Name = "label7";
            label7.Size = new Size(107, 32);
            label7.TabIndex = 11;
            label7.Text = "Position";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(26, 222);
            label6.Name = "label6";
            label6.Size = new Size(100, 32);
            label6.TabIndex = 10;
            label6.Text = "Bỉthday";
            // 
            // txtName
            // 
            txtName.Location = new Point(147, 128);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Nhập họ tên";
            txtName.Size = new Size(435, 39);
            txtName.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(26, 128);
            label2.Name = "label2";
            label2.Size = new Size(81, 32);
            label2.TabIndex = 2;
            label2.Text = "Name";
            // 
            // txtId
            // 
            txtId.Location = new Point(147, 48);
            txtId.Name = "txtId";
            txtId.PlaceholderText = "Nhập ID";
            txtId.Size = new Size(435, 39);
            txtId.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(26, 44);
            label1.Name = "label1";
            label1.Size = new Size(40, 32);
            label1.TabIndex = 0;
            label1.Text = "ID";
            // 
            // panel2
            // 
            panel2.Controls.Add(txtAddress);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(txtEmail);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(txtPhone);
            panel2.Controls.Add(label3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(617, 800);
            panel2.Name = "panel2";
            panel2.Size = new Size(636, 393);
            panel2.TabIndex = 2;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(160, 247);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.PlaceholderText = "Nhập địa chỉ";
            txtAddress.Size = new Size(445, 119);
            txtAddress.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(12, 275);
            label5.Name = "label5";
            label5.Size = new Size(106, 32);
            label5.TabIndex = 8;
            label5.Text = "Address";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(160, 147);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "example@gmail.com";
            txtEmail.Size = new Size(445, 39);
            txtEmail.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(12, 147);
            label4.Name = "label4";
            label4.Size = new Size(76, 32);
            label4.TabIndex = 6;
            label4.Text = "Email";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(160, 49);
            txtPhone.Name = "txtPhone";
            txtPhone.PlaceholderText = "012*******";
            txtPhone.Size = new Size(445, 39);
            txtPhone.TabIndex = 5;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(12, 37);
            label3.Name = "label3";
            label3.Size = new Size(135, 67);
            label3.TabIndex = 4;
            label3.Text = "Phone \r\nNumber";
            // 
            // panel3
            // 
            panel3.Controls.Add(btnExportEmp);
            panel3.Controls.Add(btnImportEmp);
            panel3.Controls.Add(btnDeleteEmp);
            panel3.Controls.Add(btnUpdateEmp);
            panel3.Controls.Add(btnRefreshEmp);
            panel3.Controls.Add(btnAddEmp);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(1259, 800);
            panel3.Name = "panel3";
            panel3.Size = new Size(472, 393);
            panel3.TabIndex = 3;
            // 
            // btnExportEmp
            // 
            btnExportEmp.BackColor = Color.Tan;
            btnExportEmp.FlatAppearance.BorderColor = Color.DarkGoldenrod;
            btnExportEmp.FlatAppearance.BorderSize = 3;
            btnExportEmp.FlatStyle = FlatStyle.Flat;
            btnExportEmp.Location = new Point(284, 309);
            btnExportEmp.Name = "btnExportEmp";
            btnExportEmp.Size = new Size(150, 63);
            btnExportEmp.TabIndex = 13;
            btnExportEmp.Text = "Export";
            btnExportEmp.UseVisualStyleBackColor = false;
            btnExportEmp.Click += btnExportEmp_Click;
            // 
            // btnImportEmp
            // 
            btnImportEmp.BackColor = Color.Tan;
            btnImportEmp.FlatAppearance.BorderColor = Color.DarkGoldenrod;
            btnImportEmp.FlatAppearance.BorderSize = 3;
            btnImportEmp.FlatStyle = FlatStyle.Flat;
            btnImportEmp.Location = new Point(25, 309);
            btnImportEmp.Name = "btnImportEmp";
            btnImportEmp.Size = new Size(150, 63);
            btnImportEmp.TabIndex = 12;
            btnImportEmp.Text = "Import";
            btnImportEmp.UseVisualStyleBackColor = false;
            btnImportEmp.Click += btnImportEmp_Click;
            // 
            // btnDeleteEmp
            // 
            btnDeleteEmp.BackColor = Color.DarkSeaGreen;
            btnDeleteEmp.FlatAppearance.BorderColor = Color.OliveDrab;
            btnDeleteEmp.FlatAppearance.BorderSize = 3;
            btnDeleteEmp.FlatStyle = FlatStyle.Flat;
            btnDeleteEmp.Location = new Point(284, 178);
            btnDeleteEmp.Name = "btnDeleteEmp";
            btnDeleteEmp.Size = new Size(150, 63);
            btnDeleteEmp.TabIndex = 11;
            btnDeleteEmp.Text = "Delete";
            btnDeleteEmp.UseVisualStyleBackColor = false;
            btnDeleteEmp.Click += btnDeleteEmp_Click;
            // 
            // btnUpdateEmp
            // 
            btnUpdateEmp.BackColor = Color.DarkSeaGreen;
            btnUpdateEmp.FlatAppearance.BorderColor = Color.OliveDrab;
            btnUpdateEmp.FlatAppearance.BorderSize = 3;
            btnUpdateEmp.FlatStyle = FlatStyle.Flat;
            btnUpdateEmp.Location = new Point(25, 178);
            btnUpdateEmp.Name = "btnUpdateEmp";
            btnUpdateEmp.Size = new Size(150, 63);
            btnUpdateEmp.TabIndex = 10;
            btnUpdateEmp.Text = "Update";
            btnUpdateEmp.UseVisualStyleBackColor = false;
            btnUpdateEmp.Click += btnUpdateEmp_Click;
            // 
            // btnRefreshEmp
            // 
            btnRefreshEmp.BackColor = SystemColors.GradientActiveCaption;
            btnRefreshEmp.FlatAppearance.BorderColor = Color.CornflowerBlue;
            btnRefreshEmp.FlatAppearance.BorderSize = 3;
            btnRefreshEmp.FlatStyle = FlatStyle.Flat;
            btnRefreshEmp.Location = new Point(284, 35);
            btnRefreshEmp.Name = "btnRefreshEmp";
            btnRefreshEmp.Size = new Size(150, 62);
            btnRefreshEmp.TabIndex = 9;
            btnRefreshEmp.Text = "Refresh";
            btnRefreshEmp.UseVisualStyleBackColor = false;
            btnRefreshEmp.Click += btnRefreshEmp_Click;
            // 
            // btnAddEmp
            // 
            btnAddEmp.BackColor = SystemColors.GradientActiveCaption;
            btnAddEmp.FlatAppearance.BorderColor = Color.CornflowerBlue;
            btnAddEmp.FlatAppearance.BorderSize = 3;
            btnAddEmp.FlatAppearance.CheckedBackColor = Color.RosyBrown;
            btnAddEmp.FlatStyle = FlatStyle.Flat;
            btnAddEmp.Location = new Point(25, 37);
            btnAddEmp.Name = "btnAddEmp";
            btnAddEmp.Size = new Size(150, 62);
            btnAddEmp.TabIndex = 8;
            btnAddEmp.Text = "Add";
            btnAddEmp.UseVisualStyleBackColor = false;
            btnAddEmp.Click += btnAddEmp_Click;
            // 
            // employeeBindingSource
            // 
            employeeBindingSource.DataSource = typeof(WebIntern.Models.Employee);
            // 
            // UC_Employees
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "UC_Employees";
            Size = new Size(1734, 1196);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEmp).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)employeeBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dgvEmp;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Button btnExportEmp;
        private Button btnImportEmp;
        private Button btnDeleteEmp;
        private Button btnUpdateEmp;
        private Button btnRefreshEmp;
        private Button btnAddEmp;
        private ComboBox cbPosition;
        private DateTimePicker dtpBd;
        private Label label7;
        private Label label6;
        private TextBox txtName;
        private Label label2;
        private TextBox txtId;
        private Label label1;
        private TextBox txtAddress;
        private Label label5;
        private TextBox txtEmail;
        private Label label4;
        private TextBox txtPhone;
        private Label label3;
        private BindingSource employeeBindingSource;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Name_Emp;
        private DataGridViewTextBoxColumn Birthday;
        private DataGridViewTextBoxColumn Position;
        private DataGridViewTextBoxColumn Phone;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Address;
    }
}
