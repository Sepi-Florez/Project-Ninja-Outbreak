using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
	
	public void menu (int i) {
		switch(i){
			case 0:
                SceneManager.LoadScene("IngameMenu", LoadSceneMode.Single);
                //Application.LoadLevel("IngameMenu");
                break;
			case 1: 
				print("Continue from last save");
				break;
			case 2:
				print("Load Game");
				break;
			case 3:
				break;
			case 4:
				break;
			case 5:
                SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
                //Application.LoadLevel("MainMenu");
                break;
			case 6:
				Application.Quit();
				break;
			
		}
	}
}
