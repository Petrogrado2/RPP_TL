using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    
    private Rigidbody2D _enemyRigidbody2D;
    
    private bool _faceFlip = true;

    private Animator _enemyPatrolAnimator;

    private IDamageable _damageable;

    private Collider2D _patrolCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        _enemyRigidbody2D = GetComponent<Rigidbody2D>();
        _enemyPatrolAnimator = GetComponent<Animator>();
        _damageable = GetComponent<IDamageable>();
        _patrolCollider2D = GetComponent<Collider2D>();
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.CompareTag("ColliderFlip"))
        {
            _faceFlip = !_faceFlip;
        }

        if (other != null && other.CompareTag("MeleeAttack"))
        {
            KillEnemy();
        }
       
        FlipEnemy();
    }
   

    private void OnCollisionEnter2D(Collision2D other)
    {
         if(other != null &&  other.collider.CompareTag("Player"))
        {
            _enemyPatrolAnimator.SetBool("CollisionPlayer", true);
            Debug.Log("bateu no player");
        }
         if (other != null && other.collider.CompareTag("Spear"))
         {
             KillEnemy();
         }
    }

    private void KillEnemy()
    {
        _patrolCollider2D.isTrigger = true;
        _enemyRigidbody2D.bodyType = RigidbodyType2D.Static;
        _enemyPatrolAnimator.SetTrigger("Dead");
        Invoke("DestroyEnemy", 0.5f);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
