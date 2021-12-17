using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{
    public float moveSpeed;
    
    [SerializeField] private bool usetransform;

    [SerializeField] private Transform transformDestination;

    [SerializeField] private Vector3 plataformDestination;

    private Vector3 _initialPosition;
    
    private bool _isReturning;

    private Vector2 worldDestination;

    private Vector2 _currentMoveDirection;
    // Start is called before the first frame update
    void Start()
    {
        _initialPosition = transform.position;
        
        
        worldDestination = Vector2.zero;

        if (usetransform)
        {
            worldDestination = transformDestination.position;
        }
        else
        {
            worldDestination = _initialPosition + plataformDestination;
        }

        
        _currentMoveDirection = (worldDestination - (Vector2) _initialPosition).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    private void MovePlatform()
    {
       
        
        if (!_isReturning)
        {
            if (Vector2.Distance(transform.position, worldDestination) < 1f)
            {
                _isReturning = true;
                _currentMoveDirection = ((Vector2) _initialPosition - worldDestination).normalized;
            }
           
        }
        else
        {
            if (Vector2.Distance(transform.position, _initialPosition) < 1f)
            {
                _isReturning = false;
                _currentMoveDirection = (worldDestination - (Vector2) _initialPosition).normalized;
            }
        }

        transform.position += (Vector3) _currentMoveDirection * moveSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        if (other.contacts.Any(contact => contact.normal == Vector2.down))
        {
            other.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }

    private void OnDrawGizmos()
    {
        if (usetransform)
        {
            Debug.DrawLine(transform.position, transformDestination.position, Color.yellow);
        }
        else
            Debug.DrawLine(transform.position, transform.position + plataformDestination, Color.red);
    }
}
