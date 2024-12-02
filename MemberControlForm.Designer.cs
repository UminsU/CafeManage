namespace WindowsFormsApp1
{
    partial class MemberControlForm
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
            this.dataGridView_memberdata = new System.Windows.Forms.DataGridView();
            this.Closeform_Btn = new System.Windows.Forms.Button();
            this.label_MemberID = new System.Windows.Forms.Label();
            this.textBox_memberID = new System.Windows.Forms.TextBox();
            this.textBox_memberName = new System.Windows.Forms.TextBox();
            this.label_memberName = new System.Windows.Forms.Label();
            this.textBox_memberTel = new System.Windows.Forms.TextBox();
            this.label_memberPhone = new System.Windows.Forms.Label();
            this.textBox_memberSex = new System.Windows.Forms.TextBox();
            this.label_memberSex = new System.Windows.Forms.Label();
            this.textBox_memberAddress = new System.Windows.Forms.TextBox();
            this.label_memberAddress = new System.Windows.Forms.Label();
            this.textBox_memberJoindate = new System.Windows.Forms.TextBox();
            this.label_memberJoindate = new System.Windows.Forms.Label();
            this.groupBox_memberInfo = new System.Windows.Forms.GroupBox();
            this.Deletemember_btn = new System.Windows.Forms.Button();
            this.Updatemember_Btn = new System.Windows.Forms.Button();
            this.Clear_memberinfoBtn = new System.Windows.Forms.Button();
            this.Appendmember_Btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_memberdata)).BeginInit();
            this.groupBox_memberInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_memberdata
            // 
            this.dataGridView_memberdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_memberdata.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_memberdata.Name = "dataGridView_memberdata";
            this.dataGridView_memberdata.RowHeadersWidth = 62;
            this.dataGridView_memberdata.RowTemplate.Height = 30;
            this.dataGridView_memberdata.Size = new System.Drawing.Size(693, 464);
            this.dataGridView_memberdata.TabIndex = 0;
            // 
            // Closeform_Btn
            // 
            this.Closeform_Btn.Location = new System.Drawing.Point(12, 493);
            this.Closeform_Btn.Name = "Closeform_Btn";
            this.Closeform_Btn.Size = new System.Drawing.Size(95, 38);
            this.Closeform_Btn.TabIndex = 1;
            this.Closeform_Btn.Text = "닫기";
            this.Closeform_Btn.UseVisualStyleBackColor = true;
            // 
            // label_MemberID
            // 
            this.label_MemberID.AutoSize = true;
            this.label_MemberID.Location = new System.Drawing.Point(23, 30);
            this.label_MemberID.Name = "label_MemberID";
            this.label_MemberID.Size = new System.Drawing.Size(58, 18);
            this.label_MemberID.TabIndex = 2;
            this.label_MemberID.Text = "회원ID";
            // 
            // textBox_memberID
            // 
            this.textBox_memberID.Location = new System.Drawing.Point(83, 27);
            this.textBox_memberID.Name = "textBox_memberID";
            this.textBox_memberID.Size = new System.Drawing.Size(152, 28);
            this.textBox_memberID.TabIndex = 3;
            // 
            // textBox_memberName
            // 
            this.textBox_memberName.Location = new System.Drawing.Point(83, 81);
            this.textBox_memberName.Name = "textBox_memberName";
            this.textBox_memberName.Size = new System.Drawing.Size(152, 28);
            this.textBox_memberName.TabIndex = 5;
            // 
            // label_memberName
            // 
            this.label_memberName.AutoSize = true;
            this.label_memberName.Location = new System.Drawing.Point(23, 84);
            this.label_memberName.Name = "label_memberName";
            this.label_memberName.Size = new System.Drawing.Size(44, 18);
            this.label_memberName.TabIndex = 4;
            this.label_memberName.Text = "이름";
            // 
            // textBox_memberTel
            // 
            this.textBox_memberTel.Location = new System.Drawing.Point(83, 135);
            this.textBox_memberTel.Name = "textBox_memberTel";
            this.textBox_memberTel.Size = new System.Drawing.Size(152, 28);
            this.textBox_memberTel.TabIndex = 7;
            // 
            // label_memberPhone
            // 
            this.label_memberPhone.AutoSize = true;
            this.label_memberPhone.Location = new System.Drawing.Point(23, 138);
            this.label_memberPhone.Name = "label_memberPhone";
            this.label_memberPhone.Size = new System.Drawing.Size(60, 18);
            this.label_memberPhone.TabIndex = 6;
            this.label_memberPhone.Text = "Phone";
            // 
            // textBox_memberSex
            // 
            this.textBox_memberSex.Location = new System.Drawing.Point(83, 189);
            this.textBox_memberSex.Name = "textBox_memberSex";
            this.textBox_memberSex.Size = new System.Drawing.Size(152, 28);
            this.textBox_memberSex.TabIndex = 9;
            // 
            // label_memberSex
            // 
            this.label_memberSex.AutoSize = true;
            this.label_memberSex.Location = new System.Drawing.Point(23, 192);
            this.label_memberSex.Name = "label_memberSex";
            this.label_memberSex.Size = new System.Drawing.Size(44, 18);
            this.label_memberSex.TabIndex = 8;
            this.label_memberSex.Text = "성별";
            // 
            // textBox_memberAddress
            // 
            this.textBox_memberAddress.Location = new System.Drawing.Point(83, 243);
            this.textBox_memberAddress.Name = "textBox_memberAddress";
            this.textBox_memberAddress.Size = new System.Drawing.Size(152, 28);
            this.textBox_memberAddress.TabIndex = 11;
            // 
            // label_memberAddress
            // 
            this.label_memberAddress.AutoSize = true;
            this.label_memberAddress.Location = new System.Drawing.Point(23, 246);
            this.label_memberAddress.Name = "label_memberAddress";
            this.label_memberAddress.Size = new System.Drawing.Size(44, 18);
            this.label_memberAddress.TabIndex = 10;
            this.label_memberAddress.Text = "주소";
            // 
            // textBox_memberJoindate
            // 
            this.textBox_memberJoindate.Location = new System.Drawing.Point(83, 297);
            this.textBox_memberJoindate.Name = "textBox_memberJoindate";
            this.textBox_memberJoindate.Size = new System.Drawing.Size(152, 28);
            this.textBox_memberJoindate.TabIndex = 13;
            // 
            // label_memberJoindate
            // 
            this.label_memberJoindate.AutoSize = true;
            this.label_memberJoindate.Location = new System.Drawing.Point(23, 300);
            this.label_memberJoindate.Name = "label_memberJoindate";
            this.label_memberJoindate.Size = new System.Drawing.Size(62, 18);
            this.label_memberJoindate.TabIndex = 12;
            this.label_memberJoindate.Text = "가입일";
            // 
            // groupBox_memberInfo
            // 
            this.groupBox_memberInfo.Controls.Add(this.Deletemember_btn);
            this.groupBox_memberInfo.Controls.Add(this.Updatemember_Btn);
            this.groupBox_memberInfo.Controls.Add(this.Clear_memberinfoBtn);
            this.groupBox_memberInfo.Controls.Add(this.Appendmember_Btn);
            this.groupBox_memberInfo.Controls.Add(this.textBox_memberID);
            this.groupBox_memberInfo.Controls.Add(this.textBox_memberJoindate);
            this.groupBox_memberInfo.Controls.Add(this.label_MemberID);
            this.groupBox_memberInfo.Controls.Add(this.label_memberJoindate);
            this.groupBox_memberInfo.Controls.Add(this.label_memberName);
            this.groupBox_memberInfo.Controls.Add(this.textBox_memberAddress);
            this.groupBox_memberInfo.Controls.Add(this.textBox_memberName);
            this.groupBox_memberInfo.Controls.Add(this.label_memberAddress);
            this.groupBox_memberInfo.Controls.Add(this.label_memberPhone);
            this.groupBox_memberInfo.Controls.Add(this.textBox_memberSex);
            this.groupBox_memberInfo.Controls.Add(this.textBox_memberTel);
            this.groupBox_memberInfo.Controls.Add(this.label_memberSex);
            this.groupBox_memberInfo.Location = new System.Drawing.Point(711, 12);
            this.groupBox_memberInfo.Name = "groupBox_memberInfo";
            this.groupBox_memberInfo.Size = new System.Drawing.Size(398, 464);
            this.groupBox_memberInfo.TabIndex = 14;
            this.groupBox_memberInfo.TabStop = false;
            this.groupBox_memberInfo.Text = "회원정보";
            // 
            // Deletemember_btn
            // 
            this.Deletemember_btn.Location = new System.Drawing.Point(228, 338);
            this.Deletemember_btn.Name = "Deletemember_btn";
            this.Deletemember_btn.Size = new System.Drawing.Size(95, 38);
            this.Deletemember_btn.TabIndex = 18;
            this.Deletemember_btn.Text = "삭제";
            this.Deletemember_btn.UseVisualStyleBackColor = true;
            // 
            // Updatemember_Btn
            // 
            this.Updatemember_Btn.Location = new System.Drawing.Point(127, 338);
            this.Updatemember_Btn.Name = "Updatemember_Btn";
            this.Updatemember_Btn.Size = new System.Drawing.Size(95, 38);
            this.Updatemember_Btn.TabIndex = 17;
            this.Updatemember_Btn.Text = "수정";
            this.Updatemember_Btn.UseVisualStyleBackColor = true;
            // 
            // Clear_memberinfoBtn
            // 
            this.Clear_memberinfoBtn.Location = new System.Drawing.Point(26, 407);
            this.Clear_memberinfoBtn.Name = "Clear_memberinfoBtn";
            this.Clear_memberinfoBtn.Size = new System.Drawing.Size(95, 38);
            this.Clear_memberinfoBtn.TabIndex = 16;
            this.Clear_memberinfoBtn.Text = "초기화";
            this.Clear_memberinfoBtn.UseVisualStyleBackColor = true;
            // 
            // Appendmember_Btn
            // 
            this.Appendmember_Btn.Location = new System.Drawing.Point(26, 338);
            this.Appendmember_Btn.Name = "Appendmember_Btn";
            this.Appendmember_Btn.Size = new System.Drawing.Size(95, 38);
            this.Appendmember_Btn.TabIndex = 15;
            this.Appendmember_Btn.Text = "추가";
            this.Appendmember_Btn.UseVisualStyleBackColor = true;
            // 
            // MemberControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 543);
            this.Controls.Add(this.groupBox_memberInfo);
            this.Controls.Add(this.Closeform_Btn);
            this.Controls.Add(this.dataGridView_memberdata);
            this.Name = "MemberControlForm";
            this.Text = "회원관리";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_memberdata)).EndInit();
            this.groupBox_memberInfo.ResumeLayout(false);
            this.groupBox_memberInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_memberdata; // 전체회원정보 보는 데이터그리드뷰(회원 테이블 활용)
        private System.Windows.Forms.Button Closeform_Btn;          // 회원관리 폼 닫기
        private System.Windows.Forms.Label label_MemberID;          //텍스트
        private System.Windows.Forms.TextBox textBox_memberID;      //dataGridView_memberdata에서 선택된 회원ID 정보 띄우는 textbox
        private System.Windows.Forms.TextBox textBox_memberName;    //dataGridView_memberdata에서 선택된 회원이름 정보 띄우는 textbox
        private System.Windows.Forms.Label label_memberName;        //텍스트
        private System.Windows.Forms.TextBox textBox_memberTel;     //dataGridView_memberdata에서 선택된 회원전화번호 정보 띄우는 textbox
        private System.Windows.Forms.Label label_memberPhone;       //텍스트
        private System.Windows.Forms.TextBox textBox_memberSex;     //dataGridView_memberdata에서 선택된 회원성별 정보 띄우는 textbox
        private System.Windows.Forms.Label label_memberSex;         //텍스트
        private System.Windows.Forms.TextBox textBox_memberAddress; //dataGridView_memberdata에서 선택된 회원주소 정보 띄우는 textbox
        private System.Windows.Forms.Label label_memberAddress;     //텍스트
        private System.Windows.Forms.TextBox textBox_memberJoindate; //dataGridView_memberdata에서 선택된 회원가입일 정보 띄우는 textbox
        private System.Windows.Forms.Label label_memberJoindate;    //텍스트
        private System.Windows.Forms.GroupBox groupBox_memberInfo; //dataGridView_memberdata에서 선택된 회원정보 띄우는 textbox 몰아둔 groupbox
        private System.Windows.Forms.Button Appendmember_Btn;       //groupBox_memberInfo의 textbox 정보 토대로 회원정보 추가 버튼
        private System.Windows.Forms.Button Clear_memberinfoBtn;    //groupBox_memberInfo의 전체 textbox 초기화 버튼
        private System.Windows.Forms.Button Deletemember_btn;       //dataGridView_memberdata에서 선택된 row(회원정보) 삭제 버튼
        private System.Windows.Forms.Button Updatemember_Btn;       //groupBox_memberInfo의 textbox 정보 토대로 회원정보 수정 버튼
    }
}