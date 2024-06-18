namespace argo.UI.UIContent
{
    partial class UserReg
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
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.types = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.User_Role = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.F_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UD_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.L_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONTACT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BDAY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATUS = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTime = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cont = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(174, 232);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 41);
            this.button1.TabIndex = 26;
            this.button1.Text = "Create User";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label6.Location = new System.Drawing.Point(76, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 21);
            this.label6.TabIndex = 24;
            this.label6.Text = "Role Type :";
            // 
            // types
            // 
            this.types.FormattingEnabled = true;
            this.types.Location = new System.Drawing.Point(174, 96);
            this.types.Name = "types";
            this.types.Size = new System.Drawing.Size(278, 29);
            this.types.TabIndex = 25;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.User_Role,
            this.F_NAME,
            this.UD_ID,
            this.L_NAME,
            this.CONTACT,
            this.BDAY,
            this.STATUS});
            this.dataGridView1.Location = new System.Drawing.Point(73, 298);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1049, 278);
            this.dataGridView1.TabIndex = 23;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // User_Role
            // 
            this.User_Role.DataPropertyName = "ROLE_ID";
            this.User_Role.HeaderText = "User Type";
            this.User_Role.Name = "User_Role";
            this.User_Role.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // F_NAME
            // 
            this.F_NAME.DataPropertyName = "F_NAME";
            this.F_NAME.HeaderText = "First Name";
            this.F_NAME.Name = "F_NAME";
            // 
            // UD_ID
            // 
            this.UD_ID.DataPropertyName = "UD_ID";
            this.UD_ID.HeaderText = "USER_ID";
            this.UD_ID.Name = "UD_ID";
            this.UD_ID.Visible = false;
            // 
            // L_NAME
            // 
            this.L_NAME.DataPropertyName = "L_NAME";
            this.L_NAME.HeaderText = "Last Name";
            this.L_NAME.Name = "L_NAME";
            // 
            // CONTACT
            // 
            this.CONTACT.DataPropertyName = "CONTACT";
            this.CONTACT.HeaderText = "Contact";
            this.CONTACT.Name = "CONTACT";
            // 
            // BDAY
            // 
            this.BDAY.DataPropertyName = "BDAY";
            this.BDAY.HeaderText = "Birthday";
            this.BDAY.Name = "BDAY";
            // 
            // STATUS
            // 
            this.STATUS.DataPropertyName = "STATUS_ID";
            this.STATUS.HeaderText = "Status";
            this.STATUS.Name = "STATUS";
            this.STATUS.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label5.Location = new System.Drawing.Point(478, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(195, 24);
            this.label5.TabIndex = 22;
            this.label5.Text = "Customer Register";
            // 
            // dateTime
            // 
            this.dateTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTime.Location = new System.Drawing.Point(585, 181);
            this.dateTime.Name = "dateTime";
            this.dateTime.Size = new System.Drawing.Size(278, 27);
            this.dateTime.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(497, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 21);
            this.label4.TabIndex = 20;
            this.label4.Text = "Birthday :";
            // 
            // cont
            // 
            this.cont.Location = new System.Drawing.Point(174, 183);
            this.cont.Name = "cont";
            this.cont.Size = new System.Drawing.Size(278, 27);
            this.cont.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(82, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 21);
            this.label3.TabIndex = 18;
            this.label3.Text = "Contact :";
            // 
            // lname
            // 
            this.lname.Location = new System.Drawing.Point(585, 140);
            this.lname.Name = "lname";
            this.lname.Size = new System.Drawing.Size(278, 27);
            this.lname.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(478, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 21);
            this.label2.TabIndex = 16;
            this.label2.Text = "Last Name :";
            // 
            // fname
            // 
            this.fname.Location = new System.Drawing.Point(174, 140);
            this.fname.Name = "fname";
            this.fname.Size = new System.Drawing.Size(278, 27);
            this.fname.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(69, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 21);
            this.label1.TabIndex = 14;
            this.label1.Text = "First Name :";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Highlight;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(947, 39);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(175, 45);
            this.button2.TabIndex = 28;
            this.button2.Text = "Loyalty ";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // UserReg
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.types);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cont);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fname);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "UserReg";
            this.Size = new System.Drawing.Size(1191, 604);
            this.Load += new System.EventHandler(this.UserReg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox types;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox cont;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox lname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox fname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewComboBoxColumn User_Role;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn UD_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn L_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONTACT;
        private System.Windows.Forms.DataGridViewTextBoxColumn BDAY;
        private System.Windows.Forms.DataGridViewComboBoxColumn STATUS;
        private System.Windows.Forms.Button button2;
    }
}
