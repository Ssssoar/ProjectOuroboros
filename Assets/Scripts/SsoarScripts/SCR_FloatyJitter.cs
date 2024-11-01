using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_FloatyJitter : MonoBehaviour{
    Vector3 homePosition;
    Vector3 headingPosition;
    public float radius;
    public float minTime;
    public float maxTime;
    public float lerpStrength;
    float timer;
    
    void Start(){
        homePosition = transform.localPosition;
        headingPosition = FindNewPosition();
        timer = Random.Range(minTime,maxTime);
    }

    void FixedUpdate(){
        transform.localPosition = Vector3.Lerp(transform.localPosition,headingPosition,lerpStrength);
        timer -= Time.deltaTime;
        if (timer <= 0f){
            timer += Random.Range(minTime,maxTime);
            headingPosition = FindNewPosition();
        }
    }

    Vector3 FindNewPosition(){
        float degrees = Random.Range(0f,360f);
        Vector3 newTarget = Vector3.right * radius;
        Quaternion rotation = Quaternion.identity;
        rotation.eulerAngles = new Vector3(0f,0f,degrees);
        newTarget = (rotation * newTarget) + homePosition;
        return newTarget;
    }
}
