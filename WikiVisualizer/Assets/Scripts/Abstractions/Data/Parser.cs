
namespace WikiVis
{
    interface Parser<WikiVisData>
    {
        WikiVisData Parse(string text);
    }
}