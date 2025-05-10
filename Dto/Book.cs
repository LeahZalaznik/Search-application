
using System.Runtime.CompilerServices;

namespace Dto
{
    public enum eBooks
    {
        All=1,
        איוב=2,
        איכה,
        אסתר,
        במדבר,
        בראשית,
        //דברי_הימים_א,
        //דברי_הימים_ב,
        דברים,
        דניאל,
        ויקרא,
        משלי,
        נחמיה,
        עזרה,
        קהלת,
        רות,
        שיר_השירים,
        שמות,
        תהילים
    }
    public enum eChomashim { בראשית, שמות, ויקרא, במדבר, דברים }
    public class Book:Text
    {
        public eBooks name { get; set; }
        public List<Book> Books { get; set; }
        public List<Chapter> chapters { get; set; }
        public List<Parasha> parashas { get; set; }

        private Book()
        {
            
        }
        public Book(eBooks nameBook,string dataBook)
        {     
            name = nameBook;
            if (eBooks.All.Equals(nameBook))
                Books = dividBooK(dataBook);
           
            if (Enum.IsDefined(typeof(eChomashim), nameBook.ToString()))
            {
                parashas = dividParashas(dataBook);
                chapters = new List<Chapter>();
                foreach (Parasha p in parashas)
                    foreach (Chapter chapter in p.chaptersP)
                        chapters.Add(chapter);
            }
            else
            {
                chapters = dividChapters(dataBook);
                parashas = null;
            }
        }
        public List<Chapter> dividChapters(string book)
        {
            List<Chapter> list = new List<Chapter>();
            if (book is not null)
            {
                string[] chapters = book.Split('~');
                for (int i = 1; i < chapters.Length; i++)
                {
                    int j = chapters[i].IndexOf("-");
                    string st = chapters[i].Substring(j > 0 ? j : 0);
                    string n = getWord(st, 1);
                    list.Add(new Chapter(st, n, this.name));
                }
            }
            return list;
         }
        public List<Book> dividBooK(string book)
        {
            string[] Books = book.Split('$');
            List<Book> list = new List<Book>();
            eBooks eBooks = eBooks.איוב;
            for (int i = 1; i < Books.Length; i++)
            {
                list.Add(new Book(eBooks++,Books[i]));
            }
            return list;
        }
        public List<Parasha> dividParashas(string book)
        {
            string[] parasot = book.Split('^');
            List<Parasha> list = new List<Parasha>();
            for (int i = 1; i < parasot.Length; i++)
            {
                list.Add(new Parasha(this.name,getWord(parasot[i], 6), parasot[i]));
            }
            return list;
        }
    }

}
