using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_ColorIntercalator : MonoBehaviour{
    [Header("References")]
    [SerializeField] SpriteRenderer sr;

    [Header("Parameters")]
    [SerializeField] Color[] colors;

    [Header("Variables")]
    int currentIndex = 0;

    void Update(){
        currentIndex++;
        if (currentIndex == colors.Length)
            currentIndex = 0;
        sr.color = colors[currentIndex];
    }
}
