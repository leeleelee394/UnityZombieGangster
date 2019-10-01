using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TimerNum : MonoBehaviour {

	private float time=120f;

	int count;

	private GameObject slider;
	private Slider sl;

	//텍스트용
	public Text timeText;


	// Use this for initialization
	void Start () {
        //slider = GameObject.Find("Slider");
        //sl = slider.GetComponent<Slider>();
        timeText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {		

		// 한 프레임 마다 깍아준다
		time -= Time.deltaTime;
		//sl.value = time/120f;

		//timeText.text=$"{time:N2}";
			//timeText.text=time.ToString();
		
		/*
		string.Foramt을 사용한다. 문자열 내에 {}을 쓰고 변수를 넣을 순서대로 0, 1, 2를 쓴다.

추가적인 형식이 필요한 경우 인덱스 다음에 : 을 쓰고 형식을 서술한다.

N과 F를 사용해 소수점 몇 번째 까지만 표시할 수 있다. N2를 쓰면 소수점 둘째 자리까지 표시하겠다는 의미이다.
 */
		
	
		//timeText.text=Mathf.Ceil(time).ToString();
		//timeText.text=string.Format("{0:N2}", time);
		int min=(int)time/60;
		int sec=(int)time-(min*60);
		int sec1=sec/10;
		int sec2=sec%10;
        timeText.text = "Time " + min + ":" + sec1 + sec2;
        //timeText.text=string.Format("Time : " + min.ToString()+":"+sec1.ToString()+sec2.ToString());
		//timeText.text=string.Format("{00:00",time);
		//timeText.text=""+time.ToString("00.00");
		//timeText.text=timeText.Replaace(".",":");


		
	}
}
