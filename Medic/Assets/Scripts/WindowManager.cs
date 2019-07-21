using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BodyPart
{
    Head, Chest, Shoulder, Arm, Leg, None, Foot
}


public class WindowManager : MonoBehaviour
{
    public GameObject currentWindow;

    public GameObject SkipPanel;
    public List<GameObject> windows;

    public BodyPart damagedPart = BodyPart.None;

    public bool firstOpening = true;

    RectTransform myRect;

    private void Start()
    {
        myRect = GetComponent<RectTransform>();
    }
    public void ChangeWndow(string name)
    {
        foreach(GameObject go in windows)
        {
            if(go.name == name)
            {

                //Vector3 pos = currentWindow.transform.position;
                Vector3 pos = currentWindow.GetComponent<RectTransform>().position;
                Destroy(currentWindow);
                //currentWindow = Instantiate(go, pos, Quaternion.identity);
                currentWindow = Instantiate(go);
                currentWindow.transform.SetParent(transform);
                var currentRect = currentWindow.GetComponent<RectTransform>();

                currentRect.position = pos;
                currentRect.sizeDelta = Vector2.zero;
                if(name == "SkipPanel" )
                {
                    if(firstOpening)
                        firstOpening = false;
                    else
                    {
                        ChangeWndow("SelectBody");
                        
                    }
                }

                return;
            }
        }
    }


}