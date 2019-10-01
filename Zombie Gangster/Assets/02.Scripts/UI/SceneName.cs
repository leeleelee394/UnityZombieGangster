using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneName : MonoBehaviour {
    public static SceneName instance;

    void Awake()
	{
		if(!instance)
		{
			instance=FindObjectOfType(typeof(SceneName))as SceneName;
			//as:프리팹을 인스턴스화시켜준답디다

			if(!instance) Debug.LogError("없어");					
		}
		
		//NowSceneName.Name = NowSceneName;
		DontDestroyOnLoad(gameObject);
	}

    public string Name;
}
