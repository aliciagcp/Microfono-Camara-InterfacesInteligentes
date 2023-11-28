using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    // Start is called before the first frame update
    private Material tvMaterial;
    private WebCamTexture webcamTexture;
    int captureCounter = 0;
    // create a string called path were we will save the images to C:\Users\Jonay\Camara Micro\Assets
    string path = @"C:\Users\Jonay\Camara Micro\Assets\snapshots\";
    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        string selectedCameraName = devices[1].name;
        Debug.Log("Selected camera: " + selectedCameraName);
        tvMaterial = GetComponent<Renderer>().material;
        webcamTexture = new WebCamTexture(selectedCameraName);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("s"))
        {
            webcamTexture.Play();
            tvMaterial.mainTexture = webcamTexture;
        }
        if (Input.GetKey("p"))
        {
            webcamTexture.Stop();
        }
        if (Input.GetKey("x"))
        {
            Texture2D snapshot = new Texture2D(webcamTexture.width, webcamTexture.height);
            snapshot.SetPixels(webcamTexture.GetPixels());
            snapshot.Apply();
            System.IO.File.WriteAllBytes(path + captureCounter.ToString() + ".png", snapshot.EncodeToPNG());
            captureCounter++;
            Debug.Log("Snapshot taken.");
        }
    }
}
