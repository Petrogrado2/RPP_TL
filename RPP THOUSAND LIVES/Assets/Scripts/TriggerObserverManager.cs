using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObserverManager : MonoBehaviour
{
    private int _bossEstado;
    
    public delegate void AtivouBossDelegate(int estadoBoss);

    public static event AtivouBossDelegate foiAtivado;
    public static event Action<int> ONBossActived;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.gameObject.CompareTag("Player"))
        {
            AtivarBoss();
        }
    }

    private void AtivarBoss()
    {
        _bossEstado = 1;
        
        foiAtivado?.Invoke(_bossEstado);
    }
}
