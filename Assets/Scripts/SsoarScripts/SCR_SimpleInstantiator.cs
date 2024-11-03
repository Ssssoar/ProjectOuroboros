using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_SimpleInstantiator : MonoBehaviour{
    [SerializeField] GameObject toInstantiate;
    public void Trigger(){
        Instantiate(toInstantiate,transform.position,Quaternion.identity);
    }
}
