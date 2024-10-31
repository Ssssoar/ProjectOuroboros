using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Lerp2Positions : MonoBehaviour{
    [SerializeField] Transform onPos,offPos;
    [SerializeField] bool on = false;

    [SerializeField] float lerpStrength;

    void Update(){
        if (on){
            transform.position = Vector3.Lerp(transform.position,onPos.position,lerpStrength);
        }else{
            transform.position = Vector3.Lerp(transform.position,offPos.position,lerpStrength);
        }
    }
}
