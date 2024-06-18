namespace argo.UI.UIContent
{
    partial class Transaction
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
            this.label5 = new System.Windows.Forms.Label();
            this.inv_from = new System.Windows.Forms.DateTimePicker();
            this.inv_to = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.po_to = new System.Windows.Forms.DateTimePicker();
            this.po_from = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.InvoiceGridView = new System.Windows.Forms.DataGridView();
            this.POSGridView = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.INV_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICE_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ITEM_COUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICE_TOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PO_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PO_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PO_ITEM_COUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PO_TOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inv_total = new System.Windows.Forms.Label();
            this.po_tot = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.POSGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label5.Location = new System.Drawing.Point(58, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 25);
            this.label5.TabIndex = 23;
            this.label5.Text = "Transactions";
            // 
            // inv_from
            // 
            this.inv_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.inv_from.Location = new System.Drawing.Point(468, 54);
            this.inv_from.Name = "inv_from";
            this.inv_from.Size = new System.Drawing.Size(129, 27);
            this.inv_from.TabIndex = 24;
            this.inv_from.ValueChanged += new System.EventHandler(this.inv_from_ValueChanged);
            // 
            // inv_to
            // 
            this.inv_to.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.inv_to.Location = new System.Drawing.Point(648, 54);
            this.inv_to.Name = "inv_to";
            this.inv_to.Size = new System.Drawing.Size(128, 27);
            this.inv_to.TabIndex = 25;
            this.inv_to.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(610, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 21);
            this.label1.TabIndex = 26;
            this.label1.Text = "TO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(405, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 21);
            this.label2.TabIndex = 27;
            this.label2.Text = "FROM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(405, 336);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 21);
            this.label3.TabIndex = 31;
            this.label3.Text = "FROM";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(610, 336);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 21);
            this.label4.TabIndex = 30;
            this.label4.Text = "TO";
            // 
            // po_to
            // 
            this.po_to.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.po_to.Location = new System.Drawing.Point(648, 331);
            this.po_to.Name = "po_to";
            this.po_to.Size = new System.Drawing.Size(128, 27);
            this.po_to.TabIndex = 29;
            this.po_to.ValueChanged += new System.EventHandler(this.po_to_ValueChanged);
            // 
            // po_from
            // 
            this.po_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.po_from.Location = new System.Drawing.Point(468, 331);
            this.po_from.Name = "po_from";
            this.po_from.Size = new System.Drawing.Size(129, 27);
            this.po_from.TabIndex = 28;
            this.po_from.ValueChanged += new System.EventHandler(this.po_from_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label6.Location = new System.Drawing.Point(405, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(169, 21);
            this.label6.TabIndex = 32;
            this.label6.Text = "Invoice Transactions";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label7.Location = new System.Drawing.Point(405, 307);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 21);
            this.label7.TabIndex = 33;
            this.label7.Text = "PO Transactions";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label8.Location = new System.Drawing.Point(797, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 21);
            this.label8.TabIndex = 34;
            this.label8.Text = "INVOICE NO";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label9.Location = new System.Drawing.Point(843, 333);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 21);
            this.label9.TabIndex = 35;
            this.label9.Text = "PO NO";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(912, 57);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(241, 27);
            this.textBox1.TabIndex = 36;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(912, 330);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(241, 27);
            this.textBox2.TabIndex = 37;
            // 
            // InvoiceGridView
            // 
            this.InvoiceGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.InvoiceGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InvoiceGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.INV_DATE,
            this.INVOICE_NO,
            this.ITEM_COUNT,
            this.INVOICE_TOTAL});
            this.InvoiceGridView.Location = new System.Drawing.Point(63, 90);
            this.InvoiceGridView.Name = "InvoiceGridView";
            this.InvoiceGridView.Size = new System.Drawing.Size(1090, 185);
            this.InvoiceGridView.TabIndex = 38;
            // 
            // POSGridView
            // 
            this.POSGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.POSGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.POSGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PO_DATE,
            this.PO_NO,
            this.PO_ITEM_COUNT,
            this.PO_TOTAL});
            this.POSGridView.Location = new System.Drawing.Point(63, 364);
            this.POSGridView.Name = "POSGridView";
            this.POSGridView.Size = new System.Drawing.Size(1090, 176);
            this.POSGridView.TabIndex = 39;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label10.Location = new System.Drawing.Point(59, 291);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(218, 21);
            this.label10.TabIndex = 40;
            this.label10.Text = "INVOICES TOTAL AMOUNT";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label11.Location = new System.Drawing.Point(59, 556);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(173, 21);
            this.label11.TabIndex = 41;
            this.label11.Text = "PO\'s TOTAL AMOUNT";
            // 
            // INV_DATE
            // 
            this.INV_DATE.DataPropertyName = "DATE";
            this.INV_DATE.HeaderText = "DATE";
            this.INV_DATE.Name = "INV_DATE";
            // 
            // INVOICE_NO
            // 
            this.INVOICE_NO.DataPropertyName = "INV_ID";
            this.INVOICE_NO.HeaderText = "INVOICE NO";
            this.INVOICE_NO.Name = "INVOICE_NO";
            // 
            // ITEM_COUNT
            // 
            this.ITEM_COUNT.DataPropertyName = "ITEM_COUNT";
            this.ITEM_COUNT.HeaderText = "ITEM COUNT";
            this.ITEM_COUNT.Name = "ITEM_COUNT";
            // 
            // INVOICE_TOTAL
            // 
            this.INVOICE_TOTAL.DataPropertyName = "INV_TOTAL";
            this.INVOICE_TOTAL.HeaderText = "INVOICE TOTAL";
            this.INVOICE_TOTAL.Name = "INVOICE_TOTAL";
            // 
            // PO_DATE
            // 
            this.PO_DATE.DataPropertyName = "DATE";
            this.PO_DATE.HeaderText = "DATE";
            this.PO_DATE.Name = "PO_DATE";
            // 
            // PO_NO
            // 
            this.PO_NO.DataPropertyName = "PURCHASE_NO";
            this.PO_NO.HeaderText = "PO NO";
            this.PO_NO.Name = "PO_NO";
            // 
            // PO_ITEM_COUNT
            // 
            this.PO_ITEM_COUNT.DataPropertyName = "ITEM_COUNT";
            this.PO_ITEM_COUNT.HeaderText = "ITEM COUNT";
            this.PO_ITEM_COUNT.Name = "PO_ITEM_COUNT";
            // 
            // PO_TOTAL
            // 
            this.PO_TOTAL.DataPropertyName = "PO_PRICE";
            this.PO_TOTAL.HeaderText = "PO TOTAL";
            this.PO_TOTAL.Name = "PO_TOTAL";
            // 
            // inv_total
            // 
            this.inv_total.AutoSize = true;
            this.inv_total.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.inv_total.Location = new System.Drawing.Point(298, 291);
            this.inv_total.Name = "inv_total";
            this.inv_total.Size = new System.Drawing.Size(56, 21);
            this.inv_total.TabIndex = 42;
            this.inv_total.Text = "Rs. 0.0";
            this.inv_total.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.inv_total.Click += new System.EventHandler(this.inv_total_Click);
            // 
            // po_tot
            // 
            this.po_tot.AutoSize = true;
            this.po_tot.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.po_tot.Location = new System.Drawing.Point(264, 556);
            this.po_tot.Name = "po_tot";
            this.po_tot.Size = new System.Drawing.Size(56, 21);
            this.po_tot.TabIndex = 43;
            this.po_tot.Text = "Rs. 0.0";
            this.po_tot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Transaction
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.po_tot);
            this.Controls.Add(this.inv_total);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.POSGridView);
            this.Controls.Add(this.InvoiceGridView);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.po_to);
            this.Controls.Add(this.po_from);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inv_to);
            this.Controls.Add(this.inv_from);
            this.Controls.Add(this.label5);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "Transaction";
            this.Size = new System.Drawing.Size(1191, 604);
            this.Load += new System.EventHandler(this.Transaction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.POSGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker inv_from;
        private System.Windows.Forms.DateTimePicker inv_to;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker po_to;
        private System.Windows.Forms.DateTimePicker po_from;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridView InvoiceGridView;
        private System.Windows.Forms.DataGridView POSGridView;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn INV_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICE_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_COUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICE_TOTAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn PO_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PO_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PO_ITEM_COUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PO_TOTAL;
        private System.Windows.Forms.Label inv_total;
        private System.Windows.Forms.Label po_tot;
    }
}
