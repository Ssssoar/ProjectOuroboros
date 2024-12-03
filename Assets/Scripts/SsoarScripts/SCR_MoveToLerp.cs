using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_MoveToLerp : MonoBehaviour{
    public float targetY,lerpStrength,maxY,minY;
    void Start(){
        targetY = transform.position.y;
    }

    void Update(){
        float newY = Mathf.Lerp(transform.position.y,targetY,lerpStrength);
        if (newY >= maxY){
            newY -= (maxY - minY);
            targetY -= (maxY - minY);
        }
        transform.position = new Vector3(transform.position.x , newY , transform.position.z);
    }
}
