using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class ThrowSpear : MonoBehaviour
{
    public Transform playerPosition;
    public float velocidadeDeVolta;
    
    
    
    [SerializeField]
    private float _velocidade;

    private Rigidbody2D rigidBody;

    private Collider2D _collider2D;
    // criar variavel para guardar o collider
    
    // Start is called before the first frame update
    void Start()
    {
        _collider2D = GetComponent<Collider2D>();
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = -transform.right * _velocidade;
    }
    

    private void FixedUpdate()
    {
        
        
        if (playerPosition.gameObject != null && Keyboard.current.iKey.isPressed)
        {
            _collider2D.isTrigger = true;
            rigidBody.velocity = (playerPosition.position - transform.position).normalized * velocidadeDeVolta;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.CompareTag("Player"))
        {
            Debug.Log("entrei");
            Destroy(gameObject);
        }
    }
    
    
}
