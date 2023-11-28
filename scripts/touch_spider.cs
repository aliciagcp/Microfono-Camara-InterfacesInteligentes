using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch_spider : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update


    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("spider")) {
            audioSource.Play();
        }
    }
}
