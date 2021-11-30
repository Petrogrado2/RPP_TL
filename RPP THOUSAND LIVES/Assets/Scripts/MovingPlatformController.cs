using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{

    [SerializeField] private Vector3 plataformDestination;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Debug.DrawLine(transform.position, transform.position + plataformDestination, Color.red);
    }
}
