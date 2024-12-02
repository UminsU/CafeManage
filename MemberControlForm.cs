using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MemberControlForm : Form
    {
        // 회원 정보를 저장할 리스트
        private List<Member> members = new List<Member>();

        public MemberControlForm()
        {
            InitializeComponent();

            // 이벤트 핸들러 연결
            this.Load += MemberControlForm_Load;
            Appendmember_Btn.Click += Appendmember_Btn_Click;
            Deletemember_btn.Click += Deletemember_Btn_Click;
            Updatemember_Btn.Click += Updatemember_Btn_Click;
            Clear_memberinfoBtn.Click += Clear_memberinfoBtn_Click;
            Closeform_Btn.Click += Closeform_Btn_Click;
        }

        private void MemberControlForm_Load(object sender, EventArgs e)
        {
            // DataGridView 열 초기화
            InitializeDataGridViewColumns();

            // 데이터 로드
            LoadMemberData();
        }

        private void InitializeDataGridViewColumns()
        {
            // 열이 없을 경우에만 추가
            if (dataGridView_memberdata.Columns.Count == 0)
            {
                dataGridView_memberdata.Columns.Add("MemberID", "회원ID");
                dataGridView_memberdata.Columns.Add("Name", "이름");
                dataGridView_memberdata.Columns.Add("Phone", "전화번호");
                dataGridView_memberdata.Columns.Add("Gender", "성별");
                dataGridView_memberdata.Columns.Add("Address", "주소");
                dataGridView_memberdata.Columns.Add("JoinDate", "가입일");
            }
        }

        private void LoadMemberData()
        {
            // DataGridView 초기화
            dataGridView_memberdata.Rows.Clear();

            // List에 저장된 데이터를 DataGridView에 추가
            foreach (var member in members)
            {
                dataGridView_memberdata.Rows.Add(
                    member.MemberID,
                    member.Name,
                    member.Phone,
                    member.Gender,
                    member.Address,
                    member.JoinDate
                );
            }
        }

        private void Appendmember_Btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_memberName.Text) ||
                string.IsNullOrWhiteSpace(textBox_memberTel.Text) ||
                string.IsNullOrWhiteSpace(textBox_memberSex.Text) ||
                string.IsNullOrWhiteSpace(textBox_memberAddress.Text) ||
                string.IsNullOrWhiteSpace(textBox_memberJoindate.Text))
            {
                MessageBox.Show("모든 입력란을 채워주세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newMember = new Member
            {
                MemberID = textBox_memberID.Text,
                Name = textBox_memberName.Text,
                Phone = textBox_memberTel.Text,
                Gender = textBox_memberSex.Text,
                Address = textBox_memberAddress.Text,
                JoinDate = textBox_memberJoindate.Text
            };

            members.Add(newMember);

            // DataGridView에 추가
            dataGridView_memberdata.Rows.Add(
                newMember.MemberID,
                newMember.Name,
                newMember.Phone,
                newMember.Gender,
                newMember.Address,
                newMember.JoinDate
            );

            MessageBox.Show("회원이 추가되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearMemberInfoFields();
        }

        private void Deletemember_Btn_Click(object sender, EventArgs e)
        {
            if (dataGridView_memberdata.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView_memberdata.SelectedRows[0];
                string selectedMemberID = selectedRow.Cells["MemberID"].Value?.ToString();

                var memberToRemove = members.FirstOrDefault(m => m.MemberID == selectedMemberID);
                if (memberToRemove != null)
                {
                    members.Remove(memberToRemove);
                }

                dataGridView_memberdata.Rows.Remove(selectedRow);

                MessageBox.Show("선택된 회원이 삭제되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("삭제할 행을 선택하세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Updatemember_Btn_Click(object sender, EventArgs e)
        {
            if (dataGridView_memberdata.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView_memberdata.SelectedRows[0];
                string selectedMemberID = selectedRow.Cells["MemberID"].Value?.ToString();

                var memberToUpdate = members.FirstOrDefault(m => m.MemberID == selectedMemberID);
                if (memberToUpdate != null)
                {
                    memberToUpdate.Name = textBox_memberName.Text;
                    memberToUpdate.Phone = textBox_memberTel.Text;
                    memberToUpdate.Gender = textBox_memberSex.Text;
                    memberToUpdate.Address = textBox_memberAddress.Text;
                    memberToUpdate.JoinDate = textBox_memberJoindate.Text;

                    selectedRow.Cells["Name"].Value = memberToUpdate.Name;
                    selectedRow.Cells["Phone"].Value = memberToUpdate.Phone;
                    selectedRow.Cells["Gender"].Value = memberToUpdate.Gender;
                    selectedRow.Cells["Address"].Value = memberToUpdate.Address;
                    selectedRow.Cells["JoinDate"].Value = memberToUpdate.JoinDate;

                    MessageBox.Show("회원 정보가 수정되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("수정할 행을 선택하세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Clear_memberinfoBtn_Click(object sender, EventArgs e)
        {
            ClearMemberInfoFields();
        }

        private void Closeform_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearMemberInfoFields()
        {
            textBox_memberID.Clear();
            textBox_memberName.Clear();
            textBox_memberTel.Clear();
            textBox_memberSex.Clear();
            textBox_memberAddress.Clear();
            textBox_memberJoindate.Clear();
        }

        // Member 클래스 정의
        public class Member
        {
            public string MemberID { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }
            public string Gender { get; set; }
            public string Address { get; set; }
            public string JoinDate { get; set; }
        }
    }
}
