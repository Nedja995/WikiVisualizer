using UnityEngine;

namespace WikiWis
{

    public class MarkerLabel : MonoBehaviour {

        [Header("Geographic data:")]
        public Vector2 coordinates;
        [Header("Map plane:")]
        public GMapStaticImage map;
        // Use this for initialization
        void Start () {
            RefreshPosition();
        }
	
        public void RefreshPosition()
        {
            Vector2<float> worldCoord = GeoCoordPlane.CoordinatesTo2D(coordinates.x, coordinates.y,
                                                                         map.size.x, map.size.y);

            Vector3 realWorldCoord = map.Get3DAbsolutCoordinate((int)worldCoord.x, 0, (int)worldCoord.y) / 2;
            gameObject.transform.position = map.transform.position;// realWorldCoord;
        }

	    // Update is called once per frame
	    void Update () {
	
	    }
    }

}
