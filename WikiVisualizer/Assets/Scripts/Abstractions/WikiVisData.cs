namespace WikiVis
{
    /// <summary>
    /// Base representation for datas
    /// </summary>
    public class Data
    {
        /// <summary>
        /// Human frendly name
        /// </summary>
        public string Name;

        /// <summary>
        /// Unique id of data representation
        /// </summary>
        public string UniqueID;

        /// <summary>
        /// Url to reference if exists
        /// </summary>
        public string ReferenceURL;
    }

    /// <summary>
    /// Base representation for events
    /// </summary>
    public class Event : Data
    {
        /// <summary>
        /// Start date
        /// </summary>
        public string DateStart;
        /// <summary>
        /// End date
        /// </summary>
        public string DateEnd;
        /// <summary>
        /// Longitude
        /// </summary>
        public float Longitude;
        /// <summary>
        /// Latitude
        /// </summary>
        public float Latitudue;

        /// <summary>
        /// Subevents if has
        /// </summary>
        public Event[] SubEvents;
    }

    public class Participant : Data
    {
        public string[] Alies;
    }

}