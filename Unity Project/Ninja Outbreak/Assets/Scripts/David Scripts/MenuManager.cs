using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {
	
	Animator anim;
	public GameObject[] Menus;
	GameObject currentMenu;
	public void Awake () {
			//Menus[0] = currentMenu;
			//anim = currentMenu.GetComponent<Animator>();
			//anim.SetBool("IsOpen",true);
	}
	public void ChangeMenu (GameObject menu) {
		
		anim = menu.GetComponent<Animator>();
		currentMenu.SetActive(false);
		menu.SetActive(true);
		anim.SetTrigger("Open");
	}
}
