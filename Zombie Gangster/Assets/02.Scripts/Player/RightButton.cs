using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    private bool buttonDown = false;
    public float rotSpeed = 50f;
    private GameObject player;
    Vector3 rotation;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonDown)
        {
            rotation += Vector3.up * rotSpeed * Time.deltaTime;
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
