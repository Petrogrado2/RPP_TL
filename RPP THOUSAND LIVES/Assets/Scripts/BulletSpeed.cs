using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class BulletSpeed : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    // Start is called before the first frame update
    void Start()
    {
        var rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = transform.right * -1 *_speed;
    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.CompareTag("Player"))
        {
            KillPlayer();
        }

        if (other.gameObject.tag.Equals("Kill") || other.gameObject.tag.Equals("Player"))
        {
            return;
        }
        Destroy(gameObject);
    }*/

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other != null && other.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void KillPlayer()
    {
        
    }
}
