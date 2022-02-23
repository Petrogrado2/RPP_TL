using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class ThrowSpear : MonoBehaviour
{
    private Transform playerPosition;
    public float velocidadeDeVolta;
    
    
    
    [SerializeField]
    private float _velocidade;
    
    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        var rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = transform.right * _velocidade;
    }

    private void Update()
    {
        if (playerPosition.gameObject != null && Keyboard.current.iKey.isPressed)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPosition.position,
                velocidadeDeVolta * Time.deltaTime);
        }
    }
}
