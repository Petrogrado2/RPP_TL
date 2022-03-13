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

    private bool _faceFlip = true;

    private int _bossState = 1;

    private Animator _bossAnimator;

    private SpriteRenderer _bossSpriteRenderer;

    private bool _hitMiddleCollider;

    public GameObject player;

    public bool activeBoss2;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _bossSpriteRenderer = GetComponent<SpriteRenderer>();
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
        

        activeBoss2 = player.GetComponent<PlayerController>().activeBoss;
       

        
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
            StartCoroutine(ChangeColor());
        }

        if (other != null && other.collider.CompareTag("MiddleCollider"))
        {
            _hitMiddleCollider = true;
            Invoke("HitFalse", 1f);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.CompareTag("MeleeAttack"))
        {
            bossLife -= 2;
            StartCoroutine(ChangeColor());
        }
        else if (other != null && other.CompareTag("Kill"))
        {
            _isWitAxe = true;
            
            _bossState = 2;
        }
        
        else if (other != null && other.CompareTag("ColliderFlip"))
        {
            _faceFlip = !_faceFlip;
            _bossState = 3;
           // FlipEnemy();
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
       velocidade = 50;

    }

    private IEnumerator BackPlace()
    {
        
        yield return new WaitForSeconds(1);
        
        _rigidbody2D.velocity = new Vector2(velocidade,0);

        yield return new WaitForSeconds(2);
        velocidade = 0;
    }

    private IEnumerator ThrowAxe()
    {
        _bossAnimator.Play("Darius_Throw_Axe");
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
        _bossAnimator.SetFloat("Speed", Math.Abs(velocidade) );
        _bossAnimator.SetBool("IsThrowingAxe", _isWitAxe);
        _bossAnimator.SetBool("HitMiddleCollider", _hitMiddleCollider);
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

    private void HitFalse()
    {
        _hitMiddleCollider = false;
    }
    

    IEnumerator ChangeColor()
    {
        _bossSpriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        _bossSpriteRenderer.color = Color.white;
    }
}
