using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public abstract class  Text
    {
        public static bool massage = false;
        public static Dictionary<char, int> gematriaMap = new Dictionary<char, int>
        {
            {'א', 1}, {'ב', 2}, {'ג', 3}, {'ד', 4}, {'ה', 5},
            {'ו', 6}, {'ז', 7}, {'ח', 8}, {'ט', 9}, {'י', 10},
            {'כ', 20}, {'ל', 30}, {'מ', 40}, {'נ', 50}, {'ס', 60},
            {'ע', 70}, {'פ', 80}, {'צ', 90}, {'ק', 100}, {'ר', 200},
            {'ש', 300}, {'ת', 400}
         };
        public static int convertStrTo(string str)
        {
            int chapterNum = 0;
            foreach (char ch in str)
            {
                chapterNum += GetGematriaValue(ch);
            }
            return chapterNum;
        }
        public static string getWord(string text, int index)
        {
            string word = "";
            while (index < text.Length && text[index] !='\n' && text[index] !='}' && text[index] != '\r' && text[index] != ' ')
            {
                word += text[index++];
            }
            return word;
        }
        public static int GetGematriaValue(char letter)
        {
            if (gematriaMap.ContainsKey(letter))
            {
                return gematriaMap[letter];
            }

            return 1; 
        } 
    }
}
