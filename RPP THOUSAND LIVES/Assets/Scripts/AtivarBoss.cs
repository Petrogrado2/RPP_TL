using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivarBoss : MonoBehaviour
{
    public delegate void StartBoss();

    public static event StartBoss OnTriggered;

    public bool bossTrigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.CompareTag("Player"))
        {
            if (OnTriggered != null)
            {
                OnTriggered();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
