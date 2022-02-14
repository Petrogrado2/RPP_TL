using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    [SerializeField] private Transform _shootPosition;

    [SerializeField] private GameObject _bulletPrefab;
    // Update is called once per frame
    void Update()
    {
        // detectar se o jogador entrou na area de tiro
        Shoot();
    }

    private void Shoot()
    {
        Instantiate(_bulletPrefab, _shootPosition.position, _shootPosition.rotation); 
    }
}
