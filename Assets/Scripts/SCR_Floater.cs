using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Floater : MonoBehaviour{
    [SerializeField] SCR_MoveToLerp[] layers;
    [SerializeField] float minMove,maxMove,lerpStrength,BPM;

    float timer,timeBetweenBeats;

    void Start(){
        timeBetweenBeats = (1/BPM)*60;
        timer = timeBetweenBeats;
    }

    void Update(){
        timer -= Time.deltaTime;
        if (timer <= 0f){
            timer += timeBetweenBeats;
            foreach (SCR_MoveToLerp layer in layers){
                layer.targetY += Random.Range(minMove,maxMove);
                layer.lerpStrength = lerpStrength;
            }
        }
    }
}
