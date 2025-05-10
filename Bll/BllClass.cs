using Dal;
using Dto;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;

namespace Bll
{
    public class BllClass
    {
        static List<Book> list = new List<Book>();
        public static bool massage;
        static BllClass()
        {
            list = transToJsonFile();
            massage = Dto.Book.massage;

        }

        //סרליזציה ודסרזלציה
        private static List<Book> transToJsonFile()
        {
            //סרליזציה
            string s = DalClass.getText();
            Book All = new Book(eBooks.All, s);
            //string jsonDataGeneral = JsonConvert.SerializeObject(All.Books);
            //File.WriteAllText("C:\\Users\\This User\\Desktop\\שנה ב\\שעורי בית\\c#\\ui\\Dall\\bin\\Debug\\net6.0\\FileGeneral.json", jsonDataGeneral);
            //דסרזלציה
            string existingJson = File.ReadAllText("C:\\Users\\This User\\Desktop\\שנה ב\\שעורי בית\\c#\\ui\\Dall\\bin\\Debug\\net6.0\\FileGeneral.json");
            List<Book> dataList = JsonConvert.DeserializeObject<List<Book>>(existingJson);
            return All.Books;
        }

        //מחזיר רשימה של האינדקסים המופיעה המילה
        public static List<int> SearchIndex(string word)
        {
            List<int> l = new List<int>();
            string data = DalClass.getText();
            int index = 0;
            while (index != -1)
            {
                index = data.IndexOf(word, index + 1);
                l.Add(index);
            }
            return l;
        }

        //מחזיר רשימה של פסוקים בכל התנך בהם מופיעה המילה
        public static List<Verse> Search1(Dictionary<eTypesData, string> valuesData)
        {

            List<Verse> verses = new List<Verse>();
            List<Book> tempList = new List<Book>();
            tempList = list;
            int i = 0, j = 0;
            List<Chapter> chapters = new List<Chapter>();
            List<Verse> varss = new List<Verse>();
            if (valuesData.ContainsKey(eTypesData.sefer))
            {
                eBooks b = (eBooks)Enum.Parse(typeof(Dto.eBooks), valuesData[eTypesData.sefer]);
                Book book = (Book)list[b.GetHashCode() - 2];
                tempList.Add(book);
            }

            if (valuesData.ContainsKey(eTypesData.pasuk))
                i = Text.convertStrTo(valuesData[eTypesData.pasuk]) - 1;
            if (valuesData.ContainsKey(eTypesData.perek))
                j = Text.convertStrTo(valuesData[eTypesData.perek]) - 1;

            foreach (Book b in tempList)
            {
                if (j != 0 && j < b.chapters.Count())
                {
                    chapters.Add(b.chapters[j - 1]);
                    b.chapters = chapters;
                }
                foreach (Chapter c in b.chapters)
                {
                    if (c.verses != null)
                        if (i != 0)
                        {
                            c.verses = varss;
                            verses.Add(c.verses[i - 1]);

                        }
                    foreach (Verse verse in c.verses)
                        if (verse.Data.Contains(valuesData[eTypesData.word]))
                            verses.Add(verse);
                }

            }
            return verses;
        }


