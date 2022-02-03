using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;


public class Dialogue : MonoBehaviour
{
    public Sprite profile;
    
    public string[] speechText;
    
    public string actorName;

    public LayerMask playerLayer;

    public float radious;

    private DialogueControl _dialogueControl;

    private bool onRadious;

    private void Start()
    {
        _dialogueControl = FindObjectOfType<DialogueControl>();
    }

    private void FixedUpdate()
    {
        Interact();
    }

    private void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame && onRadious)
        {
            _dialogueControl.Speech(profile, speechText, actorName);
        }
    }

    public void Interact()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radious, playerLayer);

        if (hit != null)
        {
            onRadious = true;
        }
        else
        {
            onRadious = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radious);
    }
}
