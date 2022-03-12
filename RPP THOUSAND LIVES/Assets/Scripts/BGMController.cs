using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class BGMController : MonoBehaviour
{
    public AudioSource mainTheme;

    public AudioSource bossTheme;

    
    // Start is called before the first frame update
    void Start()
    {
        mainTheme.Play();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Keyboard.current.nKey.wasPressedThisFrame)
        {
            mainTheme.mute = true;
            bossTheme.Play();
        }
    }
}
