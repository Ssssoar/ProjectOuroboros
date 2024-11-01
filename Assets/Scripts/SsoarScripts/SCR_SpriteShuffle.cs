using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_SpriteShuffle : MonoBehaviour{
    [Header("Parameters")]
    [SerializeField] float spriteTime;
    [SerializeField] Sprite[] sprites;

    [Header("References")]
    [SerializeField] SpriteRenderer sr;
    
    [Header("Variables")]
    float timer;

    void Update(){
        timer -= Time.deltaTime;
        if (timer <= 0f){
            timer += spriteTime;
            sr.sprite = sprites[Random.Range(0,sprites.Length)];
        }
    }

}
