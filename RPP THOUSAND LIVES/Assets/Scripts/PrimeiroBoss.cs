using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PrimeiroBoss : MonoBehaviour
{
    public float bossLife = 10;

    private Rigidbody2D _rigidbody2D;

    private bool isEnreged;

    private bool _isWitAxe = true;

    public float velocidade;

    private BoxCollider2D _bossCollider2D;
    
    private TilemapCollider2D _grounCollider2D;

    [SerializeField] private GameObject _axePrefab;

    [SerializeField] private Transform _axePosition;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

       _bossCollider2D = GetComponent<BoxCollider2D>();
       _grounCollider2D = GameObject.Find("LevelBase").GetComponent<TilemapCollider2D>();
        
        Physics2D.IgnoreCollision(_bossCollider2D, _grounCollider2D, true);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GoForward();
        
       /* if (_isWitAxe)
        {
            ThrowAxe();
        }*/
        
    }
    

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other != null && other.collider.CompareTag("Spear"))
        {
            bossLife -= 1;
        }
       
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.CompareTag("MeleeAttack"))
        {
            bossLife -= 2;
        }
        else if (other != null && other.CompareTag("Kill"))
        {
            _isWitAxe = true;
        }
       
    }

    private void GoForward()
    {
        _rigidbody2D.velocity = Vector2.left * velocidade * Time.deltaTime;
        Invoke("BackPlace", 5f);
    }

    private void BackPlace()
    {
        _rigidbody2D.velocity = Vector2.right * velocidade * Time.deltaTime;
    }

    private void ThrowAxe()
    {
      GameObject bossObject =  Instantiate(_axePrefab, _axePosition.position, _axePosition.rotation);
        _isWitAxe = false;

        bossObject.GetComponent<ThrowAxe>().bossPosition = transform;
    }

    private void DoubleAttack()
    {
        
    }
}
