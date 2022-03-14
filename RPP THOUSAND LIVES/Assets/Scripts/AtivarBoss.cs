using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivarBoss : MonoBehaviour
{
    public bool activeBoss;

    public bool bossTrigger;

    public int bossState = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bossState = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
