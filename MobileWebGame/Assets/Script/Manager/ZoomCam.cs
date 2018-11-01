using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCam : MonoBehaviour {
    public Vector3 touchStart;
    public float zoomOutMin = 1f;
    public float zoomOutMax = 8f;

    public Camera cam;
    public float orthoZoomSpeed = .5f;
    public float PerfectiveZoomSpeed = .5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ManageZoom();
	}

    void ManageZoom() {
        // PC
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(0)) {
            Vector3 dir = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position += dir;
        }
        zoom(Input.GetAxis("Mouse ScrollWheel"));

        //Mobile
        if (Input.touchCount == 2)
        {
            Touch touchzero = Input.GetTouch(0);
            Touch touzeOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchzero.position - touchzero.deltaPosition;
            Vector2 touchOnePrevPos = touzeOne.position - touzeOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchzero.position - touzeOne.position).magnitude;

            float diff = currentMagnitude - prevMagnitude;

            if (cam.orthographic)
            {
                cam.orthographicSize += diff * orthoZoomSpeed;
                cam.orthographicSize = Mathf.Max(cam.orthographicSize, .1f);
            }
            else {
                cam.fieldOfView += diff * PerfectiveZoomSpeed;
                cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, .1f , 179.9f);
            }

            //zoom(diff * 0.01f);
        }
    }

    void zoom(float increment) {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin,zoomOutMax);
    }
}
