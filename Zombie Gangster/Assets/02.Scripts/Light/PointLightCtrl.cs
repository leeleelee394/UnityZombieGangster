using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLightCtrl : MonoBehaviour {

    private Light theLight;
    private Transform tr;

	// Use this for initialization
	void Start () {
        theLight = GetComponent<Light>();
        tr = GetComponent<Transform>();
        //tr.transform.position = new Vector3(0, 7, -1);
        //theLight.color = Color.yellow; 
    }
	

}
