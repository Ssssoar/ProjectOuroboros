using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Glow : MonoBehaviour{
    [Header("References")]
    [SerializeField] SpriteRenderer sr;

    [Header("Parameters")]
    [SerializeField] Color glow;
    [SerializeField] Color dull;
    [SerializeField] float lerpUp;
    [SerializeField] float lerpDown;

    [Header("Variables")]
    Color currentColor;
    float lerpStrength = 1f;
    bool glowing = false;

    void Update(){
        Color target = (glowing)? glow : dull;
        currentColor = Color.Lerp(currentColor,target,lerpStrength);
        sr.color = currentColor;
    }

    public void Glow(){
        glowing = true;
        lerpStrength = lerpUp;
    }

    public void Dull(){
        glowing = false;
        lerpStrength = lerpDown;
    }
}
