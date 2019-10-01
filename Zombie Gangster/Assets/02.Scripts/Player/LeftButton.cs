using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    private bool buttonDown = false;
    public float rotSpeed = 50f;
    public GameObject player;
    Vector3 rotation;

    void Start()
    {
        player = GameObject.Find("Player");
        
    }

	// Update is called once per frame
	void Update () {
		if(buttonDown)
        {
            rotation += -Vector3.up * rotSpeed * Time.deltaTime;
            player.transform.rotation = Quaternion.Euler(rotation);
        }
	}

    public void OnPointerDown(PointerEventData eventData)
    {
        rotation = player.transform.eulerAngles;
        buttonDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonDown = false;
    }
}
