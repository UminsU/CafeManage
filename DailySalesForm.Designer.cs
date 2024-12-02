namespace WindowsFormsApp1
{
    partial class DailySalesForm
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
            this.listView_Dailysales = new System.Windows.Forms.ListView();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.Search_Btn = new System.Windows.Forms.Button();
            this.label_totaltxt = new System.Windows.Forms.Label();
            this.textBox_totalsales = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listView_Dailysales
            // 
            this.listView_Dailysales.HideSelection = false;
            this.listView_Dailysales.Location = new System.Drawing.Point(325, 12);
            this.listView_Dailysales.Name = "listView_Dailysales";
            this.listView_Dailysales.Size = new System.Drawing.Size(432, 393);
            this.listView_Dailysales.TabIndex = 0;
            this.listView_Dailysales.UseCompatibleStateImageBehavior = false;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(12, 12);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 28);
            this.dateTimePicker.TabIndex = 1;
            // 
            // Search_Btn
            // 
            this.Search_Btn.Location = new System.Drawing.Point(218, 12);
            this.Search_Btn.Name = "Search_Btn";
            this.Search_Btn.Size = new System.Drawing.Size(84, 28);
            this.Search_Btn.TabIndex = 2;
            this.Search_Btn.Text = "검색";
            this.Search_Btn.UseVisualStyleBackColor = true;
            // 
            // label_totaltxt
            // 
            this.label_totaltxt.AutoSize = true;
            this.label_totaltxt.Location = new System.Drawing.Point(12, 387);
            this.label_totaltxt.Name = "label_totaltxt";
            this.label_totaltxt.Size = new System.Drawing.Size(86, 18);
            this.label_totaltxt.TabIndex = 3;
            this.label_totaltxt.Text = "총 매출액";
            // 
            // textBox_totalsales
            // 
            this.textBox_totalsales.Location = new System.Drawing.Point(104, 384);
            this.textBox_totalsales.Name = "textBox_totalsales";
            this.textBox_totalsales.Size = new System.Drawing.Size(198, 28);
            this.textBox_totalsales.TabIndex = 4;
            // 
            // DailySalesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox_totalsales);
            this.Controls.Add(this.label_totaltxt);
            this.Controls.Add(this.Search_Btn);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.listView_Dailysales);
            this.Name = "DailySalesForm";
            this.Text = "일 매출";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView_Dailysales;   //검색된 하루 결재내역 표시
        private System.Windows.Forms.DateTimePicker dateTimePicker;  //검색하기 위한 날짜선택
        private System.Windows.Forms.Button Search_Btn;             //날짜 검색 버튼
        private System.Windows.Forms.Label label_totaltxt;          //텍스트
        private System.Windows.Forms.TextBox textBox_totalsales;    //검색된 하루 총 매출액 표시하는 textbox
    }
}