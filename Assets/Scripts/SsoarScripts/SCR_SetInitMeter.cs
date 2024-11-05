using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_SetInitMeter : MonoBehaviour{
    [SerializeField] RectTransform refTransform;
    [SerializeField] RectTransform selfTransform;

    void Start(){
        selfTransform.anchoredPosition = new Vector2(selfTransform.anchoredPosition.x,refTransform.position.y - refTransform.rect.height);
    }
}
