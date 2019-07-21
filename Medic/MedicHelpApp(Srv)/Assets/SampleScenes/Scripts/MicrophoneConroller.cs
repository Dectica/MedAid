using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneConroller : MonoBehaviour
{
    private AudioClip audioClip;
    void Start()
    {
        if (Microphone.devices.Length > 0)
        {
            //string selectredDevice = Microphone.devices[0].ToString();
            //audioClip = Microphone.Start(selectredDevice,true,);
        }
    }

    void UpdateMicrophone()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
