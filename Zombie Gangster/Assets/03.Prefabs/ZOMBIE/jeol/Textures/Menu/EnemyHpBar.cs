using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHpBar : MonoBehaviour {

    private Camera uicamera;
    private Canvas canvas;
    private RectTransform rectparaent;

    private RectTransform rectHp;


    [HideInInspector] public Vector3 offset = Vector3.zero;

    [HideInInspector] public Transform target;


    // Use this for initialization
    void Start () {
        canvas = GetComponentInParent<Canvas>();
        uicamera = canvas.worldCamera;
        rectparaent = canvas.GetComponent<RectTransform>();
        rectHp = this.gameObject.GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        //var screenpos = Camera.main.WorldToScreenPoint(target.position + offset);
        //
        //if(screenpos.z < 0.0f)
        //{
        //    screenpos *= 1.0f;
        //}
        //
        //var localpos = Vector2.zero;
        //
        //RectTransformUtility.ScreenPointToLocalPointInRectangle(rectparaent, screenpos, uicamera, out localpos);
        //
        //
        //rectHp.localPosition = localpos;
        
            
         

	}
}
