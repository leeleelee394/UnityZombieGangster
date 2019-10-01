using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour {

	private float time=120f;

	int count;

	private GameObject slider;
	private Slider sl;
	private Animator ani;

	//텍스트용
	public Text timeText;
	//private float time;


	// Use this for initialization
	void Start () {
		slider = GameObject.Find("Slider");
		sl = slider.GetComponent<Slider>();
		ani = GameObject.Find("TimeCheck").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {		

		//시간 완료 시 게임오버화면
		if(time<=0f) 
		{
			SceneManager.LoadScene("Over");	
		}


		// 한 프레임 마다 깍아준다
		//time -= Time.deltaTime;
		//sl.value = time/120f;

		
		//timeText.text=string.Format("{0:N2}", time);
		//timeText.text=time.ToString();
		//timeText.text=Mathf.Ceil(time).ToString();
		//timeText.text=$"{time:N2}";

		//일정시간 내에 도달하면 색상 변경됨
		if(time<=40f)		
		{			
			ani.SetTrigger("Time");
		}
	}
}
