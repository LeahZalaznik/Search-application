using Dto;
using System.ComponentModel.Design;

namespace Dal
{
    public class DalClass
    {
        //תוכן הספר
        public static string getText(eBooks nameBook)
        {
            string s = File.ReadAllText(@"C:\Users\This User\Desktop\שנה ב\שעורי בית\c#\ui\Dall\bin\Debug\net6.0\text\" + nameBook.ToString() + ".txt"); ;
            return s;
        }
        //תוכן כל הספרים
        public static string getText()
        {
            string s = "";
            string[] files = Directory.GetFiles(@"C:\Users\This User\Desktop\שנה ב\שעורי בית\c#\ui\Dall\bin\Debug\net6.0\text", "*.txt");
            Array.Sort(files);
            foreach (string file in files)
            {
                s += "$" + "\n" + File.ReadAllText(file);
            }
            return s;
        }
    }
}
