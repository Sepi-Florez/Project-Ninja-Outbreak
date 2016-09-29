using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {
    public bool main;
    public bool gameToggle;
	Animator anim;
	public GameObject[] menus;
	GameObject currentMenu;
	public void Awake () {
		for(int a = 0; a < menus.Length; a++){
			menus[a].SetActive(false);
		}
		currentMenu = menus[0];
        anim = currentMenu.GetComponent<Animator>();
        currentMenu.SetActive(true);
        if (main == true) {
            
            anim.SetBool("IsOpen", true);
        }
        
        
	}
	public void ChangeMenu (GameObject menu) {
        print("Menu Change");
		anim.SetBool("IsOpen", false);
		menu.SetActive(true);
		anim = menu.GetComponent<Animator>();
		menu.SetActive(true);
		anim.SetBool("IsOpen", true);
		currentMenu = menu;
        main = true;
	}
	public void Update () {
        Escape();
	}
    public void Escape() {
        if (Input.GetButtonDown("Cancel")) {
            if (main == false) {
                InGameChange();
            }
            else {
                MainMenuChange();
            }
        }
    }
    public void InGameChange () {
        gameToggle = !gameToggle;
        transform.GetChild(0).gameObject.SetActive(gameToggle);
        anim.SetBool("IsOpen", gameToggle);
        print("Escape");
    }
    public void MainMenuChange () {
        anim.SetBool("IsOpen", false);
        currentMenu = menus[0];
        anim = currentMenu.GetComponent<Animator>();
        anim.SetBool("IsOpen", true);
        main = false;
    }
}
