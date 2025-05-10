using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
   
    public class Verse:Text
    {
        public eBooks Sefer { get; set; }

        public string Parasha { get; set; }
        public string Perek { get; set; }
        public string Pasuk { get; set; }

        public string Data { get; set; }
        

        public Verse(string verse, string verseStr,eBooks nameBook ,int numChapter,string nameChapter) 
        {
            this.Data = verse;
            this.Pasuk = verseStr;
            this.Sefer = nameBook; 
            this.Perek=nameChapter;
        }
       
        public Verse(string verse, string verseStr, eBooks nameBook, int numChapter, string nameChapter,string nameParasha)
        {
            if(Enum.IsDefined(typeof(eChomashim), nameBook.ToString()))
                this.Parasha = nameParasha;
            this.Data = verse;
            this.Pasuk = verseStr;
            this.Sefer = nameBook;
            this.Perek = nameChapter;
        }
        public Verse()
        {
            
        }
    }

}
