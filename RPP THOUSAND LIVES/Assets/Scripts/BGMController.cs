using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.Events;

public class BGMController : MonoBehaviour
{
    public AudioSource mainTheme;

    public AudioSource bossTheme;

    public GameObject triggerMusic;

    public bool iniciarMusica2;

    private int _variavel = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        mainTheme.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
