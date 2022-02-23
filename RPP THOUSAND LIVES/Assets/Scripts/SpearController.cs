using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpearController : MonoBehaviour
{
    //public GameObject Spear;
   // public Transform thrudHand;
   // public float velocidade;

    private bool _isWithSpear = true;

    [SerializeField] private Transform _ThrowPosition;

    [SerializeField] private GameObject _spearPrefab;
  

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.lKey.wasPressedThisFrame && _isWithSpear)
        {
            ThrowSpear();
            _isWithSpear = false;
        }
        
      /*  if (Keyboard.current.iKey.isPressed)
        {
            ComeBack();
        }*/
    }

   /* private void OnCollisionEnter2D(Collision2D other)
    {
        if (other != null && other.collider.CompareTag("Player"))
        {
            Spear.SetActive(false);
        }
    }*/
   
   private void OnCollisionEnter2D(Collision2D other)
   {
       if (other != null && other.collider.CompareTag("Spear"))
       {
           _isWithSpear = true;
           //lança some

       }
   }

    private void ThrowSpear()
    {
        Instantiate(_spearPrefab, _ThrowPosition.position, _ThrowPosition.rotation);
    }

   /* private void ComeBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, thrudHand.position, velocidade * Time.deltaTime);
    }*/
    
}
