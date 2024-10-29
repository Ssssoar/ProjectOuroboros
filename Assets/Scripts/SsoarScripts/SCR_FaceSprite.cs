using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_FaceSprite : MonoBehaviour{
    [Header("References")]
    public SpriteRenderer sr;

    [Header("Parameters")]
    [SerializeField] float changeChance = 0.2f;

    [Header("Variables")]
    List<Sprite> sprites = new List<Sprite>();
    internal bool overtake = false;

    public void TryChange(){
        if (overtake) return;
        if (Random.value <= changeChance)
            ChangeSprite();
    }

    public void NewList(List<Sprite> newSprites){
        sprites = newSprites;
    }

    void ChangeSprite(){
        sr.sprite = sprites[Random.Range(0,sprites.Count)];
    }
}
