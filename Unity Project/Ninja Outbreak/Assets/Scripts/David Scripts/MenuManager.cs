using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {
	
	Animator anim;
	public GameObject[] menus;
	GameObject currentMenu;
	public void Awake () {
			currentMenu = menus[0];
			currentMenu.SetActive(true);
			anim = currentMenu.GetComponent<Animator>();
			anim.SetBool("IsOpen",true);
	}
	public void ChangeMenu (GameObject menu) {
		anim.SetBool("IsOpen", false);
		menu.SetActive(true);
		anim = menu.GetComponent<Animator>();
		menu.SetActive(true);
		anim.SetBool("IsOpen", true);
		currentMenu = menu;
	}
	public void Update () {
		if(Input.GetButtonDown("Cancel")){
			print("back");
			anim.SetBool("IsOpen", false);
			currentMenu = menus[0];
			anim = currentMenu.GetComponent<Animator>();
			anim.SetBool("IsOpen", true);
		}
	}
}
