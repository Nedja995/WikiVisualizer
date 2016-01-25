namespace WikiVis
{
    class EventMeeting : Event
    {
        /// <summary>
        /// Participants
        /// </summary>
        public Participant[] Participants;

        /// <summary>
        /// Some events created from this meeting
        /// </summary>
        public Event ResultEvent;
    }

    class MeetingParticipant : Participant
    {
        /// <summary>
        /// What offer
        /// </summary>
        public string Offer;
        /// <summary>
        /// What demand
        /// </summary>
        public string Demand;
    }

}
