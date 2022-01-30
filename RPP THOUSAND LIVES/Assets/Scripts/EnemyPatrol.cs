using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    
    private Rigidbody2D _enemyRigidbody2D;
    
    private bool _faceFlip;

    private Animator _enemyPatrolAnimator;
    

    // Start is called before the first frame update
    void Start()
    {
        _enemyRigidbody2D = GetComponent<Rigidbody2D>();
        _enemyPatrolAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.fixedDeltaTime);
    }

    private void FlipEnemy()
    {
        if (_faceFlip)
        {
            gameObject.transform.rotation = Quaternion.Euler(0,0, 0);
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0,180, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other != null && !other.collider.CompareTag("Player") && !other.collider.CompareTag("Ground"))
        {
            _faceFlip = !_faceFlip;
        }
        else if(other != null &&  other.collider.CompareTag("Player"))
        {
            _enemyPatrolAnimator.SetBool("CollisionPlayer", true);
        }
        FlipEnemy();
    }

    
}
