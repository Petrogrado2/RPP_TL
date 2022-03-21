using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MusicTrigger : MonoBehaviour
{
    public AudioClip newTrack;

    private BGMController _theAM;
   
    // Start is called before the first frame update
    void Start()
    {
        _theAM = FindObjectOfType<BGMController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (newTrack != null)
            {
                _theAM.ChangeBGM(newTrack);
            }
            
        }
    }
}
