using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenType : MonoBehaviour {

    public GameObject panel;

    private bool isActive = true;

     public void ActivePanel()
     {
        panel.SetActive(isActive);

        isActive = !isActive;
     }
}
