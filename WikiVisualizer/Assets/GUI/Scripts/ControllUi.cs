using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControllUi : MonoBehaviour {

    public GMapStaticImage gMapStaticImage;

    public Slider zoomSlider;

    public Slider latitudeSlider;
    public Slider longitudeSlider;

    // Use this for initialization
    void Start () {
	
	}
	

    public void ZoomChanged()
    {
        gMapStaticImage.zoom = (int)zoomSlider.value;
        gMapStaticImage.RefreshImage = true;
    }

    public void PositionChanged()
    {
        gMapStaticImage.coo[1] = latitudeSlider.value;
        gMapStaticImage.coo[0] = -longitudeSlider.value;
        gMapStaticImage.RefreshImage = true;
    }

	// Update is called once per frame
	void Update () {
	
	}
}
