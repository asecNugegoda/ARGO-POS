namespace argo.UI
{
    partial class Loyalty
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
            this.LoyatyGridView = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.F_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.L_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONTACT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL_LOYAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.LoyatyGridView)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoyatyGridView
            // 
            this.LoyatyGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.LoyatyGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LoyatyGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.F_NAME,
            this.L_NAME,
            this.CONTACT,
            this.TOTAL_LOYAL});
            this.LoyatyGridView.Location = new System.Drawing.Point(41, 125);
            this.LoyatyGridView.Name = "LoyatyGridView";
            this.LoyatyGridView.Size = new System.Drawing.Size(602, 357);
            this.LoyatyGridView.TabIndex = 0;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.BackColor = System.Drawing.SystemColors.Highlight;
            this.flowLayoutPanel3.Controls.Add(this.flowLayoutPanel1);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(7, 519);
            this.flowLayoutPanel3.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(7, 0);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(7, 512);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(682, 7);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(7, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(682, 7);
            this.panel2.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(682, 7);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(7, 505);
            this.panel3.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label6.Location = new System.Drawing.Point(36, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 30);
            this.label6.TabIndex = 32;
            this.label6.Text = "Loyalty ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(421, 82);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(222, 31);
            this.textBox1.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(224, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 22);
            this.label1.TabIndex = 34;
            this.label1.Text = "Customer Contact :";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(625, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(52, 38);
            this.button2.TabIndex = 35;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // F_NAME
            // 
            this.F_NAME.DataPropertyName = "F_NAME";
            this.F_NAME.HeaderText = "FIRST NAME";
            this.F_NAME.Name = "F_NAME";
            // 
            // L_NAME
            // 
            this.L_NAME.DataPropertyName = "L_NAME";
            this.L_NAME.HeaderText = "LAST NAME";
            this.L_NAME.Name = "L_NAME";
            // 
            // CONTACT
            // 
            this.CONTACT.DataPropertyName = "CONTACT";
            this.CONTACT.HeaderText = "CONTACT";
            this.CONTACT.Name = "CONTACT";
            // 
            // TOTAL_LOYAL
            // 
            this.TOTAL_LOYAL.DataPropertyName = "TOTAL_LOYAL";
            this.TOTAL_LOYAL.HeaderText = "TOTAL LOYALTY POINT";
            this.TOTAL_LOYAL.Name = "TOTAL_LOYAL";
            // 
            // Loyalty
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(689, 519);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.LoyatyGridView);
            this.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "Loyalty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loyalty";
            this.Load += new System.EventHandler(this.Loyalty_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LoyatyGridView)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView LoyatyGridView;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn L_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONTACT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL_LOYAL;
    }
}