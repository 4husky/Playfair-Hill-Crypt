using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playfair
{
    class Matrix66
    {
        private string[] alphabet66 = new string[36] { "A", "B", "C", "D", "E", "F", "G", "H", "I","J", "K", "L", "M",
            "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z","0","1","2","3","4","5","6","7","8","9" };
        private string[,] matrix66 = new string[6, 6];
        private bool key;

        #region Step 1 : Upper string    
        private string fixString(string s)
        {       
            string buffer = s.ToUpper();
            return buffer;
        }
        #endregion

        #region Step2 : check chuỗi nhập vào có kí tự lạ hay không        
        private bool checkString(string s)
        {
            string st = fixString(s);
            string[] buffer = convertStringtoArray(st);
            bool check;
            for (int i = 0; i < buffer.Length; i++)
            {
                check = checkCharinArray(buffer[i], alphabet66);
                if (check == false)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region Step 3: Lập mảng 1 chiều từ chuỗi đã check
        private string[] sortAlphabet(string s)
        {
            key = checkString(s);
            string[] buffer;
            if (key == true)
                buffer = KeyTrue(s);
            else
                buffer = KeyFalse();
            return buffer;
        }
        #endregion

        #region Step 4: Chuyển đổi mảng 1 chiều thành ma trận 6x6        
        public string[,] createMatrix66(string s)
        {
            string[] buffer = sortAlphabet(s);
            int k = 0;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    matrix66[i, j] = buffer[k];
                    k++;
                }
            }
            return matrix66;
        }
        #endregion

        #region Các hàm bổ trợ
        //kiểm tra kí tự s có trong mảng hay không         
        private bool checkCharinArray(string s, string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                if (s == arr[i])
                    return true;
            return false;
        }

        //Chuyển mảng char thành mảng string    
        private string[] convertChartoString(char[] s)
        {
            string[] arr = new string[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                arr[i] = Convert.ToString(s[i]);
            }
            return arr;
        }

        //Chuyển mảng string thành chuỗi
        private string convertArraytoString(string[] arr)
        {
            string s = string.Empty;
            for (int i = 0; i < arr.Length; i++)
                s += arr[i];
            return s;
        }

        // Chuyển chuỗi thành mảng string
        private string[] convertStringtoArray(string s)
        {
            string buffer = fixString(s);
            char[] array = buffer.ToCharArray();
            string[] st = convertChartoString(array);
            return st;
        }
        //Nếu key==true thì gọi hàm này
        private string[] KeyTrue(string s)
        {
            string bufferAlphabet55 = convertArraytoString(alphabet66);
            s += bufferAlphabet55;
            string[] str = convertStringtoArray(s);
            int k = 0;
            string[] buffer = new string[s.Length];
            bool check;
            //Lấy chuỗi nhập vào thêm vào buffer
            for (int i = 0; i < str.Length; i++)
            {
                //kiểm tra s[i] có trong buffer chưa
                check = checkCharinArray(str[i], buffer);
                if (check == false)
                {
                    buffer.SetValue(str[i], k);
                    k++;
                }
            }
            //Thay đổi lại length của buffer = 36 
            string conv = convertArraytoString(buffer);
            buffer = convertStringtoArray(conv);
            return buffer;
        }

        //Nếu key==false thì gọi hàm này
        private string[] KeyFalse()
        {
            string[] buffer = new string[alphabet66.Length];
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = alphabet66[i];
            }
            return buffer;
        }
        #endregion
    }
}
