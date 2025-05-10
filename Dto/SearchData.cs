using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public enum eTypesData { perek,pasuk,parasha,sefer,word}
    public class SearchData
    {
        public string word { get; set; }
        public string nameBook{ get; set; }
        public string parasha { get; set; }
        public string perek { get; set; }
        public string pasuk { get; set; }
        
        public SearchData(string word)
        {
            this.word = word; 
        }
        public SearchData(string word,string nameBook)
        {
            this.word=word;
            this.nameBook=nameBook;
        }
 
        public SearchData(Dictionary<eTypesData, string> valuesData)
        {
            if (valuesData.ContainsKey(eTypesData.word))
                this.word = valuesData[eTypesData.word];
            if (valuesData.ContainsKey(eTypesData.sefer))
                this.nameBook = valuesData[eTypesData.sefer];
            if (valuesData.ContainsKey(eTypesData.parasha))
                this.parasha = valuesData[eTypesData.parasha];
            if (valuesData.ContainsKey(eTypesData.perek))
                this.perek = valuesData[eTypesData.perek];
            if (valuesData.ContainsKey(eTypesData.pasuk))
                this.pasuk = valuesData[eTypesData.pasuk];
        }

        public SearchData()
        {
            
        }

    }
}
