using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {
    public bool Main;
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
        if (Main == true) {
            
            anim.SetBool("IsOpen", true);
        }
        
        
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
        Escape();
	}
    public void Escape() {
        if (Input.GetButtonDown("Cancel")) {
            if (Main == false) {
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
    }
}
