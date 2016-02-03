using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using WikiWis;
using System;

namespace WikiWis {
    public class Marker {
        public Marker(Vector2 absoloute)
        {
            absoluteCoodinates = absoloute;
        }
        public Vector2 absoluteCoodinates;
        public Vector2 relativeCoodinates;
    }
}

public class GMapStaticImage : MonoBehaviour
{
    #region REQUEST_DATAS
    public Vector2 coo = new Vector2(0f, 0f);
    public int zoom;
    public MapType type;
    public Vector2 size = new Vector2(800, 600);
    public ArrayList markers;
    public Vector2[] markersList;

    private string urlBase = "http://maps.google.com/maps/api/staticmap?";
    public String url;// http://maps.google.com/maps/api/staticmap?center=64.88833,28.88889&zoom=5&size=800x600&type=hybrid&sensor=true";
    #endregion

    public bool RefreshImage
    {
        get; set;
    }

    public List<Marker> _relativeMarkers;

    public enum MapType{
        satellite,
        hybrid
    };

    public GameObject markerLabelPrefab;
    public GameObject markersContainer;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
        if(this.markers == null)
        {
            this.markers = new ArrayList();
        }
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
    private string MakeUrlRequest(Vector2 coo, 
                                  Vector2 size, 
                                  int zoom, 
                                  MapType type, 
                                  ArrayList markers)
    {
        //Check coordinates
        int maxLat = 6 * zoom;
        if(coo[1] > maxLat || coo[1] < -maxLat)
        {
            //Wrong latitude
            Debug.LogWarning("Latitude wrong");
            if(coo[1] < 0)
            {
                coo[1] = -maxLat;
            }
            else
            {
                coo[1] = maxLat;
            }
        }

        string ret = urlBase                                          // request base string adress
            + "center=" + coo[0].ToString() + "," + coo[1].ToString() // + position
            + "&zoom=" + zoom.ToString()                              // + zoom
            + "&size=" + size[0].ToString() + "x" + size[1].ToString()// + size
            + "&maptype=" + type.ToString();                          // + maptype
                                                                      // + "&markers=size:mid%7Ccolor:0xff0000%7Clabel:1%7C" + coo[0].ToString() + "," + coo[1].ToString() // + marker example
                                                                      // + "&markers=size:mid%7Ccolor:0xff0000%7Clabel:1%7C" + coo[1].ToString() + "," + coo[1].ToString();// + marker example

        GameObject[] gos = GameObject.FindGameObjectsWithTag("MarkerLabel");
        foreach (GameObject go in gos)
        {
            DestroyObject(go);
        }


        int count = 35;
        if (markers != null)
        {
            //add markers to request           
            foreach (Vector2 marker in markers)
            {
                
                if (count-- == 0)
                {                  
                    break;
                }
                ret += "&markers=size:mid%7Ccolor:0xff0000%7Clabel:1%7C" + marker[0].ToString() + "," + marker[1].ToString();
             //   ret += "&markers=size:mid%7Ccolor:0xff0000%7Clabel:1%7C" + marker[0].ToString() + "," + marker[1].ToString();
                GameObject mlObj = Instantiate<GameObject>(markerLabelPrefab);
                MarkerLabel ml = mlObj.GetComponent<MarkerLabel>();
                ml.coordinates = marker;
                ml.zoom = zoom;
            }
        }
        //add custom markers to request      
        if (markersList != null)
        {
           
            foreach (Vector2 marker in markersList /* gui property */)
            {
                if (count-- <= 0)
                {
                    break;
                }
                ret += "&markers=%7Clabel:1%7C" + marker[0].ToString() + "," + marker[1].ToString();
                GameObject mlObj = Instantiate<GameObject>(markerLabelPrefab);
                MarkerLabel ml = mlObj.GetComponent<MarkerLabel>();
                ml.coordinates = marker;
                ml.zoom = zoom;
            }
        }
        /* google static map api key */
        ret += "&key=AIzaSyDb-yIJTeihCDkU_GAVK67i878h88zfYIk";
        //set gui propery
        url = ret;
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
        //refresh flag
        if(RefreshImage)
        {
            if( !_refreshingImage )
            {
                _refreshingImage = true;
                //download image and fill buffer
                //like threads
                StartCoroutine(_refreshImage());

            }
            //refresh gui
            if (_buffer != null)
            {
                //change gui material
                _renderer.material.mainTexture = _buffer;
                //clean buffer
                _buffer = null;
                //reset flags
                RefreshImage = false;
                _refreshingImage = false;
            }
        }
    }

    public void AddMarker(int longitude, int latitude)
    {
        if(_relativeMarkers == null)
        {
            _relativeMarkers = new List<Marker>();
        }
        _relativeMarkers.Add(new Marker(new Vector2(longitude, latitude)));
    }



    #region PRIVATE
    private Renderer _renderer;
    private Texture2D _buffer; //map image buffer
    private bool _refreshingImage;
    #endregion
}