using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public float distance;

    public LayerMask playerLayer;

    private IDamageable _damageable;

    private Animator _enemyShooterAnimator;
    // Start is called before the first frame update
    void Start()
    {
        _damageable = GetComponent<IDamageable>();
        _enemyShooterAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, transform.forward, distance, playerLayer);
    }

    private void DestroyBody()
    {
        Destroy(gameObject);
    }

    private void KillEnemy()
    {
        Invoke("DestroyBody", 0.5f);
    }

   
}
