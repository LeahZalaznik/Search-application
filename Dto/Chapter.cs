using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class  Chapter:Text
    {
        public string chapter { get; set; }
        public int numChapter { get; set; }
        
        public string ChapterStr { get; set; }
        
        public eBooks nameBook { get; set; }

        public string nameParasha { get; set; }

        public List<Verse> verses { get; set; }
        public Chapter()
        {

        }
        public Chapter(string chapter,string strChapter,eBooks nameBook)
        {
            this.chapter = chapter;
            this.ChapterStr = strChapter;
            this.numChapter = convertStrTo(strChapter);
            this.nameBook = nameBook;
            verses=dividVerse(chapter);
                           
        }
        public Chapter(string chapter, string strChapter, eBooks nameBook,string nameParasha)
        {
            this.nameParasha = nameParasha;
            this.chapter = chapter;
            this.ChapterStr = strChapter;
            this.numChapter = convertStrTo(strChapter);
            this.nameBook = nameBook;
            verses = dividVerse(chapter);

        }
        public List<Verse> dividVerse(string chapter)
        {
            string[] verss = chapter.Split('!');
            List<Verse> list = new List<Verse>();

            for (int i = 1; i < verss.Length; i++)
            {
                int j = verss[i].IndexOf("!");
                string st = verss[i].Substring(j > 0 ? j : 0);
                j = st.IndexOf("}");
                string n = getWord(st, 2);
                list.Add(new Verse(st.Substring(j+1), n, nameBook, numChapter, ChapterStr,nameParasha));
            }
            return list;
        }
        
    }
}