        public static List<Verse> Search2(Dictionary<eTypesData, string> valuesData)
        {

            List<Verse> verses = new List<Verse>();
            List<Book> tempList = new List<Book>();
            string word = valuesData[eTypesData.word];
            int i = 0, j = 0;
            if (valuesData.ContainsKey(eTypesData.pasuk))
                i = Text.convertStrTo(valuesData[eTypesData.pasuk]) - 1;
            if (valuesData.ContainsKey(eTypesData.perek))
                j = Text.convertStrTo(valuesData[eTypesData.perek]) - 1;
            if (j == -1)
                massage = true;

            ////////////////////////ספרים פסוקים ופרקים//////////////////////////
            if (valuesData.ContainsKey(eTypesData.sefer))
            {
                eBooks b = (eBooks)Enum.Parse(typeof(Dto.eBooks), valuesData[eTypesData.sefer]);
                Book book = (Book)list[b.GetHashCode() - 2];

                if (valuesData.ContainsKey(eTypesData.perek))
                {
                    //מחזיר רשימה של פסוקים ומחפש בספר פרק ופסוק הרצוי
                    if (valuesData.ContainsKey(eTypesData.pasuk))
                    {
                        if (j < book.chapters.Count() && book.chapters[j].verses.Count() > i && book.chapters[j].verses[i].Data.Contains(word))
                            verses.Add(book.chapters[j].verses[i]);
                    }

                    //מחזיר רשימה של פסוקים  בתוך פרק וספר מבוקשים בהם מופיעה המילה המבוקשת
                    else
                    {
                        if (book.chapters.Count() >= j)
                        {
                            Chapter Chapter = book.chapters[j - 1];
                            foreach (Verse v in Chapter.verses)
                            {
                                // if (Chapter != null && Chapter.verses != null)
                                if (v.Data.Contains(word))
                                    verses.Add(v);
                            }
                        }
                    }
                }
                else if (valuesData.ContainsKey(eTypesData.perek))
                {
                    foreach (Chapter chapter in book.chapters)
                    {
                        if (i < chapter.verses.Count())
                        {
                            if (chapter.verses[i].Data.Contains(word))
                                verses.Add(chapter.verses[i]);
                        }

                    }
                }
                else
                {
                    //מחזיר רשימה של פסוקים מתוך ספר רצוי
                    foreach (Chapter c in book.chapters)
                    {
                        if (c.verses != null)
                            foreach (Verse verse in c.verses)
                                if (verse.Data.Contains(word))
                                    verses.Add(verse);
                    }
                }
            }
            ///////////////// פרקים ופסוקים////////////////////
            else if (valuesData.ContainsKey(eTypesData.perek))
            {

                ////מחזיר פסוק אם נמצא בו מוקד ע"י פרק ופסוק
                if (valuesData.ContainsKey(eTypesData.pasuk))
                {
                    {
                        foreach (Book b in list)
                        {
                            if (j < b.chapters.Count() && b.chapters[j].verses.Count() > i && b.chapters[j].verses[i].Data.Contains(word))
                            {
                                verses.Add(b.chapters[j].verses[i]);
                            }
                        }
                    }
                }
                //מחזירה את כל הפסוקים שקיימים במילה בפרקים המבוקשים בכל התנך
                else
                {
                    foreach (Book b in list)
                    {
                        if (j < b.chapters.Count())
                        {
                            foreach (Verse verse in b.chapters[j].verses)
                                if (verse.Data.Contains(word))
                                    verses.Add(verse);
                        }
                    }
                }
            }

            ////////////////////פסוקים//////////////////////
            //מציג את הפסוק המבוקש
            else if (valuesData.ContainsKey(eTypesData.pasuk))
            {
                foreach (Book b in list)
                {
                    foreach (Chapter c in b.chapters)
                    {
                        if (i < c.verses.Count)
                            if (c.verses[i].Data.Contains(word))
                                verses.Add(c.verses[i - 1]);
                    }
                }
            }

            //חיפוש לא ממוקד

            else
            {
                foreach (Book b in list)
                {
                    foreach (Chapter c in b.chapters)
                    {
                        if (c.verses != null)
                            foreach (Verse verse in c.verses)
                                if (verse.Data.Contains(valuesData[eTypesData.word]))
                                    verses.Add(verse);
                    }
                }
            }
            return verses;
        }

        //מחזיר רשימה של פסוקים בתוך ספר מבוקש בהם מופיעה המילה המבוקשת
        public static List<Verse> Search(Dto.eBooks nameBook, string word)
        {
            List<Verse> verses = new List<Verse>();
            Book book = (Book)list[nameBook.GetHashCode() - 2];
            foreach (Chapter c in book.chapters)
            {
                if (c.verses != null)
                    foreach (Verse verse in c.verses)
                        if (verse.Data.Contains(word))
                            verses.Add(verse);
            }
            return verses;
        }

        public static List<Verse> Search( string word)
        {
            List<Verse> verses = new List<Verse>();
            foreach (Book book in list)
            {
                foreach (Chapter c in book.chapters)
                {
                    if (c.verses != null)
                        foreach (Verse verse in c.verses)
                            if (verse.Data.Contains(word))
                                verses.Add(verse);
                }
            }
            return verses;
        }

        //מחזיר רשימה של פסוקים  בתוך פרק מבוקש בהם מופיעה המילה המבוקשת
        public static List<Verse> Search(eBooks nameBook, string chapter, string word)
        {
            List<Verse> verses = new List<Verse>();
            Book book = (Book)list[nameBook.GetHashCode() - 2];
            int i = Text.convertStrTo(chapter);
            if (i == -1)
                massage = true;
            if (book.chapters.Count() >= i)
            {
                Chapter Chapter = book.chapters[i - 1];
                foreach (Verse v in Chapter.verses)
                {
                    if (Chapter != null && Chapter.verses != null)
                        if (v.Data.Contains(word))
                            verses.Add(v);
                }
            }
            return verses;
        }

