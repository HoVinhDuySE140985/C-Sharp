
namespace ASM_4
{
    partial class frmBookReport
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
            this.dgvBooksSort = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSort = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooksSort)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBooksSort
            // 
            this.dgvBooksSort.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBooksSort.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgvBooksSort.Location = new System.Drawing.Point(12, 12);
            this.dgvBooksSort.Name = "dgvBooksSort";
            this.dgvBooksSort.Size = new System.Drawing.Size(326, 290);
            this.dgvBooksSort.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "BookID";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "BookName";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "BookPrice";
            this.Column3.Name = "Column3";
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(358, 23);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(107, 23);
            this.btnSort.TabIndex = 1;
            this.btnSort.Text = "SortDesByPrice";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // frmBookReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 314);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.dgvBooksSort);
            this.Name = "frmBookReport";
            this.Text = "frmBookReport";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBookReport_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooksSort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBooksSort;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}