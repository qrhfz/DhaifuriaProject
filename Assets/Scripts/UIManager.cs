using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	public int timerValue = 60;
	public Text timerUI;
	private Tower _tower;
	// Use this for initialization
	void Start () {
		_tower = GameObject.Find("tower").GetComponent<Tower>();
		countdownTimer();
	}

	void countdownTimer(){
		if(timerValue > 0 && _tower.hp > 0){
			TimeSpan spanTime = TimeSpan.FromSeconds(timerValue);
			timerUI.text = "Sisa waktu " + spanTime.Minutes.ToString("D2") + " : " + spanTime.Seconds.ToString("D2"); ;
			timerValue--;
			Invoke("countdownTimer", 1.0f);
		}else if(timerValue > 0 && _tower.hp == 0){
			timerUI.text = "Game Over";
			DontDestroyOnLoad(GameObject.Find("getLevel"));
			SceneManager.LoadScene("resultLose");
		}
		else{
			if (!PlayerPrefs.HasKey("level"))
            {
				PlayerPrefs.SetInt("level", 1);
			}
            else
            {
                if (GameObject.Find("getLevel").GetComponent<Getlevel>().level == PlayerPrefs.GetInt("level"))
                {
					PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
				}
				
			}
				

			timerUI.text = "Complete";
			SceneManager.LoadScene("resultWin");

		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();
	}
}
