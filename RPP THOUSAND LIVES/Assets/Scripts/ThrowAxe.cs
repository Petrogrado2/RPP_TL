using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ThrowAxe : MonoBehaviour
{
    [SerializeField] private float _velocidade;

    public Transform bossPosition;

    public float velocidadeDeVolta;

    private Rigidbody2D rigidBody;

   
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = -transform.right * _velocidade;
    }

    private void FixedUpdate()
    {
       Invoke("Back", 1f);

       
    }

    private void Back()
    {
        if (bossPosition.gameObject != null)
        {
            rigidBody.velocity = (bossPosition.position - transform.position).normalized * velocidadeDeVolta;
        }
        
        
      
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.CompareTag("Boss"))
        {
            Debug.Log("entrei");
            Destroy(gameObject);
        }
    }
}
