using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Glow : MonoBehaviour{
    [Header("References")]
    [SerializeField] SpriteRenderer sr;

    [Header("Parameters")]
    [SerializeField] Color glow;
    [SerializeField] Color dull;
    [SerializeField] float lerpStrength;

    [Header("Variables")]
    Color currentColor;
    bool glowing = false;

    void Update(){
        Color target = (glowing)? glow : dull;
        sr.color = Color.Lerp(currentColor,target,lerpStrength);
    }

    public void Glow(){
        glowing = true;
    }

    public void Dull(){
        glowing = false;
    }
}
