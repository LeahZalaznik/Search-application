using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class Parasha:Text
    {
        public string nameParasha { get; set; }
        public List<Chapter> chaptersP{ get; set; }
        public string parasha { get; set; }
        public eBooks nameBook { get; set; }
        
        //private Parasha() { }
        public Parasha(eBooks nameBook,string nameParasha, string parasha)
        {

            this.parasha = parasha;
            this.nameParasha = nameParasha;
            this.nameBook = nameBook;
            chaptersP =dividChaptersP(parasha);
        }

   
        public List<Chapter> dividChaptersP(string parasha)
        {
            string[] chapters = parasha.Split('~');
            List<Chapter> list = new List<Chapter>();

            for (int i = 1; i < chapters.Length; i++)
            {
                int j = chapters[i].IndexOf("-");
                string st = chapters[i].Substring(j > 0 ? j : 0);
                string n = getWord(st, 1);
                list.Add(new Chapter(st, n, this.nameBook,nameParasha));
            }
            return list;
        }
    

    }
}
