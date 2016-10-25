using UnityEngine;
using System.Collections;

//give all interactable items / enemies "Interactable" tag
public class Select : MonoBehaviour {
    public GameObject selectedObject;
    public MouseCursor mouse;
    void Start () {
       mouse = GameObject.Find("Cursor").GetComponent<MouseCursor>();  ;
    }
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            //Debug.Log("Mouse over:" + hitInfo.collider.name);
            GameObject hitObject = hitInfo.transform.root.gameObject;
            if (hitInfo.collider.tag == "Interactable")
            {
                mouse.Big();
            }
            SelectObject(hitObject);
        }
        else
        {
            ClearSelection();
        }
    }
    void SelectObject(GameObject obj)
    {
        if (selectedObject != null)
        {
            if (obj == selectedObject)
                return;
            ClearSelection();
        }
        selectedObject = obj;
    }
    void ClearSelection()
    {
        selectedObject = null;
        mouse.Normal();
    }
}
