using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PrimeiroBoss : MonoBehaviour
{
    //estado 1: atirar machado
    //estado 2: corrida
    //estado 3: voltar pro lugar
    //estado 4: idle
    //estado 5 ataque duplo
    
    
    public float bossLife = 10;

    private Rigidbody2D _rigidbody2D;

    private bool isEnreged;

    private bool _isWitAxe = true;

    public float velocidade;

    public float forca;

    private BoxCollider2D _bossCollider2D, _colliderDoMeio;
    
    private TilemapCollider2D _grounCollider2D;

    [SerializeField] private GameObject _axePrefab;

    [SerializeField] private Transform _axePosition;

    private int _bossState = 1;

    private Animator _bossAnimator;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _bossAnimator = GetComponent<Animator>();
        _bossCollider2D = GetComponent<BoxCollider2D>();
        _colliderDoMeio = GetComponentInChildren<BoxCollider2D>();
       _grounCollider2D = GameObject.Find("LevelBase").GetComponent<TilemapCollider2D>();
       Physics2D.IgnoreCollision(_colliderDoMeio, _grounCollider2D, true);
        Physics2D.IgnoreCollision(_bossCollider2D, _grounCollider2D, true);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (bossLife <= 0)
        {
            Destroy(gameObject);
        }
        
            //StartCoroutine(DoubleAttack());
        BossAnimations();
       
        switch (_bossState)
        {
            case 1:
                if (_isWitAxe)
                {
                    StartCoroutine(ThrowAxe());
                }
                break; 
            case 2:
                StartCoroutine(GoForward());
                break;
            case 3:
                StartCoroutine(BackPlace());
                break;
            case 4:
                StopBoss();
                break;
        }
                
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
            
            _bossState = 2;
        }
        
        else if (other != null && other.CompareTag("ColliderFlip"))
        {
            
            _bossState = 3;
            
        }
        
        else if (other != null && other.CompareTag("StopCollider"))
        {
            _bossState = 4;
            
            Invoke("BackStageOne", 3f);
           
            Debug.Log("Para boss");
        }
       
    }

    private IEnumerator GoForward()
    {
        yield return new WaitForSeconds(3);
       
       _rigidbody2D.AddForce(new Vector2(-forca,0), ForceMode2D.Impulse);
        
    }

    private IEnumerator BackPlace()
    {
        
        yield return new WaitForSeconds(1);
        
        _rigidbody2D.velocity = new Vector2(velocidade,0);
    }

    private IEnumerator ThrowAxe()
    {
        
      GameObject bossObject =  Instantiate(_axePrefab, _axePosition.position, _axePosition.rotation);
        _isWitAxe = false;
        yield return new WaitForSeconds(3);
        bossObject.GetComponent<ThrowAxe>().bossPosition = transform;
        
    }

    private void StopBoss()
    {
        _rigidbody2D.velocity = new Vector2(0,0);
    }

    private void BackStageOne()
    {
        _bossState = 1;
    }

    private IEnumerator DoubleAttack()
    {
        yield return new WaitForSeconds(1);
        _rigidbody2D.AddForce(new Vector2(-forca,0), ForceMode2D.Impulse);
     
    }

    private void BossAnimations()
    {
        _bossAnimator.SetBool("IsThrowingAxe", _isWitAxe);
    }
}
