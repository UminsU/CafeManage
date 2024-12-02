using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace WindowsFormsApp1
{
    public partial class Main_Form : Form
    {
        ORDER ord = new ORDER();
        STOCK sto = new STOCK();
        SALES sal = new SALES();

        int membercount = 0, forcount = 0, stockcount = 0; // 회원 검색 버튼 카운터, 회원 검색시 포문 카운터, 재고 검색 버튼 카운터
        Int32 Salesday = 0, Salesmuney = 0; // 매출 달력 날짜 누르면 이제 해당 날짜랑 그날 매출이 저장되는 변수
        int cash = 0; // 총 받을 금액
        int stockErrorcount = 0; // 재고부족한거 카운트하는거
        string SName, STell, Sbirthday, Stockname, Stockcount, Stocknote; // 회원 정보 수정, 재고 수정 에 사용되는 변수들 수정 이전 내용을 저장해놈 
        string memberfile = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=member.mdb";
        string stockfile = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=stock.mdb";
        string salesfile = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = sales.mdb";
     

        OleDbConnection memberconn;
        OleDbCommand membercomm;

        OleDbConnection stockconn;
        OleDbCommand stockcomm;

        OleDbConnection salesconn;
        OleDbCommand salescomm;

        public int openclosecount // 로그인 폼에서 openclosecount 값 전달받는곳, 즉 로그인폼에서 메인폼으로 값 전달
        {
            set; get;
        }

        private ShowOrderForm showOrderForm = new ShowOrderForm(); // 주문 현황 폼
        private System.Windows.Forms.DataGridView dataGridView_showOrders;
        public Main_Form()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
           
            //dataGridView_showOrders.Columns.Clear();
            //dataGridView_showOrders.Columns.Add("ProductName", "상품명");
            //dataGridView_showOrders.Columns.Add("Quantity", "수량");
           // dataGridView_showOrders.Columns.Add("OrderDate", "주문 시간");

            //dataGridView_showOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ------------------------------------------------------------------주문 관리-----------------------------------------------------------------------------

       

        private void button_order_Click(object sender, EventArgs e) // 주문관리 버튼
        {
            groupBox_order.Visible = !groupBox_order.Visible;
            groupBox_member.Visible = false;
            groupBox_stock.Visible = false;
            groupBox_sales.Visible = false;
        }
        private void AddToOrder(string productName, int price)
        {
            // 주문 항목이 이미 있는지 확인
            var existingOrder = currentOrders.Find(o => o.ProductName == productName);

            if (existingOrder != null)
            {
                // 기존 주문 수량 증가 및 총액 계산
                existingOrder.Quantity++;
                existingOrder.TotalPrice += price;

                // DataGridView 업데이트
                foreach (DataGridViewRow row in dataGridView_showOrders.Rows)
                {
                    if (row.Cells[0].Value.ToString() == productName)
                    {
                        row.Cells[1].Value = existingOrder.Quantity;
                        row.Cells[2].Value = existingOrder.TotalPrice;
                        break;
                    }
                }
            }
            else
            {
                // 새로운 주문 추가
                var newOrder = new Order
                {
                    ProductName = productName,
                    Quantity = 1,
                    TotalPrice = price,
                    OrderDate = DateTime.Now
                };

                currentOrders.Add(newOrder);

                // DataGridView에 새 항목 추가
                dataGridView_showOrders.Rows.Add(productName, newOrder.Quantity, newOrder.TotalPrice, newOrder.OrderDate.ToString("yyyy-MM-dd HH:mm:ss"));
            }

            UpdateSummary();
        }

        private void UpdateSummary()
        {
            // 주문 요약 정보 갱신
            int totalQuantity = 0;
            int totalPrice = 0;

            foreach (var order in currentOrders)
            {
                totalQuantity += order.Quantity;
                totalPrice += order.TotalPrice;
            }

            textBox_sumnumber.Text = totalQuantity.ToString();
            textBox_sumcash.Text = totalPrice.ToString();
        }


        private List<Order> currentOrders = new List<Order>(); // 현재 주문 목록 관리

          private void button_Americano_Click(object sender, EventArgs e)// 아메리카노 hot 버튼 누르면 리스트뷰에 뜨게하는거
        {
            int count = listView_order.Items.Count; // 리스트뷰 항목 수 반환
            if (ord.americanohcount >= 2)
            {
                for (int i = 0; i < count; i++) // 리스트 뷰 내에서 검색하는 포문
                {
                    if (listView_order.Items[i].SubItems[0].Text == button_Americanoh.Text) // 리스트 뷰에 해당 버튼의 텍스트가 있으면
                    {
                        listView_order.Items[i].Focused = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.Items[i].Selected = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.FocusedItem.SubItems[0].Text = button_Americanoh.Text; // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.americanohcount); // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.AmericanohSum()); // 포커스된 부분에 내용 덮어쓰는거
                        ord.americanohcount++;
                        listView_order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var coffee = new string[] { this.button_Americanoh.Text, Convert.ToString(ord.americanohcount), Convert.ToString(ord.AmericanohSum()) };
                var lvt = new ListViewItem(coffee);
                this.listView_order.Items.Add(lvt);
                listView_order.Focus();
                ord.americanohcount++;
            }
            textBox_sumnumber.Text = Convert.ToString(ord.SumNumber());
            textBox_sumcash.Text = Convert.ToString(ord.SumCash());
        }

        private void button_Americanoi_Click(object sender, EventArgs e)// 아메리카노 ice 버튼 누르면 리스트 뷰에 뜨게하는거
        {
            int count = listView_order.Items.Count; // 리스트뷰 항목 수 반환
            if (ord.americanoicount >= 2)
            {
                for (int i = 0; i < count; i++) // 리스트 뷰 내에서 검색하는 포문
                {
                    if (listView_order.Items[i].SubItems[0].Text == button_Americanoi.Text)
                    {
                        listView_order.Items[i].Focused = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.Items[i].Selected = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.FocusedItem.SubItems[0].Text = button_Americanoi.Text; // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.americanoicount); // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.AmericanoiSum()); // 포커스된 부분에 내용 덮어쓰는거
                        ord.americanoicount++;
                        listView_order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var coffee = new string[] { this.button_Americanoi.Text, Convert.ToString(ord.americanoicount), Convert.ToString(ord.AmericanoiSum()) };
                var lvt = new ListViewItem(coffee);
                this.listView_order.Items.Add(lvt);
                listView_order.Focus();
                ord.americanoicount++;
            }
            textBox_sumnumber.Text = Convert.ToString(ord.SumNumber());
            textBox_sumcash.Text = Convert.ToString(ord.SumCash());
        }

        private void button_Cafelatteh_Click(object sender, EventArgs e)// 카페라떼 hot 버튼 누르면 리스트뷰에 뜨게하는거
        {
            int count = listView_order.Items.Count; // 리스트뷰 항목 수 반환
            if (ord.cafelattehcount >= 2)
            {
                for (int i = 0; i < count; i++) // 리스트 뷰 내에서 검색하는 포문
                {
                    if (listView_order.Items[i].SubItems[0].Text == button_Cafelatteh.Text)

                    {
                        listView_order.Items[i].Focused = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.Items[i].Selected = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.FocusedItem.SubItems[0].Text = button_Cafelatteh.Text; // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.cafelattehcount); // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.CafelattehSum()); // 포커스된 부분에 내용 덮어쓰는거
                        ord.cafelattehcount++;
                        listView_order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var coffee = new string[] { this.button_Cafelatteh.Text, Convert.ToString(ord.cafelattehcount), Convert.ToString(ord.CafelattehSum()) };
                var lvt = new ListViewItem(coffee);
                this.listView_order.Items.Add(lvt);
                listView_order.Focus();
                ord.cafelattehcount++;
            }
            textBox_sumnumber.Text = Convert.ToString(ord.SumNumber());
            textBox_sumcash.Text = Convert.ToString(ord.SumCash());
        }

        private void button_Cafelattei_Click(object sender, EventArgs e)// 카페라떼 ice 버튼 누르면 리스트뷰에 뜨게하는거
        {
            int count = listView_order.Items.Count; // 리스트뷰 항목 수 반환
            if (ord.cafelatteicount >= 2)
            {
                for (int i = 0; i < count; i++) // 리스트 뷰 내에서 검색하는 포문
                {
                    if (listView_order.Items[i].SubItems[0].Text == button_Cafelattei.Text)

                    {
                        listView_order.Items[i].Focused = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.Items[i].Selected = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.FocusedItem.SubItems[0].Text = button_Cafelattei.Text; // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.cafelatteicount); // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.CafelatteiSum()); // 포커스된 부분에 내용 덮어쓰는거
                        ord.cafelatteicount++;
                        listView_order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var coffee = new string[] { this.button_Cafelattei.Text, Convert.ToString(ord.cafelatteicount), Convert.ToString(ord.CafelatteiSum()) };
                var lvt = new ListViewItem(coffee);
                this.listView_order.Items.Add(lvt);
                listView_order.Focus();
                ord.cafelatteicount++;
            }
            textBox_sumnumber.Text = Convert.ToString(ord.SumNumber());
            textBox_sumcash.Text = Convert.ToString(ord.SumCash());
        }

        private void button_Cappuccinoh_Click(object sender, EventArgs e)// 카푸치노 hot 버튼 누르면 리스트뷰에 뜨게하는거
        {
            int count = listView_order.Items.Count; // 리스트뷰 항목 수 반환
            if (ord.cappuccinohcount >= 2)
            {
                for (int i = 0; i < count; i++) // 리스트 뷰 내에서 검색하는 포문
                {
                    if (listView_order.Items[i].SubItems[0].Text == button_Cappuccinoh.Text)

                    {
                        listView_order.Items[i].Focused = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.Items[i].Selected = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.FocusedItem.SubItems[0].Text = button_Cappuccinoh.Text; // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.cappuccinohcount); // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.CappuccinohSum()); // 포커스된 부분에 내용 덮어쓰는거
                        ord.cappuccinohcount++;
                        listView_order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var coffee = new string[] { this.button_Cappuccinoh.Text, Convert.ToString(ord.cappuccinohcount), Convert.ToString(ord.CappuccinohSum()) };
                var lvt = new ListViewItem(coffee);
                this.listView_order.Items.Add(lvt);
                listView_order.Focus();
                ord.cappuccinohcount++;
            }
            textBox_sumnumber.Text = Convert.ToString(ord.SumNumber());
            textBox_sumcash.Text = Convert.ToString(ord.SumCash());
        }

        private void button_Cappuccinoi_Click(object sender, EventArgs e)// 카푸치노 ice 버튼 누르면 리스트뷰에 뜨게하는거
        {
            int count = listView_order.Items.Count; // 리스트뷰 항목 수 반환
            if (ord.cappuccinoicount >= 2)
            {
                for (int i = 0; i < count; i++) // 리스트 뷰 내에서 검색하는 포문
                {
                    if (listView_order.Items[i].SubItems[0].Text == button_Cappuccinoi.Text)

                    {
                        listView_order.Items[i].Focused = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.Items[i].Selected = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.FocusedItem.SubItems[0].Text = button_Cappuccinoi.Text; // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.cappuccinoicount); // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.CappuccinoiSum()); // 포커스된 부분에 내용 덮어쓰는거
                        ord.cappuccinoicount++;
                        listView_order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var coffee = new string[] { this.button_Cappuccinoi.Text, Convert.ToString(ord.cappuccinoicount), Convert.ToString(ord.CappuccinoiSum()) };
                var lvt = new ListViewItem(coffee);
                this.listView_order.Items.Add(lvt);
                listView_order.Focus();
                ord.cappuccinoicount++;
            }
            textBox_sumnumber.Text = Convert.ToString(ord.SumNumber());
            textBox_sumcash.Text = Convert.ToString(ord.SumCash());
        }

        private void button_CafeMochah_Click(object sender, EventArgs e)// 카페모카 hot 버튼 누르면 리스트뷰에 뜨게하는거
        {
            int count = listView_order.Items.Count; // 리스트뷰 항목 수 반환
            if (ord.cafemochahcount >= 2)
            {
                for (int i = 0; i < count; i++) // 리스트 뷰 내에서 검색하는 포문
                {
                    if (listView_order.Items[i].SubItems[0].Text == button_CafeMochah.Text)

                    {
                        listView_order.Items[i].Focused = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.Items[i].Selected = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.FocusedItem.SubItems[0].Text = button_CafeMochah.Text; // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.cafemochahcount); // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.CafemochahSum()); // 포커스된 부분에 내용 덮어쓰는거
                        ord.cafemochahcount++;
                        listView_order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var coffee = new string[] { this.button_CafeMochah.Text, Convert.ToString(ord.cafemochahcount), Convert.ToString(ord.CafemochahSum()) };
                var lvt = new ListViewItem(coffee);
                this.listView_order.Items.Add(lvt);
                listView_order.Focus();
                ord.cafemochahcount++;
            }
            textBox_sumnumber.Text = Convert.ToString(ord.SumNumber());
            textBox_sumcash.Text = Convert.ToString(ord.SumCash());
        }

        private void button_CafeMochai_Click(object sender, EventArgs e)// 카페모카 ice 버튼 누르면 리스트뷰에 뜨게하는거
        {
            int count = listView_order.Items.Count; // 리스트뷰 항목 수 반환
            if (ord.cafemochaicount >= 2)
            {
                for (int i = 0; i < count; i++) // 리스트 뷰 내에서 검색하는 포문
                {
                    if (listView_order.Items[i].SubItems[0].Text == button_CafeMochai.Text)

                    {
                        listView_order.Items[i].Focused = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.Items[i].Selected = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.FocusedItem.SubItems[0].Text = button_CafeMochai.Text; // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.cafemochaicount); // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.CafemochaiSum()); // 포커스된 부분에 내용 덮어쓰는거
                        ord.cafemochaicount++;
                        listView_order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var coffee = new string[] { this.button_CafeMochai.Text, Convert.ToString(ord.cafemochaicount), Convert.ToString(ord.CafemochaiSum()) };
                var lvt = new ListViewItem(coffee);
                this.listView_order.Items.Add(lvt);
                listView_order.Focus();
                ord.cafemochaicount++;
            }
            textBox_sumnumber.Text = Convert.ToString(ord.SumNumber());
            textBox_sumcash.Text = Convert.ToString(ord.SumCash());
        }

        private void button_caramelh_Click(object sender, EventArgs e)// 카라멜 마끼아또 hot 버튼 누르면 리스트뷰에 뜨게하는거
        {
            int count = listView_order.Items.Count; // 리스트뷰 항목 수 반환
            if (ord.caramelhcount >= 2)
            {
                for (int i = 0; i < count; i++) // 리스트 뷰 내에서 검색하는 포문
                {
                    if (listView_order.Items[i].SubItems[0].Text == button_caramelh.Text)

                    {
                        listView_order.Items[i].Focused = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.Items[i].Selected = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.FocusedItem.SubItems[0].Text = button_caramelh.Text; // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.caramelhcount); // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.CaramelhSum()); // 포커스된 부분에 내용 덮어쓰는거
                        ord.caramelhcount++;
                        listView_order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var coffee = new string[] { this.button_caramelh.Text, Convert.ToString(ord.caramelhcount), Convert.ToString(ord.CaramelhSum()) };
                var lvt = new ListViewItem(coffee);
                this.listView_order.Items.Add(lvt);
                listView_order.Focus();
                ord.caramelhcount++;
            }
            textBox_sumnumber.Text = Convert.ToString(ord.SumNumber());
            textBox_sumcash.Text = Convert.ToString(ord.SumCash());
        }

        private void button_carameli_Click(object sender, EventArgs e)// 카라멜 마끼아또 ice 버튼 누르면 리스트뷰에 뜨게하는거
        {
            int count = listView_order.Items.Count; // 리스트뷰 항목 수 반환
            if (ord.caramelicount >= 2)
            {
                for (int i = 0; i < count; i++) // 리스트 뷰 내에서 검색하는 포문
                {
                    if (listView_order.Items[i].SubItems[0].Text == button_carameli.Text)

                    {
                        listView_order.Items[i].Focused = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.Items[i].Selected = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.FocusedItem.SubItems[0].Text = button_carameli.Text; // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.caramelicount); // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.CarameliSum()); // 포커스된 부분에 내용 덮어쓰는거
                        ord.caramelicount++;
                        listView_order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var coffee = new string[] { this.button_carameli.Text, Convert.ToString(ord.caramelicount), Convert.ToString(ord.CarameliSum()) };
                var lvt = new ListViewItem(coffee);
                this.listView_order.Items.Add(lvt);
                listView_order.Focus();
                ord.caramelicount++;
            }
            textBox_sumnumber.Text = Convert.ToString(ord.SumNumber());
            textBox_sumcash.Text = Convert.ToString(ord.SumCash());
        }

        private void button_Chococake_Click(object sender, EventArgs e)// 초코케익 버튼 누르면 리스트뷰에 뜨게하는거
        {
            int count = listView_order.Items.Count; // 리스트뷰 항목 수 반환
            if (ord.chococakecount >= 2)
            {
                for (int i = 0; i < count; i++) // 리스트 뷰 내에서 검색하는 포문
                {
                    if (listView_order.Items[i].SubItems[0].Text == button_Chococake.Text)

                    {
                        listView_order.Items[i].Focused = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.Items[i].Selected = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.FocusedItem.SubItems[0].Text = button_Chococake.Text; // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.chococakecount); // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.ChococakeSum()); // 포커스된 부분에 내용 덮어쓰는거
                        ord.chococakecount++;
                        listView_order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var dessert = new string[] { this.button_Chococake.Text, Convert.ToString(ord.chococakecount), Convert.ToString(ord.ChococakeSum()) };
                var lvt = new ListViewItem(dessert);
                this.listView_order.Items.Add(lvt);
                listView_order.Focus();
                ord.chococakecount++;
            }
            textBox_dessertsum.Text = Convert.ToString(ord.Sumdessert());
            textBox_sumcash.Text = Convert.ToString(ord.SumCash());
        }

        private void button_Cheezecake_Click(object sender, EventArgs e)// 치즈케익 버튼 누르면 리스트뷰에 뜨게 하는거
        {
            int count = listView_order.Items.Count; // 리스트뷰 항목 수 반환
            if (ord.cheezecakecount >= 2)
            {
                for (int i = 0; i < count; i++) // 리스트 뷰 내에서 검색하는 포문
                {
                    if (listView_order.Items[i].SubItems[0].Text == button_Cheezecake.Text)

                    {
                        listView_order.Items[i].Focused = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.Items[i].Selected = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.FocusedItem.SubItems[0].Text = button_Cheezecake.Text; // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.cheezecakecount); // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.CheezecakeSum()); // 포커스된 부분에 내용 덮어쓰는거
                        ord.cheezecakecount++;
                        listView_order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var dessert = new string[] { this.button_Cheezecake.Text, Convert.ToString(ord.cheezecakecount), Convert.ToString(ord.CheezecakeSum()) };
                var lvt = new ListViewItem(dessert);
                this.listView_order.Items.Add(lvt);
                listView_order.Focus();
                ord.cheezecakecount++;
            }
            textBox_dessertsum.Text = Convert.ToString(ord.Sumdessert());
            textBox_sumcash.Text = Convert.ToString(ord.SumCash());
        }

        private void button_Brownie_Click(object sender, EventArgs e)// 브라우니 버튼 누르면 리스트뷰에 뜨게 하는거
        {
            int count = listView_order.Items.Count; // 리스트뷰 항목 수 반환
            if (ord.browniecount >= 2)
            {
                for (int i = 0; i < count; i++) // 리스트 뷰 내에서 검색하는 포문
                {
                    if (listView_order.Items[i].SubItems[0].Text == button_Brownie.Text)

                    {
                        listView_order.Items[i].Focused = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.Items[i].Selected = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.FocusedItem.SubItems[0].Text = button_Brownie.Text; // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.browniecount); // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.BrownieSum()); // 포커스된 부분에 내용 덮어쓰는거
                        ord.browniecount++;
                        listView_order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var dessert = new string[] { this.button_Brownie.Text, Convert.ToString(ord.browniecount), Convert.ToString(ord.BrownieSum()) };
                var lvt = new ListViewItem(dessert);
                this.listView_order.Items.Add(lvt);
                listView_order.Focus();
                ord.browniecount++;
            }
            textBox_dessertsum.Text = Convert.ToString(ord.Sumdessert());
            textBox_sumcash.Text = Convert.ToString(ord.SumCash());
        }

        private void button_Tiramisu_Click(object sender, EventArgs e) // 티리미슈 버튼 누르면 리스트뷰에 뜨게 하는거
        {
            int count = listView_order.Items.Count; // 리스트뷰 항목 수 반환
            if (ord.tiramisucount >= 2)
            {
                for (int i = 0; i < count; i++) // 리스트 뷰 내에서 검색하는 포문
                {
                    if (listView_order.Items[i].SubItems[0].Text == button_Tiramisu.Text)

                    {
                        listView_order.Items[i].Focused = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.Items[i].Selected = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.FocusedItem.SubItems[0].Text = button_Tiramisu.Text; // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.tiramisucount); // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.TiramisuSum()); // 포커스된 부분에 내용 덮어쓰는거
                        ord.tiramisucount++;
                        listView_order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var dessert = new string[] { this.button_Tiramisu.Text, Convert.ToString(ord.tiramisucount), Convert.ToString(ord.TiramisuSum()) };
                var lvt = new ListViewItem(dessert);
                this.listView_order.Items.Add(lvt);
                listView_order.Focus();
                ord.tiramisucount++;
            }
            textBox_dessertsum.Text = Convert.ToString(ord.Sumdessert());
            textBox_sumcash.Text = Convert.ToString(ord.SumCash());
        }

        private void button_Muffin_Click(object sender, EventArgs e) // 머핀 버튼 누르면 리스트뷰에 뜨게 하는거
        {
            int count = listView_order.Items.Count; // 리스트뷰 항목 수 반환
            if (ord.muffincount >= 2)
            {
                for (int i = 0; i < count; i++) // 리스트 뷰 내에서 검색하는 포문
                {
                    if (listView_order.Items[i].SubItems[0].Text == button_Muffin.Text)

                    {
                        listView_order.Items[i].Focused = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.Items[i].Selected = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.FocusedItem.SubItems[0].Text = button_Muffin.Text; // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.muffincount); // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.MuffinSum()); // 포커스된 부분에 내용 덮어쓰는거
                        ord.muffincount++;
                        listView_order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var dessert = new string[] { this.button_Muffin.Text, Convert.ToString(ord.muffincount), Convert.ToString(ord.MuffinSum()) };
                var lvt = new ListViewItem(dessert);
                this.listView_order.Items.Add(lvt);
                listView_order.Focus();
                ord.muffincount++;
            }
            textBox_dessertsum.Text = Convert.ToString(ord.Sumdessert());
            textBox_sumcash.Text = Convert.ToString(ord.SumCash());
        }

        private void button_Bagel_Click(object sender, EventArgs e) // 베이글 버튼 누르면 리스트뷰에 뜨게 하는거
        {
            int count = listView_order.Items.Count; // 리스트뷰 항목 수 반환
            if (ord.bagelcount >= 2)
            {
                for (int i = 0; i < count; i++) // 리스트 뷰 내에서 검색하는 포문
                {
                    if (listView_order.Items[i].SubItems[0].Text == button_Bagel.Text)

                    {
                        listView_order.Items[i].Focused = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.Items[i].Selected = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.FocusedItem.SubItems[0].Text = button_Bagel.Text; // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.bagelcount); // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.BagelSum()); // 포커스된 부분에 내용 덮어쓰는거
                        ord.bagelcount++;
                        listView_order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var dessert = new string[] { this.button_Bagel.Text, Convert.ToString(ord.bagelcount), Convert.ToString(ord.BagelSum()) };
                var lvt = new ListViewItem(dessert);
                this.listView_order.Items.Add(lvt);
                listView_order.Focus();
                ord.bagelcount++;
            }
            textBox_dessertsum.Text = Convert.ToString(ord.Sumdessert());
            textBox_sumcash.Text = Convert.ToString(ord.SumCash());
        }

        private void button_Waffle_Click(object sender, EventArgs e) // 와플 버튼 누르면 리스트뷰에 뜨게 하는거
        {
            int count = listView_order.Items.Count; // 리스트뷰 항목 수 반환
            if (ord.wafflecount >= 2)
            {
                for (int i = 0; i < count; i++) // 리스트 뷰 내에서 검색하는 포문
                {
                    if (listView_order.Items[i].SubItems[0].Text == button_Waffle.Text)

                    {
                        listView_order.Items[i].Focused = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.Items[i].Selected = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.FocusedItem.SubItems[0].Text = button_Waffle.Text; // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.wafflecount); // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.WaffleSum()); // 포커스된 부분에 내용 덮어쓰는거
                        ord.wafflecount++;
                        listView_order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var dessert = new string[] { this.button_Waffle.Text, Convert.ToString(ord.wafflecount), Convert.ToString(ord.WaffleSum()) };
                var lvt = new ListViewItem(dessert);
                this.listView_order.Items.Add(lvt);
                listView_order.Focus();
                ord.wafflecount++;
            }
            textBox_dessertsum.Text = Convert.ToString(ord.Sumdessert());
            textBox_sumcash.Text = Convert.ToString(ord.SumCash());
        }

        private void button_bell7_Click(object sender, EventArgs e)// 계산기 7번 버튼
        {
            if (cash == 0)
            {
                cash = 7;
                textBox_cash.Text = Convert.ToString(cash);
            }
            else
            {
                cash *= 10;
                cash += 7;
                textBox_cash.Text = Convert.ToString(cash);
            }
            textBox_cash2.Text = Convert.ToString(cash - ord.SumCash());
        }

        private void button_bell8_Click(object sender, EventArgs e)// 계산기 8번 버튼
        {
            if (cash == 0)
            {
                cash = 8;
                textBox_cash.Text = Convert.ToString(cash);
            }
            else
            {
                cash *= 10;
                cash += 8;
                textBox_cash.Text = Convert.ToString(cash);
            }
            textBox_cash2.Text = Convert.ToString(cash - ord.SumCash());
        }

        private void button_bell9_Click(object sender, EventArgs e)// 계산기 9번 버튼
        {
            if (cash == 0)
            {
                cash = 9;
                textBox_cash.Text = Convert.ToString(cash);
            }
            else
            {
                cash *= 10;
                cash += 9;
                textBox_cash.Text = Convert.ToString(cash);
            }
            textBox_cash2.Text = Convert.ToString(cash - ord.SumCash());
        }

        private void button_bell4_Click(object sender, EventArgs e) // 계산기 4번 버튼
        {
            if (cash == 0)
            {
                cash = 4;
                textBox_cash.Text = Convert.ToString(cash);
            }
            else
            {
                cash *= 10;
                cash += 4;
                textBox_cash.Text = Convert.ToString(cash);
            }
            textBox_cash2.Text = Convert.ToString(cash - ord.SumCash());
        }

        private void button_bell5_Click(object sender, EventArgs e)// 계산기 5번 버튼
        {
            if (cash == 0)
            {
                cash = 5;
                textBox_cash.Text = Convert.ToString(cash);
            }
            else
            {
                cash *= 10;
                cash += 5;
                textBox_cash.Text = Convert.ToString(cash);
            }
            textBox_cash2.Text = Convert.ToString(cash - ord.SumCash());
        }

        private void button_bell6_Click(object sender, EventArgs e)// 계산기 6번 버튼
        {
            if (cash == 0)
            {
                cash = 6;
                textBox_cash.Text = Convert.ToString(cash);
            }
            else
            {
                cash *= 10;
                cash += 6;
                textBox_cash.Text = Convert.ToString(cash);
            }
            textBox_cash2.Text = Convert.ToString(cash - ord.SumCash());
        }

        private void button_bell1_Click(object sender, EventArgs e)// 계산기 1번 버튼
        {
            if (cash == 0)
            {
                cash = 1;
                textBox_cash.Text = Convert.ToString(cash);
            }
            else
            {
                cash *= 10;
                cash += 1;
                textBox_cash.Text = Convert.ToString(cash);
            }
            textBox_cash2.Text = Convert.ToString(cash - ord.SumCash());
        }

        private void button_bell2_Click(object sender, EventArgs e)// 계산기 2번 버튼
        {
            if (cash == 0)
            {
                cash = 2;
                textBox_cash.Text = Convert.ToString(cash);
            }
            else
            {
                cash *= 10;
                cash += 2;
                textBox_cash.Text = Convert.ToString(cash);
            }
            textBox_cash2.Text = Convert.ToString(cash - ord.SumCash());
        }

        private void button_bell3_Click(object sender, EventArgs e)// 계산기 3번 버튼
        {
            if (cash == 0)
            {
                cash = 3;
                textBox_cash.Text = Convert.ToString(cash);
            }
            else
            {
                cash *= 10;
                cash += 3;
                textBox_cash.Text = Convert.ToString(cash);
            }
            textBox_cash2.Text = Convert.ToString(cash - ord.SumCash());
        }

        private void button_bell0_Click(object sender, EventArgs e)// 계산기 0번 버튼
        {
            cash *= 10;
            textBox_cash.Text = Convert.ToString(cash);
            textBox_cash2.Text = Convert.ToString(cash - ord.SumCash());
        }

        private void button_bell00_Click(object sender, EventArgs e)// 계산기 00번 버튼
        {
            cash *= 100;
            textBox_cash.Text = Convert.ToString(cash);
            textBox_cash2.Text = Convert.ToString(cash - ord.SumCash());
        }

        private void button_bellce_Click(object sender, EventArgs e)// 계산기 CE 버튼
        {
            cash = 0;
            textBox_cash.Text = Convert.ToString(cash);
            textBox_cash2.Text = Convert.ToString(cash - ord.SumCash());
        }



        private void button_Cash_Click(object sender, EventArgs e) // 현금결제 버튼
        {
            int count = listView_order.Items.Count; // 리스트뷰 항목수 반환
            if (count == 0)
            {
                MessageBox.Show("결제할 메뉴가 없습니다!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (textBox_cash.Text == "0")
                {
                    textBox_cash.Text = textBox_sumcash.Text;
                }
                DialogResult dlr = MessageBox.Show("현금결제 하시겠습니까?", "현금 결제", MessageBoxButtons.YesNo);
                if (dlr == DialogResult.Yes)
                {
                    listView_order.Items.Clear();
                    textBox_cash.Text = "0";
                    textBox_cash2.Text = "0";
                    textBox_sumcash.Text = "0";
                    textBox_sumnumber.Text = "0";
                    textBox_dessertsum.Text = "0";
                    MessageBox.Show("결제가 완료되었습니다.", "결제 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button_Card_Click(object sender, EventArgs e) // 카드결제 버튼
        {
            int count = listView_order.Items.Count; // 리스트뷰 항목수 반환
            if (count == 0)
            {
                MessageBox.Show("결제할 메뉴가 없습니다!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                textBox_cash.Text = textBox_sumcash.Text;
                DialogResult dlr = MessageBox.Show("카드결제 하시겠습니까?", "카드 결제", MessageBoxButtons.YesNo);
                if (dlr == DialogResult.Yes)
                {
                    listView_order.Items.Clear();
                    textBox_cash.Text = "0";
                    textBox_cash2.Text = "0";
                    textBox_sumcash.Text = "0";
                    textBox_sumnumber.Text = "0";
                    textBox_dessertsum.Text = "0";
                    MessageBox.Show("결제가 완료되었습니다.", "결제 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }



        private void button_cancel2_Click(object sender, EventArgs e)// 전체 취소
        {
            int count = listView_order.Items.Count;
            if (count == 0)
            {
                MessageBox.Show("취소할 메뉴가 없습니다!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                listView_order.Items.Clear();
                textBox_cash.Text = "0";
                textBox_cash2.Text = "0";
                textBox_sumcash.Text = "0";
                textBox_sumnumber.Text = "0";
                textBox_dessertsum.Text = "0";
                cash = 0;
                ord.americanohcount = ord.cafelattehcount = ord.cappuccinohcount = ord.cafemochahcount = ord.caramelhcount = ord.americanoicount = ord.cafelatteicount = ord.cappuccinoicount = ord.cafemochaicount = ord.caramelicount = ord.chococakecount = ord.cheezecakecount = ord.browniecount = ord.tiramisucount = ord.muffincount = ord.bagelcount = ord.wafflecount = 1;
                ord.americanohsum = ord.cafelattehsum = ord.cappuccinohsum = ord.cafemochahsum = ord.caramelhsum = ord.americanoisum = ord.cafelatteisum = ord.cappuccinoisum = ord.cafemochaisum = ord.caramelisum = ord.chococakesum = ord.cheezecakesum = ord.browniesum = ord.tiramisusum = ord.muffinsum = ord.bagelsum = ord.wafflesum = 0;
            }
        }

        private void button_cancel1_Click(object sender, EventArgs e)// 선택 취소
        {
            int count = listView_order.Items.Count;
            if (count == 0)
            {
                MessageBox.Show("취소할 메뉴가 없습니다!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                if (listView_order.FocusedItem.SubItems[0].Text == button_Americanoh.Text)
                {
                    ord.americanohcount = 1;
                    ord.americanohsum = 0;
                }
                else if (listView_order.FocusedItem.SubItems[0].Text == button_Americanoi.Text)
                {
                    ord.americanoicount = 1;
                    ord.americanoisum = 0;
                }
                else if (listView_order.FocusedItem.SubItems[0].Text == button_Cafelatteh.Text)
                {
                    ord.cafelattehcount = 1;
                    ord.cafelattehsum = 0;

                }
                else if (listView_order.FocusedItem.SubItems[0].Text == button_Cafelattei.Text)
                {
                    ord.cafelatteicount = 1;
                    ord.cafelatteisum = 0;
                }
                else if (listView_order.FocusedItem.SubItems[0].Text == button_Cappuccinoh.Text)
                {
                    ord.cappuccinohcount = 1;
                    ord.cappuccinohsum = 0;
                }
                else if (listView_order.FocusedItem.SubItems[0].Text == button_Cappuccinoi.Text)
                {
                    ord.cappuccinoicount = 1;
                    ord.cappuccinoisum = 0;
                }
                else if (listView_order.FocusedItem.SubItems[0].Text == button_CafeMochah.Text)
                {
                    ord.cafemochahcount = 1;
                    ord.cafemochahsum = 0;
                }
                else if (listView_order.FocusedItem.SubItems[0].Text == button_CafeMochai.Text)
                {
                    ord.cafemochaicount = 1;
                    ord.cafemochaisum = 0;

                }
                else if (listView_order.FocusedItem.SubItems[0].Text == button_caramelh.Text)
                {
                    ord.caramelhcount = 1;
                    ord.caramelhsum = 0;

                }
                else if (listView_order.FocusedItem.SubItems[0].Text == button_carameli.Text)
                {
                    ord.caramelicount = 1;
                    ord.caramelisum = 0;
                }
                else if (listView_order.FocusedItem.SubItems[0].Text == button_Chococake.Text)
                {
                    ord.chococakecount = 1;
                    ord.chococakesum = 0;
                }
                else if (listView_order.FocusedItem.SubItems[0].Text == button_Cheezecake.Text)
                {
                    ord.cheezecakecount = 1;
                    ord.cheezecakesum = 0;
                }
                else if (listView_order.FocusedItem.SubItems[0].Text == button_Brownie.Text)
                {
                    ord.browniecount = 1;
                    ord.browniesum = 0;
                }
                else if (listView_order.FocusedItem.SubItems[0].Text == button_Tiramisu.Text)
                {
                    ord.tiramisucount = 1;
                    ord.tiramisusum = 0;
                }
                else if (listView_order.FocusedItem.SubItems[0].Text == button_Muffin.Text)
                {
                    ord.muffincount = 1;
                    ord.muffinsum = 0;
                }
                else if (listView_order.FocusedItem.SubItems[0].Text == button_Bagel.Text)
                {
                    ord.bagelcount = 1;
                    ord.bagelsum = 0;
                }
                else if (listView_order.FocusedItem.SubItems[0].Text == button_Waffle.Text)
                {
                    ord.wafflecount = 1;
                    ord.wafflesum = 0;
                }
                textBox_sumnumber.Text = Convert.ToString(ord.SumNumber());
                textBox_sumcash.Text = Convert.ToString(ord.SumCash());
                textBox_dessertsum.Text = Convert.ToString(ord.Sumdessert());
                listView_order.Items.Remove(listView_order.FocusedItem); // 컨트롤 부분을 제거하는거.
            }
        }


        // ------------------------------------------------------------------기타-----------------------------------------------------------------------------
        private void timer_Tick(object sender, EventArgs e) // 타이머 사용해서 영업일자 나타내는거
        {
            labelTIME.Text = DateTime.Now.ToString();
        }

        private void 메모장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MEMO mem = new MEMO();
            mem.Show();

        }

        private void 도움말ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HELP help = new HELP();
            help.Show();
        }


        //----------------------------------------메뉴버튼 폼 열기 동작------------------------------------

        private void MemberControl_ToolStripMenuItem_Click(object sender, EventArgs e) //회원관리 폼 열기
        {
            MemberControlForm frm = new MemberControlForm();
            frm.Owner = this;
            frm.ShowDialog();
            frm.Dispose();
        }

        private void ProductControl_ToolStripMenuItem_Click(object sender, EventArgs e) //상품관리 폼 열기
        {
            ProductControlForm frm = new ProductControlForm();
            frm.Owner = this;
            frm.ShowDialog();
            frm.Dispose();
        }
        private void ShowOrder_ToolStripMenuItem_Click(object sender, EventArgs e) //주문관리 폼 열기
        {
            ShowOrderForm frm = new ShowOrderForm();
            frm.Owner = this;
            frm.ShowDialog();
            frm.Dispose();
        }

        private void DailySales_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DailySalesForm frm = new DailySalesForm();
            frm.Owner = this;
            frm.ShowDialog();
            frm.Dispose();
        }

        private void MonthlySales_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonthlySalesForm frm = new MonthlySalesForm();
            frm.Owner = this;
            frm.ShowDialog();
            frm.Dispose();
        }

    }
}

