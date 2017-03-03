using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayfairCiperSimulator
{  
    public partial class Simulator : Form
    {
        string[,] _matrix55 = new string[5, 5]; //Ma trận 5x5 hiển thị trên UI + Chứa ma trận sau khi đã thêm key
        string[,] _matrix66 = new string[6, 6]; //Ma trận 6x6 hiển thị trên UI + Chứa ma trận sau khi đã thêm key
        string[] alphabet55 = new string[25] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "K", "L", "M",
            "N", "O", "P", "Q", "R", "S", "T", "U", "V", "Q", "X", "Y", "Z" };
        //Chuỗi pre-formatting dùng để test hàm mã hóa- chuỗi này chỉ dùng để test -
        string[] pre_formatTEXT =new string[18] { "A", "N", "T", "O", "A", "N", "M", "A", "N", "G", "M", "A", "Y", "T", "I", "N", "H", "X" };
        //string[] alphabet66 =new string[36] //dùng cả chữ J và thêm số từ 0 tới 9     
        //Hàm loop kết quả ra UI cho ma trận 5x5
        public void LoopToUI55()
        {
            // row = 0;
            lbl00.Text = _matrix55[0, 0];
            lbl01.Text = _matrix55[0, 1];
            lbl02.Text = _matrix55[0, 2];
            lbl03.Text = _matrix55[0, 3];
            lbl04.Text = _matrix55[0, 4];
            //row = 1;
            lbl10.Text = _matrix55[1, 0];
            lbl11.Text = _matrix55[1, 1];
            lbl12.Text = _matrix55[1, 2];
            lbl13.Text = _matrix55[1, 3];
            lbl14.Text = _matrix55[1, 4];
            //row = 2;
            lbl20.Text = _matrix55[2, 0];
            lbl21.Text = _matrix55[2, 1];
            lbl22.Text = _matrix55[2, 2];
            lbl23.Text = _matrix55[2, 3];
            lbl24.Text = _matrix55[2, 4];
            //row = 3
            lbl30.Text = _matrix55[3, 0];
            lbl31.Text = _matrix55[3, 1];
            lbl32.Text = _matrix55[3, 2];
            lbl33.Text = _matrix55[3, 3];
            lbl34.Text = _matrix55[3, 4];
            //row = 4
            lbl40.Text = _matrix55[4, 0];
            lbl41.Text = _matrix55[4, 1];
            lbl42.Text = _matrix55[4, 2];
            lbl43.Text = _matrix55[4, 3];
            lbl44.Text = _matrix55[4, 4];
        }
        
       
        public Simulator()
        {
            InitializeComponent();
            //Test thuật toán mã hóa playfair => thiết lập matrix55 với key= KEYISANT
            //Text = "an toan mang may tinh"      
            _matrix55 = new string[,]  {
            {"K","E","Y","I","S"},
            {"A","N","T","B","C"},
            {"D","F","G","H","L"},
            {"M","O","P","Q","R"},
            {"U","V","W","X","Z"}
            };
            LoopToUI55();
            //Nhấn check 5x5 trên UI
            tbKey.Text = "KEYISANT";
            radioButton5.Checked = true;
        }

        #region Thuật toán mã hóa
        //Hàm lấy ra index của chữ cái dựa vào ma trận 
        public void getIndex(string input,int Row,int Column,int matrixlength)
        {
            Row = Column = -1;
            for(int i=0;i<matrixlength;i++)
                for(int j=0;j<matrixlength;j++)
                    if(_matrix55[i,j]==input)
                    {
                        Row = i;
                        Column=j;
                    }
             //                      
        }
        //Hàm so sánh 2 index và chọn cách giải mã phù hợp ( nếu 2 index trùng => input vào bị lỗi => thoát và báo error)
        public void Encrypt(string letter1,string letter2,string cipher1,string cipher2)
        {
            //Tạo biến lưu trữ hàng và cột- row & column
            int r1 = -1;
            int r2 = -1;
            int c1 = -1;
            int c2 = -1;
            getIndex(letter1, r1, c1, 5);
            getIndex(letter2, r2, c2, 5);
            //Gọi các hàm xử lý phù hợp dựa vào index
            if (r1 == r2 && c1 == c2)
                MessageBox.Show("Lỗi tính toán,2 ký tự giống nhau trong pre-formatting text");
            else
            {
                //Gọi các hàm xử lý
            }
        }
        //Các hàm sẽ lấy tọa độ chữ cái cần mã hóa và xử lý, xuất kết quả vào biến cipher1 & 2.
        //Hàm xử lý nếu 2 chữ cái cùng hàng
        public void encryptSameRow(string cipher1,int c1,string cipher2,int c2,int Row)
        {
            //Hàm xử lý cùng hàng, vì cùng hàng nên chỉ cần xem xét dịch chuyển cột
            c1++; c2++;
            if (c1 < c2)
            {
                if (c2 == 5)
                    c2 = 0;
            }
            else if( c1 > c2)
            {
                if (c1 == 5)
                    c1 = 0;
            }
            cipher1 = _matrix55[Row, c1];
            cipher2 = _matrix55[Row, c2];
        }
        //Hàm xử lý nếu 2 chữ cái cùng cột
        public void encryptSameColumn(string cipher1,int r1,string cipher2,int r2,int Column)
        {
            r1++; r2++;
            if(r1 < r2)
            {
                if (r2 == 5)
                    r2 = 0;
            }
            else if( r1 > r2)
            {
                if (r1 == 5)
                    r1 = 0;
            }
            cipher1 = _matrix55[r1, Column];
            cipher2 = _matrix55[r2, Column];
        }
        //Hàm xử lý nếu 2 chữ cái tạo thành hình chữ nhật
        
        #endregion
    }
}
