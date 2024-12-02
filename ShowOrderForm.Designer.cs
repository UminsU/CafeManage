namespace WindowsFormsApp1
{
    partial class ShowOrderForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dataGridView_showOrders = new System.Windows.Forms.DataGridView();
            this.Delete_Btn = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_showOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_showOrders
            // 
            this.dataGridView_showOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_showOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dataGridView_showOrders.Location = new System.Drawing.Point(8, 8);
            this.dataGridView_showOrders.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView_showOrders.Name = "dataGridView_showOrders";
            this.dataGridView_showOrders.RowHeadersWidth = 62;
            this.dataGridView_showOrders.RowTemplate.Height = 30;
            this.dataGridView_showOrders.Size = new System.Drawing.Size(558, 257);
            this.dataGridView_showOrders.TabIndex = 0;
            // 
            // Delete_Btn
            // 
            this.Delete_Btn.Location = new System.Drawing.Point(8, 269);
            this.Delete_Btn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Delete_Btn.Name = "Delete_Btn";
            this.Delete_Btn.Size = new System.Drawing.Size(65, 26);
            this.Delete_Btn.TabIndex = 1;
            this.Delete_Btn.Text = "삭제";
            this.Delete_Btn.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "상품 이름";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "수량";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "주문 날짜";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // ShowOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 303);
            this.Controls.Add(this.Delete_Btn);
            this.Controls.Add(this.dataGridView_showOrders);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ShowOrderForm";
            this.Text = "주문현황";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_showOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_showOrders;
        private System.Windows.Forms.Button Delete_Btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}
