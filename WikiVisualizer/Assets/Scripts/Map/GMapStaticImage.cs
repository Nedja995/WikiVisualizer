using UnityEngine;
using System.Collections;

// Get the latest webcam shot from outside "Friday's" in Times Square
public class GMapStaticImage : MonoBehaviour
{
    #region REQUEST_DATAS
    public Vector2 coo = new Vector2(64.88833f, 28.88889f);
    public int zoom = 5;
    public MapType type;
    public Vector2 size = new Vector2(800, 600);
    public Vector2[] markers;

    public string urlBase = "http://maps.google.com/maps/api/staticmap?";
    public string url = "http://maps.google.com/maps/api/staticmap?center=64.88833,28.88889&zoom=5&size=800x600&type=hybrid&sensor=true";
    #endregion

    public enum MapType{
        satellite,
        hybrid
    };



    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    /// <summary>
    /// Set map zoom
    /// </summary>
    /// <param name="zoom">from 0 to 17</param>
    public void Zoom(int zoom)
    {
        this.zoom = zoom;
    }

    /// <summary>
    /// Make request url string 
    /// for Google Static Maps
    /// </summary>
    /// <param name="coo"></param>
    /// <param name="size"></param>
    /// <param name="zoom"></param>
    /// <param name="type"></param>
    /// <returns>string url</returns>
    private string MakeUrlRequest(Vector2 coo, Vector2 size, int zoom, MapType type, Vector2[] markers)
    {
        string ret = urlBase                                          // request base string adress
            + "center=" + coo[0].ToString() + "," + coo[1].ToString() // + position
            + "&zoom=" + zoom.ToString()                              // + zoom
            + "&size=" + size[0].ToString() + "x" + size[1].ToString()// + size
            + "&maptype=" + type.ToString();                          // +maptype
            // + "&markers=size:mid%7Ccolor:0xff0000%7Clabel:1%7C" + coo[0].ToString() + "," + coo[1].ToString() // + marker example
            // + "&markers=size:mid%7Ccolor:0xff0000%7Clabel:1%7C" + coo[1].ToString() + "," + coo[1].ToString();// + marker example

        //add markers to request
        foreach (Vector2 marker in markers)
        {
            ret += "&markers=size:mid%7Ccolor:0xff0000%7Clabel:1%7C" + marker[0].ToString() + "," + marker[1].ToString();
        }

        return ret;
    }

    /// <summary>
    /// Download image and set buffer
    /// Call with StartCoroutine
    /// </summary>
    /// <returns>yield</returns>
    private IEnumerator _refreshImage()
    {
        //make url
        string reqUrl = MakeUrlRequest(this.coo, this.size, this.zoom, this.type, this.markers);
        //request
        WWW www = new WWW(reqUrl);
        //wait
        yield return www;
        //set buffer
        _buffer = www.texture;
    }

    void Update()
    {
        //optimizing image refresh rate
        if(_frameCount++ < 30)
        {
            //refresh gui
            if(_buffer != null)
            {
                //change gui material
                _renderer.material.mainTexture = _buffer;
                //clean buffer
                _buffer = null;
            }
        }
        else
        {
           //download image and fill buffer
           StartCoroutine(_refreshImage());
            _frameCount = 0;
        }
    }

    #region PRIVATE
    private Renderer _renderer;
    private Texture2D _buffer; //map image buffer
    private int _frameCount = 0; //optimizing image refresh rate
    #endregion
}