using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;

public class SendDataNetwork : NetworkBehaviour
{
    [SerializeField] GameObject prefabClient;
    [SerializeField] GameObject rawImagePrefab;
    [SerializeField] GameObject canvasServerPrefab;
    RawImage rawImage;

    private GameObject cam;
    private PhoneCamera phoneCamera;
    private GameObject canvasServer;

    // Start is called before the first frame update
    void Start()
    {
        if (isServer && isLocalPlayer)
        {
            canvasServer = Instantiate(canvasServerPrefab);
            rawImage = Instantiate(rawImagePrefab, canvasServer.transform).GetComponent<RawImage>();
        }
        if (!isServer && isLocalPlayer)
        {
            prefabClient = Instantiate(prefabClient);

            phoneCamera = prefabClient.transform.GetChild(0).GetComponent<PhoneCamera>();
            return;
        }
        else if (isLocalPlayer)
        {

        }
    }

    public IEnumerator TakeSnapshot()
    {
        yield return new WaitForEndOfFrame();

        if (!isServer && isLocalPlayer)
        {

            //CmdSendData(phoneCamera.background.texture);
            Texture2D texture2D = new Texture2D(phoneCamera.webCamTexture.width, phoneCamera.webCamTexture.height);
            texture2D.SetPixels(phoneCamera.webCamTexture.GetPixels());

            texture2D.Apply();
            texture2D.ReadPixels(new Rect(0, 0, texture2D.width, texture2D.height), 0, 0);
            texture2D.Apply();
            CmdSendData(texture2D.EncodeToJPG());
            
            Debug.Log("Send data");
        }
        // gameObject.renderer.material.mainTexture = TakeSnapshot;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(TakeSnapshot());
    }
    [Command]
    void CmdSendData(byte[] image)
    {
        Texture2D texture2D = new Texture2D(1, 1);
        texture2D.LoadImage(image);
        print(image);
        rawImage.texture = texture2D;
    }

    [Command]
    public void CmdUpdate()
    {
        //RpcSendData();
    }

    [ClientRpc]
    void RpcSendData(byte[] image)
    {
        if (cam == null)
        {

        }
    }
}
