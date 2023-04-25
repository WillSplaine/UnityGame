using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleDoorSFX : MonoBehaviour
{
    // Start is called before the first frame update

    AudioSource doorOpen;
    AudioSource doorClose;
    // Start is called before the first frame update
    void Start()
    {
        doorClose = GetComponent<AudioSource>();
        doorOpen = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void playDoorOpen()
    {
        doorOpen.Play();
    }
    public void playDoorClose()
    {
        doorClose.Play();
    }
}
