using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ShowOrderForm : Form
    {
        // 주문 정보를 저장할 리스트
        private List<Order> orders = new List<Order>();

        public ShowOrderForm()
        {
            InitializeComponent();
            InitializeDataGridView();
            Delete_Btn.Click += Delete_Btn_Click; // 삭제 버튼 이벤트 연결
            
        }

        private void InitializeDataGridView()
        {
            if (dataGridView_showOrders == null)
            {
                MessageBox.Show("dataGridView_showOrders가 초기화되지 않았습니다.");
                return;
            }

            dataGridView_showOrders.Columns.Clear();
            dataGridView_showOrders.Columns.Add("ProductName", "상품명");
            dataGridView_showOrders.Columns.Add("Quantity", "수량");
            dataGridView_showOrders.Columns.Add("OrderDate", "주문 시간");

            dataGridView_showOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    
    // 주문 추가 메서드
    public void AddOrder(List<Order> newOrders)
        {
            if (newOrders == null || newOrders.Count == 0)
            {
                MessageBox.Show("추가할 주문이 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            orders.AddRange(newOrders); // 새로운 주문 추가
            UpdateOrderGrid(); // DataGridView 업데이트
        }

        // DataGridView 업데이트
        private void UpdateOrderGrid()
        {
            dataGridView_showOrders.Rows.Clear();

            foreach (var order in orders)
            {
                dataGridView_showOrders.Rows.Add(
                    order.ProductName,
                    order.Quantity,
                    order.TotalPrice, // 주문 가격
                    order.OrderDate.ToString("yyyy-MM-dd HH:mm:ss") // 날짜 출력
                );
            }
        }

        // 선택된 주문 삭제
        private void Delete_Btn_Click(object sender, EventArgs e)
        {
            if (dataGridView_showOrders.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView_showOrders.SelectedRows[0];
                string productName = selectedRow.Cells[0].Value?.ToString();
                int quantity = int.Parse(selectedRow.Cells[1].Value?.ToString() ?? "0");

                var orderToRemove = orders.FirstOrDefault(o =>
                    o.ProductName == productName &&
                    o.Quantity == quantity);

                if (orderToRemove != null)
                {
                    orders.Remove(orderToRemove);
                }

                dataGridView_showOrders.Rows.Remove(selectedRow);
                MessageBox.Show("선택된 주문이 삭제되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("삭제할 주문을 선택하세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 모든 주문 삭제
        private void ClearAll_Btn_Click(object sender, EventArgs e)
        {
            if (orders.Count > 0)
            {
                var result = MessageBox.Show(
                    "모든 주문을 삭제하시겠습니까?",
                    "확인",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    orders.Clear();
                    UpdateOrderGrid();
                    MessageBox.Show("모든 주문이 삭제되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("삭제할 주문이 없습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }

    // 주문 클래스 정의
    public class Order
    {
        public string ProductName { get; set; }  // 주문 상품 이름
        public int Quantity { get; set; }        // 주문 수량
        public int TotalPrice { get; set; }      // 총 가격
        public DateTime OrderDate { get; set; }  // 주문 날짜
    }
}
