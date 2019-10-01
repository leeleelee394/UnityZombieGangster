using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxKill : MonoBehaviour {

    private Text maxKillText;

	// Use this for initialization
	void Start () {
        ManagerClass.Instance.LoadKillDataToJson();
        maxKillText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        maxKillText.text = "Max Kill : " + ManagerClass.Instance.maxKillNum;
	}
}
