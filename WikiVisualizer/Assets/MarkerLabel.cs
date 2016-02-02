using UnityEngine;

namespace WikiWis
{

    public class MarkerLabel : MonoBehaviour {

        [Header("Geographic data:")]
        public Vector2 coordinates;
        [Header("Map plane:")]
        public GMapStaticImage map;
        public MeshCollider _mapMesh;
        // Use this for initialization
        void Start () {
            map = GameObject.FindObjectOfType<GMapStaticImage>();
            _mapMesh = map.gameObject.GetComponent<MeshCollider>();
            
            RefreshPosition();
        }
	
        public void RefreshPosition()
        {
            Vector2 worldCoord = GeoCoordPlane.CoordinatesTo2D(-coordinates.y, -coordinates.x,
                                                                        _mapMesh.bounds.size.x, _mapMesh.bounds.size.z);

            Vector3 realWorldCoord = new Vector3(worldCoord.x,
                                                    0f,
                                                    worldCoord.y);
            gameObject.transform.position = realWorldCoord;
        }

	    // Update is called once per frame
	    void Update () {
            RefreshPosition();
        }
    }

}
