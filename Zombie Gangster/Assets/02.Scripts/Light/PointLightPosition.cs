using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLightPosition : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
        GameObject[] pointLight = GameObject.FindGameObjectsWithTag("PointLight");
        for(int i = 0; i < pointLight.Length; i++)
        {
            Transform parent = pointLight[i].transform.parent;
            pointLight[i].transform.position = new Vector3(parent.position.x, parent.position.y + 7, parent.position.z - 1);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
