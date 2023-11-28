using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Microphone.Start(null, true, 10, 44100);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Microphone.End(null);
            audioSource.Play();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.clip = Microphone.Start(null, true, 10, 44100);
        }
    }
}
