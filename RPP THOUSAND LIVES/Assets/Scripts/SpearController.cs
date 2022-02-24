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

    public PlayerController playerController;
  

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
   
   private void OnTriggerEnter2D(Collider2D other)
   {
       if (other != null && other.CompareTag("Spear"))
       {
           _isWithSpear = true;
           //lança some

       }
   }

    private void ThrowSpear()
    {
       GameObject spearObject =  Instantiate(_spearPrefab, _ThrowPosition.position, _ThrowPosition.rotation);

       if (!playerController.IsMovingRight)
       {
           spearObject.transform.rotation = Quaternion.Euler(0, 180,0) * spearObject.transform.rotation;
       }
       
       spearObject.GetComponent<ThrowSpear>().playerPosition = transform;
    }

   /* private void ComeBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, thrudHand.position, velocidade * Time.deltaTime);
    }*/
    
}