        //מחזיר ררשימה של פסוקים ומחפש בספר הרצוי
        public static List<Verse> SearchByVers(eBooks nameBook, string vers, string word)
        {
            List<Verse> verses = new List<Verse>();
            Book book = (Book)list[nameBook.GetHashCode() - 2];
            int i = Text.convertStrTo(vers) - 1;
            foreach (Chapter chapter in book.chapters)
            {
                if (i < chapter.verses.Count())
                {
                    if (chapter.verses[i].Data.Contains(word))
                        verses.Add(chapter.verses[i]);
                }

            }
            return verses;
        }

        //מחזירה את כל הפסוקים שקיימים במילה בפרקים המבוקשים בכל התנך
        public static List<Verse> Search(string chapter, string word)
        {
            List<Verse> verses = new List<Verse>();
            foreach (Book b in list)
            {
                int i = Text.convertStrTo(chapter) - 1;
                if (i < b.chapters.Count())
                {
                    foreach (Verse verse in b.chapters[i].verses)
                        if (verse.Data.Contains(word))
                            verses.Add(verse);
                }
            }
            return verses;
        }

        //מחזירה את כל הפסוקים שקיימים במילה בפסוקים המבוקשים בכל התנך
        public static List<Verse> SearchV(string vers, string word)
        {
            List<Verse> verses = new List<Verse>();
            int i = Text.convertStrTo(vers) -1;
            foreach (Book b in list)
            {
                foreach (Chapter c in b.chapters)
                {
                    if (i < c.verses.Count())
                        if (c.verses[i].Data.Contains(word))
                            verses.Add(c.verses[i]);
                }
            }
            return verses;
        }

        //מחזיר פסוק אם נמצא בו מוקד ע"י פרק ופסוק
        public static List<Verse> Search(string chapter, string vers, string word)
        {
            List<Verse> verss = new List<Verse>();
            int i = Text.convertStrTo(chapter) - 1;
            int j = Text.convertStrTo(vers) - 1;
            foreach (Book b in list)
            {
                if (i < b.chapters.Count && b.chapters[i].verses.Count > j)
                {
                    verss.Add(b.chapters[i].verses[j]);
                }
            }
            return verss;
        }

        //מציג את הפסוק המבוקש
        public static List<Verse> Search(eBooks nameBook, string chapter, string vers, string word)
        {
            List<Verse> verss = new List<Verse>();
            Book book = (Book)list[nameBook.GetHashCode() - 2];
            int i = Text.convertStrTo(chapter) - 1;
            int j = Text.convertStrTo(vers) - 1;
            if (i < book.chapters.Count && book.chapters[i].verses.Count > j)
                verss.Add(book.chapters[i].verses[j]);
            return verss;
        }
        //שומר בקובץ גיסון חיפושים אחרונים
        public static void saveSearch(Dictionary<eTypesData, string> valuesData)
        {
            //דסרליזציה
            string existingJson = File.ReadAllText("C:\\Users\\This User\\Desktop\\שנה ב\\שעורי בית\\c#\\ui\\Dall\\bin\\Debug\\net6.0\\jsonLastSearch.json");
            List<SearchData> dataList = JsonConvert.DeserializeObject<List<SearchData>>(existingJson);
            //List<SearchData> dataList=new List<SearchData>();
            dataList.Add(new SearchData(valuesData));
            //סרליזציה
            string jsonLastSearch = JsonConvert.SerializeObject(dataList);
            File.WriteAllText("C:\\Users\\This User\\Desktop\\שנה ב\\שעורי בית\\c#\\ui\\Dall\\bin\\Debug\\net6.0\\jsonLastSearch.json", jsonLastSearch);

        }
        //מחזיר רשימת חיפושים אחרונים
        public static List<SearchData> GetsaveSearch1()
        {
            //סרליזציה
            List<SearchData> l = new List<SearchData>();
            string existingJson = File.ReadAllText("C:\\Users\\This User\\Desktop\\שנה ב\\שעורי בית\\c#\\ui\\Dall\\bin\\Debug\\net6.0\\jsonLastSearch.json");
            List<SearchData> dataList = JsonConvert.DeserializeObject<List<SearchData>>(existingJson);
            return dataList;
        }
        public static List<string> GetsaveSearch()
        {
            List<SearchData> lis = GetsaveSearch1();
            List<string> l = new List<string>();
            foreach (SearchData s in lis)
                l.Add(s.word);
            return l;
        }


    }

}
