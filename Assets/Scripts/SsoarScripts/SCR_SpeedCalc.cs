using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_SpeedCalc : MonoBehaviour{
    internal float velocity;
    Vector3 prevPos;

    void Start(){
        prevPos = transform.position;
    }

    void Update(){
        float deltaPos = (prevPos - transform.position).magnitude;
        velocity = deltaPos / Time.deltaTime;
        prevPos = transform.position;
    }
}
