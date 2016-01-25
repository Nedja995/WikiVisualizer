
using System;

namespace WikiVis.Datas
{
    /// <summary>
    /// Base Battle datas
    /// </summary>
    public class EventBattle : Event
    {
        public BattleParticipant[] Agressors;
        public BattleParticipant[] Defenders;
    }

    public class BattleParticipant : Participant
    {
        int Solders;
    }

}
