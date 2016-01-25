
using System;

namespace WikiVis
{
    /// <summary>
    /// Base Battle datas
    /// </summary>
    public class BattleData : WikiVisData
    {
        public string Date;
        public BattleParticipant[] Agressors;
        public BattleParticipant[] Defenders;
        public float Longitude;
        public float Latitudue;
    }

    public class BattleParticipant : WikiVisData
    {
        int Solders;
    }

}
