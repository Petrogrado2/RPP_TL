using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesativarCollider : MonoBehaviour
{
    private BoxCollider2D _colliderDoDoubleAttack;
    // Start is called before the first frame update
    void Start()
    {
        _colliderDoDoubleAttack = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other != null && other.collider.CompareTag("Boss"))
        {
            StartCoroutine(TurnToFalse());
            StartCoroutine(TurnToTrue());
        }
    }

    private IEnumerator TurnToFalse()
    {
        yield return new WaitForSeconds(2);
        _colliderDoDoubleAttack.isTrigger = true;
    }

    private IEnumerator TurnToTrue()
    {
        yield return new WaitForSeconds(20);
        _colliderDoDoubleAttack.isTrigger = false;
    }
}
