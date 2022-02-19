using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    [SerializeField] private Transform _shootPosition;

    [SerializeField] private GameObject _bulletPrefab;
    
    private IDamageable _damageable;

    private Animator _enemyShooterAnimator;

    public Transform enemySight;

    public LayerMask playerLayerMask;

    public float rayLength = 0.5f;

    public bool isOnSight = false;

    public float timeToWait = 1f;

    private float shootTime;
    
    
    void Start()
    {
        _damageable = GetComponent<IDamageable>();
        _enemyShooterAnimator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit2D enemySigHit2D = Physics2D.Raycast(enemySight.position, Vector2.left, rayLength, playerLayerMask);

        if (enemySigHit2D.collider != null)
        {
            isOnSight = true;
        }
        else
        {
            isOnSight = false;
        }

        if (isOnSight && Time.time - shootTime > timeToWait)
        {
            Shoot();
            shootTime = Time.time;
        }
        // detectar se o jogador entrou na area de tiro
        
    }

    private void Shoot()
    {
        Instantiate(_bulletPrefab, _shootPosition.position, _shootPosition.rotation);
        
    }

   

   
   
    // Start is called before the first frame update
  

   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.CompareTag("MeleeAttack"))
        {
            KillEnemy();
        }
    }

    private void DestroyBody()
    {
        Destroy(gameObject);
    }

    private void KillEnemy()
    {
        Invoke("DestroyBody", 0.5f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(enemySight.position,enemySight.position + Vector3.left * rayLength);
    }
}
