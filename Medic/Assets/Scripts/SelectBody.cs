using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectBody : MonoBehaviour {

    public BodyPart thisPart;
    //public ScrollRect scroll;

    // public GameObject CategoryButton, ProblemList;
    public GameObject[] gameObjects;
    bool isSelected = false;


    public void SelectBodyPart()
    {
        if (isSelected)
        {
            GetComponent<Image>().color = Color.white;
            GameObject.FindGameObjectWithTag("window").GetComponent<WindowManager>().damagedPart = BodyPart.None;
            isSelected = false;

            //scroll.vertical = false;
            //ProblemList.SetActive(false);
            //CategoryButton.SetActive(true);

            return;
        }

        foreach(Image img in transform.parent.GetComponentsInChildren<Image>())
        {
            img.color = Color.white;
        }
        GetComponent<Image>().color = Color.red;
        GameObject.FindGameObjectWithTag("window").GetComponent<WindowManager>().damagedPart = thisPart;
        isSelected = true;

        switch (thisPart)
        {
            case BodyPart.Head:
                {

                }
                break;
            case BodyPart.Chest:
                break;
            case BodyPart.Shoulder:
                break;
            case BodyPart.Arm:
                {
                    GameObject.FindGameObjectWithTag("window").GetComponent<WindowManager>().ChangeWndow("CategoryArm");
                }
                break;
            case BodyPart.Leg:
                break;
            case BodyPart.None:
                break;
            case BodyPart.Foot:
                break;
            default:
                break;
        }
         //scroll.vertical = true;
         //ProblemList.SetActive(true);
         //CategoryButton.SetActive(false);

    }
}
