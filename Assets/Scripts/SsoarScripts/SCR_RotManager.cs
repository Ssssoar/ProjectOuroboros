using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_RotManager : MonoBehaviour{
    [SerializeField] SCR_DampRotate[] rotateScripts;

    public void SetSpeed(int i){
        foreach(SCR_DampRotate rotScript in rotateScripts){
            rotScript.ChangeSpeed(i);
        }
    }
}
