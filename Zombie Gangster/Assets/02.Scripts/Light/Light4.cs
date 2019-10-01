using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light4 : MonoBehaviour {

    private Light theLight;
    private float targetIntensity;  //묙표로 하는 빛이 세기
    private float currentIntensity;


	// Use this for initialization
	void Start () {
        theLight = GetComponent<Light>();
        currentIntensity = theLight.intensity;
        targetIntensity = Random.Range(0.4f, 0.6f);
	}
	
	// Update is called once per frame
	void Update () {
        
		if(Mathf.Abs(targetIntensity - currentIntensity) >=0.01)
        {
            if(targetIntensity -currentIntensity>=0)
            {
                currentIntensity += Time.deltaTime * 3f;
            }
            else
            {
                currentIntensity -= Time.deltaTime * 3f;
            }
            theLight.intensity = currentIntensity;
            theLight.range = currentIntensity+10;

        }
        else
        {
            targetIntensity = Random.Range(0.4f, 0.6f);

        }
	}
}
