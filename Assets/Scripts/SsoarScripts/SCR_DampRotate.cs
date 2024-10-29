using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_DampRotate : MonoBehaviour{

    [Header("Parameters")]
    [SerializeField] float[] speeds;
    [SerializeField] float upDamping;
    [SerializeField] float downDamping;
    [SerializeField] bool clockwise = true;

    [Header("Variables")]
    float currentZ;
    internal int speedi = 0;
    float currentSpeed;

    void Start(){
        currentSpeed = speeds[0];
    }

    void Update(){
        currentSpeed = SpeedCalc();
        currentZ = RotCalc(currentZ);
        transform.eulerAngles = new Vector3(0f,0f,currentZ);
    }

    float RotCalc(float currentRot){
        float rot = currentRot + (currentSpeed * Time.deltaTime * ((clockwise)? -1 : 1));
        rot = LoopZ(rot);
        return rot;
    }

    float SpeedCalc(){
        float targetSpeed = speeds[speedi];
        float damping = (currentSpeed > targetSpeed)? downDamping : upDamping;
        return Mathf.Lerp(currentSpeed,targetSpeed,damping);
    }

    float LoopZ(float z){
        while((z > 360f) || (z < 0f)){
            if (z > 360f) z -= 360f;
            else z += 360f;
        }
        return z;
    }

    public void ChangeSpeed(int i){
        if (i < 0) i = 0;
        if (i >= speeds.Length) i = speeds.Length - 1;
        speedi = i;
    }
}
