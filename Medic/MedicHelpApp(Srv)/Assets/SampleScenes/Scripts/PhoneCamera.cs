using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneCamera : MonoBehaviour
{
    private bool camAvailable;
    public WebCamTexture webCamTexture;
    public AspectRatioFitter fit;
    public RawImage background;

    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        if (devices.Length == 0)
        {
            Debug.Log("No camera detected");
            camAvailable = false;
            return;
        }
        for (int i = 0; i < devices.Length; i++)
        {
            //if (!devices[i].isFrontFacing)
            //{
            webCamTexture = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
            break;
            //}
        }
        if (webCamTexture == null)
        {
            Debug.Log("Unable to find back camera");
            return;
        }
        webCamTexture.Play();
        background.texture = webCamTexture;
        camAvailable = true;
    }
    


    // Update is called once per frame
    void Update()
    {
        if (!camAvailable) return;

        float ratio = (float)webCamTexture.width / (float)webCamTexture.height;
        fit.aspectRatio = ratio;

        float scaleY = webCamTexture.videoVerticallyMirrored ? -1f : 1f;
        background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        int orient = -webCamTexture.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
    }
}
