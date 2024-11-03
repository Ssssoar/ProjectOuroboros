using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_ShakeSender : MonoBehaviour{

    [SerializeField] float intensity,decay;

    public void Send(){
        SCR_CinemachineShake.instance.ShakeCamera(intensity,decay);
    }
}
