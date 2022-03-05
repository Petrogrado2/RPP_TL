using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpearController : MonoBehaviour
{
    public bool _isWithSpear = true;

    [SerializeField] private Transform _ThrowPosition;

    [SerializeField] private GameObject _spearPrefab;

    public PlayerController playerController;

    public bool IsThrowingSpear;

    [SerializeField]private float AttackTime = 0.2f;
  

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.lKey.wasPressedThisFrame && _isWithSpear)
        {
            IsThrowingSpear = true;
            
            Invoke("ThrowSpear", 0.4f);
            _isWithSpear = false;
        }
    }

  
   
   private void OnTriggerEnter2D(Collider2D other)
   {
       if (other != null && other.CompareTag("Spear"))
       {
           _isWithSpear = true;
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
       StartCoroutine(PerformAttack());
    }
    private IEnumerator PerformAttack()
    {
        yield return new WaitForSeconds(AttackTime);
        IsThrowingSpear = false;
    }
}
