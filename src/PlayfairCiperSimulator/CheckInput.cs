using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckInput
{
    class Program
    {
        public static bool CheckInput55(string str)
        {
            //Nếu chuỗi rỗng, trả về false
            if (str == "")
            {
                return false;
            }
            //Nếu chuỗi không rỗng
            char[] varChar = str.ToCharArray(); //tách chuỗi thành mảng
            int i = 0;
            while (i < varChar.Length &&
                ((Convert.ToInt32(varChar[i]) == 32) // khoảng trắng
                || (Convert.ToInt32(varChar[i]) >= 65 && Convert.ToInt32(varChar[i]) <= 90) //chữ hoa
                || (Convert.ToInt32(varChar[i]) >= 97 && Convert.ToInt32(varChar[i]) <= 122))) //chữ thường
            {
                i++;
            }
            if (i < varChar.Length)
            {
                return false;
            }
            return true;
        }

        public static bool CheckInput66(string str)
        {
            if (str == "")
            {
                return false;
            }
            char[] varChar = str.ToCharArray();
            int i = 0;
            while (i < varChar.Length &&
                ((Convert.ToInt32(varChar[i]) == 32)
                || (Convert.ToInt32(varChar[i]) >= 65 && Convert.ToInt32(varChar[i]) <= 90)
                || (Convert.ToInt32(varChar[i]) >= 97 && Convert.ToInt32(varChar[i]) <= 122)
                || (Convert.ToInt32(varChar[i]) >= 48 && Convert.ToInt32(varChar[i]) <= 57)))
            {
                i++;
            }
            if (i < varChar.Length)
            {
                return false;
            }
            return true;
        }
    }
}
