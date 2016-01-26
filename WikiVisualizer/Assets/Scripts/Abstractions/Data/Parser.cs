
namespace WikiVis
{
    /// <summary>
    /// Abstraction for parse for some WikiVisData class
    /// </summary>
    /// <typeparam name="WikiVisData"></typeparam>
    interface Parser<Data>
    {
        /// <summary>
        /// Parse one object of WikiVisData class type
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        Data Parse(string text);
    }
}