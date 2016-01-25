using UnityEngine;
using System.Collections;

using WikiVis;
using System;
using System.IO;
using System.Text;
using WikiVis.Parsers;

namespace WikiVis.Components
{
    public class DataHolder : MonoBehaviour
    {
        public GMapStaticImage map;

        public ArrayList battles;
        // Use this for initialization
        void Start()
        {
            String path = @"D:\Projects\WikiVisualizer\Datas\Scraped\fiveBattles.csv";//wikiwwtwobattles.csv";
            StreamReader theReader = new StreamReader(path, Encoding.Default);
            string text = theReader.ReadToEnd();

            string[] battles = text.Split('\n');
            foreach(string battle in battles)
            {
                BattleData bd = new ParserBattle().Parse(battle);
                if(this.battles == null) {
                    this.battles = new ArrayList();
                }
                this.battles.Add(bd);
            }
           

            foreach(BattleData battle in this.battles)
            {
                string battleName = battle.Name;
                string battleRef = battle.ReferenceURL;
                string battleDate = battle.Date;
                if(map.markers == null)
                {
                    map.markers = new ArrayList();
                }
                if(battle.Longitude > 0.0f && battle.Longitude < 90.0f 
                    || battle.Latitudue > 0.0f && battle.Latitudue < 90.0f)
                {
                    map.markers.Add(new Vector2(battle.Longitude, battle.Latitudue));
                }
            }
            int a = 2;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}