using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
	
	public void menu (int i) {
		switch(i){
			case 0:
                SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
                //Application.LoadLevel("IngameMenu");
                break;
			case 1: 
				break;
			case 2:
				break;
			case 3:
				break;
			case 4:
				break;
			case 5:
                SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
                Destroy(GameObject.FindGameObjectWithTag("GameManager"));
                //Application.LoadLevel("MainMenu");
                break;
			case 6:
				Application.Quit();
				break;
			
		}
	}
}
