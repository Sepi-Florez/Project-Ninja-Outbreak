using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	public GameObject[] canvas;
	public Animator anim;
	
	public void menu (int i) {
		switch(i){
			case 0:
				print("Start Game");
				break;
			case 1: 
				print("Continue from last save");
				break;
			case 2:
				print("Load Game");
				break;
			case 3:
				//canvas[0].SetActive(false);
				anim.SetTrigger ("Move");
				//canvas[1].SetActive(true);
				break;
			case 4:
				canvas[0].SetActive(false);
				canvas[2].SetActive(true);
				break;
			case 5:
				canvas[0].SetActive(false);
				canvas[3].SetActive(true);
				break;
			case 6:
				Application.Quit();
				break;
		}
	}
}
