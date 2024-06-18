namespace argo.UI.UIContent
{
    partial class StockView
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
            this.stockListView = new System.Windows.Forms.DataGridView();
            this.category = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.item = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.stockListView)).BeginInit();
            this.SuspendLayout();
            // 
            // stockListView
            // 
            this.stockListView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.stockListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stockListView.Location = new System.Drawing.Point(47, 172);
            this.stockListView.Name = "stockListView";
            this.stockListView.Size = new System.Drawing.Size(1105, 391);
            this.stockListView.TabIndex = 0;
            // 
            // category
            // 
            this.category.Location = new System.Drawing.Point(162, 116);
            this.category.Name = "category";
            this.category.Size = new System.Drawing.Size(224, 27);
            this.category.TabIndex = 1;
            this.category.TextChanged += new System.EventHandler(this.category_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(63, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Category :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(471, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Item :";
            // 
            // item
            // 
            this.item.Location = new System.Drawing.Point(532, 116);
            this.item.Name = "item";
            this.item.Size = new System.Drawing.Size(224, 27);
            this.item.TabIndex = 4;
            this.item.TextChanged += new System.EventHandler(this.item_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label6.Location = new System.Drawing.Point(433, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(198, 30);
            this.label6.TabIndex = 31;
            this.label6.Text = "Available Stock";
            // 
            // StockView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.item);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.category);
            this.Controls.Add(this.stockListView);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "StockView";
            this.Size = new System.Drawing.Size(1191, 604);
            this.Load += new System.EventHandler(this.StockView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stockListView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView stockListView;
        private System.Windows.Forms.TextBox category;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox item;
        private System.Windows.Forms.Label label6;
    }
}
