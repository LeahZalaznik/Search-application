using Bll;
using Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UiWebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TanachApiController : ControllerBase
    {
        [HttpGet("{word}")]
        public List<Verse> Serche(string word, string sefer="",string perek="",string pasuk="")
        {   
            List<Verse> l = new List<Verse>();
            if (word != "")
                if (!sefer.Equals("") && !Enum.IsDefined(typeof(Dto.eBooks), sefer))
                    return null;
            if (!sefer.Equals("") && !perek.Equals("") && !pasuk.Equals(""))
                l = BllClass.Search((eBooks)Enum.Parse(typeof(Dto.eBooks), sefer), perek, pasuk, word);
            else if (!sefer.Equals("") && !perek.Equals("") && pasuk.Equals(""))
                l = BllClass.Search((eBooks)Enum.Parse(typeof(Dto.eBooks), sefer), perek, word);
            else if (!sefer.Equals("") && perek.Equals("") && !pasuk.Equals(""))
                l = BllClass.SearchByVers((eBooks)Enum.Parse(typeof(Dto.eBooks), sefer), pasuk, word);
            else if (sefer.Equals("") && !perek.Equals("") && !pasuk.Equals(""))
                l = BllClass.Search(perek, pasuk, word);
            else if (sefer.Equals("") && !perek.Equals("") && pasuk.Equals(""))
                l = BllClass.Search(perek, word);
            else if (sefer.Equals("") && perek.Equals("") && !pasuk.Equals(""))
                l = BllClass.SearchV(pasuk, word);             
            else if (!sefer.Equals("") && perek.Equals("") && pasuk.Equals(""))
                l = BllClass.Search((eBooks)Enum.Parse(typeof(Dto.eBooks), sefer), word);
            else if (sefer.Equals("") && perek.Equals("") && pasuk.Equals(""))
                l = BllClass.Search(word);  
            return l;
        }
    }
}
