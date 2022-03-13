using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject cameraPlayer;

    private float _lenght, _inicialPosition;

    public float speedParallax;
    
    // Start is called before the first frame update
    void Start()
    {
        _inicialPosition = transform.position.x;
        _lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = (cameraPlayer.transform.position.x * (1 - speedParallax));

        float dist = (cameraPlayer.transform.position.x * speedParallax);

        transform.position = new Vector3(_inicialPosition + dist, transform.position.y, transform.position.z);

        if (temp > _inicialPosition + _lenght / 2)
        {
            _inicialPosition += _lenght;
        }
        else if (temp < _inicialPosition - _lenght / 2)
        {
            _inicialPosition -= _lenght;
        }
    }
}
