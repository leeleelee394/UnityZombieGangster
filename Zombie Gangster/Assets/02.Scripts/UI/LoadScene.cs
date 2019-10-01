using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadScene : MonoBehaviour {

	public void GoLobby()
	{
        //SceneName.instance.Name="Rooms";
        //SceneManager.LoadScene("Loading");	
        SceneManager.LoadScene("SimpleTown_DemoScene");
    }

	public void GoMain()
	{
        //SceneName.instance.Name="Main";
        //SceneManager.LoadScene("Loading");	
        SceneManager.LoadScene("Main");
	}

	public void GoPlay()
	{				
		SceneName.instance.Name="Play";
		SceneManager.LoadScene("Loading");	
	}


	//로딩없이 발생
	public void GoRanking()
	{				
		SceneName.instance.Name="Over_Ranking";
		SceneManager.LoadScene("Over_Ranking");	
	}

	public void GoKill()
	{				
		SceneName.instance.Name="GoKill";
		SceneManager.LoadScene("GoKill");	
	}

}
