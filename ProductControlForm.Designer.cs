namespace WindowsFormsApp1
{
    partial class ProductControlForm
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
            this.groupBox_ProductInfo = new System.Windows.Forms.GroupBox();
            this.DeleteProduct_btn = new System.Windows.Forms.Button();
            this.UpdateProduct_Btn = new System.Windows.Forms.Button();
            this.Clear_ProductinfoBtn = new System.Windows.Forms.Button();
            this.AppendProduct_Btn = new System.Windows.Forms.Button();
            this.textBox_memberID = new System.Windows.Forms.TextBox();
            this.label_ProductID = new System.Windows.Forms.Label();
            this.label_ProductName = new System.Windows.Forms.Label();
            this.textBox_ProductName = new System.Windows.Forms.TextBox();
            this.label_ProductRegistdate = new System.Windows.Forms.Label();
            this.textBox_ProductRegistdate = new System.Windows.Forms.TextBox();
            this.dataGridView_Productcontrol = new System.Windows.Forms.DataGridView();
            this.groupBox_ProductInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Productcontrol)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_ProductInfo
            // 
            this.groupBox_ProductInfo.Controls.Add(this.DeleteProduct_btn);
            this.groupBox_ProductInfo.Controls.Add(this.UpdateProduct_Btn);
            this.groupBox_ProductInfo.Controls.Add(this.Clear_ProductinfoBtn);
            this.groupBox_ProductInfo.Controls.Add(this.AppendProduct_Btn);
            this.groupBox_ProductInfo.Controls.Add(this.textBox_memberID);
            this.groupBox_ProductInfo.Controls.Add(this.label_ProductID);
            this.groupBox_ProductInfo.Controls.Add(this.label_ProductName);
            this.groupBox_ProductInfo.Controls.Add(this.textBox_ProductName);
            this.groupBox_ProductInfo.Controls.Add(this.label_ProductRegistdate);
            this.groupBox_ProductInfo.Controls.Add(this.textBox_ProductRegistdate);
            this.groupBox_ProductInfo.Location = new System.Drawing.Point(624, 12);
            this.groupBox_ProductInfo.Name = "groupBox_ProductInfo";
            this.groupBox_ProductInfo.Size = new System.Drawing.Size(398, 375);
            this.groupBox_ProductInfo.TabIndex = 17;
            this.groupBox_ProductInfo.TabStop = false;
            this.groupBox_ProductInfo.Text = "상품정보";
            // 
            // DeleteProduct_btn
            // 
            this.DeleteProduct_btn.Location = new System.Drawing.Point(252, 227);
            this.DeleteProduct_btn.Name = "DeleteProduct_btn";
            this.DeleteProduct_btn.Size = new System.Drawing.Size(95, 38);
            this.DeleteProduct_btn.TabIndex = 18;
            this.DeleteProduct_btn.Text = "삭제";
            this.DeleteProduct_btn.UseVisualStyleBackColor = true;
            // 
            // UpdateProduct_Btn
            // 
            this.UpdateProduct_Btn.Location = new System.Drawing.Point(151, 227);
            this.UpdateProduct_Btn.Name = "UpdateProduct_Btn";
            this.UpdateProduct_Btn.Size = new System.Drawing.Size(95, 38);
            this.UpdateProduct_Btn.TabIndex = 17;
            this.UpdateProduct_Btn.Text = "수정";
            this.UpdateProduct_Btn.UseVisualStyleBackColor = true;
            // 
            // Clear_ProductinfoBtn
            // 
            this.Clear_ProductinfoBtn.Location = new System.Drawing.Point(50, 296);
            this.Clear_ProductinfoBtn.Name = "Clear_ProductinfoBtn";
            this.Clear_ProductinfoBtn.Size = new System.Drawing.Size(95, 38);
            this.Clear_ProductinfoBtn.TabIndex = 16;
            this.Clear_ProductinfoBtn.Text = "초기화";
            this.Clear_ProductinfoBtn.UseVisualStyleBackColor = true;
            // 
            // AppendProduct_Btn
            // 
            this.AppendProduct_Btn.Location = new System.Drawing.Point(50, 227);
            this.AppendProduct_Btn.Name = "AppendProduct_Btn";
            this.AppendProduct_Btn.Size = new System.Drawing.Size(95, 38);
            this.AppendProduct_Btn.TabIndex = 15;
            this.AppendProduct_Btn.Text = "추가";
            this.AppendProduct_Btn.UseVisualStyleBackColor = true;
            // 
            // textBox_memberID
            // 
            this.textBox_memberID.Location = new System.Drawing.Point(161, 60);
            this.textBox_memberID.Name = "textBox_memberID";
            this.textBox_memberID.Size = new System.Drawing.Size(152, 28);
            this.textBox_memberID.TabIndex = 3;
            // 
            // label_ProductID
            // 
            this.label_ProductID.AutoSize = true;
            this.label_ProductID.Location = new System.Drawing.Point(57, 63);
            this.label_ProductID.Name = "label_ProductID";
            this.label_ProductID.Size = new System.Drawing.Size(58, 18);
            this.label_ProductID.TabIndex = 2;
            this.label_ProductID.Text = "상품ID";
            // 
            // label_ProductName
            // 
            this.label_ProductName.AutoSize = true;
            this.label_ProductName.Location = new System.Drawing.Point(57, 117);
            this.label_ProductName.Name = "label_ProductName";
            this.label_ProductName.Size = new System.Drawing.Size(62, 18);
            this.label_ProductName.TabIndex = 4;
            this.label_ProductName.Text = "상품명";
            // 
            // textBox_ProductName
            // 
            this.textBox_ProductName.Location = new System.Drawing.Point(161, 114);
            this.textBox_ProductName.Name = "textBox_ProductName";
            this.textBox_ProductName.Size = new System.Drawing.Size(152, 28);
            this.textBox_ProductName.TabIndex = 5;
            // 
            // label_ProductRegistdate
            // 
            this.label_ProductRegistdate.AutoSize = true;
            this.label_ProductRegistdate.Location = new System.Drawing.Point(57, 171);
            this.label_ProductRegistdate.Name = "label_ProductRegistdate";
            this.label_ProductRegistdate.Size = new System.Drawing.Size(98, 18);
            this.label_ProductRegistdate.TabIndex = 6;
            this.label_ProductRegistdate.Text = "상품등록일";
            // 
            // textBox_ProductRegistdate
            // 
            this.textBox_ProductRegistdate.Location = new System.Drawing.Point(161, 168);
            this.textBox_ProductRegistdate.Name = "textBox_ProductRegistdate";
            this.textBox_ProductRegistdate.Size = new System.Drawing.Size(152, 28);
            this.textBox_ProductRegistdate.TabIndex = 7;
            // 
            // dataGridView_Productcontrol
            // 
            this.dataGridView_Productcontrol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Productcontrol.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_Productcontrol.Name = "dataGridView_Productcontrol";
            this.dataGridView_Productcontrol.RowHeadersWidth = 62;
            this.dataGridView_Productcontrol.RowTemplate.Height = 30;
            this.dataGridView_Productcontrol.Size = new System.Drawing.Size(606, 375);
            this.dataGridView_Productcontrol.TabIndex = 18;
            // 
            // ProductControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 407);
            this.Controls.Add(this.dataGridView_Productcontrol);
            this.Controls.Add(this.groupBox_ProductInfo);
            this.Name = "ProductControlForm";
            this.Text = "상품관리";
            this.groupBox_ProductInfo.ResumeLayout(false);
            this.groupBox_ProductInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Productcontrol)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_ProductInfo; //상품정보 몰아둔 groupbox
        private System.Windows.Forms.Button DeleteProduct_btn;      //dataGridView_Productcontrol에서 선택된 상품정보 삭제 버튼
        private System.Windows.Forms.Button UpdateProduct_Btn;      //groupBox_ProductInfo의 정보를 토대로 해당 row 수정 버튼
        private System.Windows.Forms.Button Clear_ProductinfoBtn;   //groupBox_ProductInfo textbox 클리어 버튼
        private System.Windows.Forms.Button AppendProduct_Btn;      //groupBox_ProductInfo의 정보를 토대로 새로운 row 추가 버튼
        private System.Windows.Forms.TextBox textBox_memberID;      //dataGridView_Productcontrol에서 선택된 상품의 id 표시 및 수정
        private System.Windows.Forms.Label label_ProductID;         //텍스트
        private System.Windows.Forms.Label label_ProductName;       //텍스트
        private System.Windows.Forms.TextBox textBox_ProductName;    //dataGridView_Productcontrol에서 선택된 상품의 이름 표시 및 수정
        private System.Windows.Forms.Label label_ProductRegistdate; //텍스트
        private System.Windows.Forms.TextBox textBox_ProductRegistdate;//dataGridView_Productcontrol에서 선택된 상품의 등록일 표시 및 수정
        private System.Windows.Forms.DataGridView dataGridView_Productcontrol;//상품 테이블 데이터 표시
    }
}