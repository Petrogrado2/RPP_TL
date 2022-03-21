using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveLetter : MonoBehaviour
{
    public SpriteRenderer imagem;
    // Start is called before the first frame update
    void Start()
    {
        imagem = GetComponent<SpriteRenderer>();
        imagem.color = Color.clear;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            imagem.color = Color.white;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            imagem.color = Color.clear;
        }
    }
}
