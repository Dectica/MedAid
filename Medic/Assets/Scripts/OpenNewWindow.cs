using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenNewWindow : MonoBehaviour {

    public void OpenWindow(string name)
    {
        GameObject.FindGameObjectWithTag("window").GetComponent<WindowManager>().ChangeWndow(name);
    }
}
