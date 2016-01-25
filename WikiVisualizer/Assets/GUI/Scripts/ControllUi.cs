using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControllUi : MonoBehaviour {

    public GMapStaticImage gMapStaticImage;

    public Slider zoomSlider;

	// Use this for initialization
	void Start () {
	
	}
	

    public void ZoomChanged()
    {
        gMapStaticImage.zoom = (int)zoomSlider.value;
    }

	// Update is called once per frame
	void Update () {
	
	}
}
