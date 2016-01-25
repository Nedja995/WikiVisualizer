using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WikiVis;
using WikiVis.Datas;

namespace WikiVis.Parsers
{
    class ParserBattle : Parser<EventBattle>
    {
        private string getClear(string str)
        {
            string someString = str.EndsWith("\"") ? str.Substring(0, str.Length - 1) : str;
           // someString = str.StartsWith("\"") ? str.Substring(1, str.Length - 1) : str;
            return someString;
        }
        public EventBattle Parse(string text)
        {
            EventBattle ret = new EventBattle();

            //check
            string[] battleParams = text.Split(',');
            if(battleParams.Length <= 3)
            {
                return ret;
            }
            //Name
            ret.Name = battleParams[0];
            //Url
            ret.ReferenceURL = battleParams[1];
            //Check coordinate strings
            string[] coordScraped = battleParams[2].Split('/');
            if(coordScraped.Length == 3)
            {
                string[] longAndLat = coordScraped[2].Split(';');
                ret.Longitude = float.Parse(longAndLat[0]); 
                string clearStr = getClear(longAndLat[1]); //clear param
                ret.Latitudue = float.Parse(clearStr);
            }
            //  
            ret.DateStart = battleParams[3];

            return ret;
        }
    }
}
