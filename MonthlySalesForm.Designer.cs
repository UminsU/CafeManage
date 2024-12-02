namespace WindowsFormsApp1
{
    partial class MonthlySalesForm
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
            this.textBox_totalsales = new System.Windows.Forms.TextBox();
            this.label_totaltxt = new System.Windows.Forms.Label();
            this.Search_Btn = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.listView_monthlysales = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // textBox_totalsales
            // 
            this.textBox_totalsales.Location = new System.Drawing.Point(130, 397);
            this.textBox_totalsales.Name = "textBox_totalsales";
            this.textBox_totalsales.Size = new System.Drawing.Size(198, 28);
            this.textBox_totalsales.TabIndex = 9;
            // 
            // label_totaltxt
            // 
            this.label_totaltxt.AutoSize = true;
            this.label_totaltxt.Location = new System.Drawing.Point(38, 400);
            this.label_totaltxt.Name = "label_totaltxt";
            this.label_totaltxt.Size = new System.Drawing.Size(86, 18);
            this.label_totaltxt.TabIndex = 8;
            this.label_totaltxt.Text = "총 매출액";
            // 
            // Search_Btn
            // 
            this.Search_Btn.Location = new System.Drawing.Point(244, 25);
            this.Search_Btn.Name = "Search_Btn";
            this.Search_Btn.Size = new System.Drawing.Size(84, 28);
            this.Search_Btn.TabIndex = 7;
            this.Search_Btn.Text = "검색";
            this.Search_Btn.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "yyyy/MM";
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(38, 25);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.ShowUpDown = true;
            this.dateTimePicker.Size = new System.Drawing.Size(200, 28);
            this.dateTimePicker.TabIndex = 6;
            // 
            // listView_monthlysales
            // 
            this.listView_monthlysales.HideSelection = false;
            this.listView_monthlysales.Location = new System.Drawing.Point(351, 25);
            this.listView_monthlysales.Name = "listView_monthlysales";
            this.listView_monthlysales.Size = new System.Drawing.Size(432, 393);
            this.listView_monthlysales.TabIndex = 5;
            this.listView_monthlysales.UseCompatibleStateImageBehavior = false;
            // 
            // MonthlySalesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 447);
            this.Controls.Add(this.textBox_totalsales);
            this.Controls.Add(this.label_totaltxt);
            this.Controls.Add(this.Search_Btn);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.listView_monthlysales);
            this.Name = "MonthlySalesForm";
            this.Text = "월 매출";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_totalsales;        //검색된 하루 총 매출액 표시하는 textbox
        private System.Windows.Forms.Label label_totaltxt;             //텍스트
        private System.Windows.Forms.Button Search_Btn;                //월 검색 버튼
        private System.Windows.Forms.DateTimePicker dateTimePicker;     //월 검색 입력
        private System.Windows.Forms.ListView listView_monthlysales;    //검색된 월 하루마다 총 결재금액 표시
    }
}