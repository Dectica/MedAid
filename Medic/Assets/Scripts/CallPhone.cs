using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallPhone : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Call()
    {
        Application.OpenURL("tel://112");
    }
}
