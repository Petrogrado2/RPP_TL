using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDDialogueController : MonoBehaviour
{
    public static HUDDialogueController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
