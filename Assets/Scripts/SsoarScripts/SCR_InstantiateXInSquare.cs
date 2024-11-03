using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_InstantiateXInSquare : MonoBehaviour{
    [SerializeField] GameObject toInstantiate;
    [SerializeField] Transform topLeft,bottomRight;
    [SerializeField] int ammount;

    public void Activate(){
        for (int i = 0; i < ammount; i++){
            Vector3 randPos = new Vector3(
                Random.Range(topLeft.position.x,bottomRight.position.x),
                Random.Range(bottomRight.position.y,topLeft.position.y),
                0f
            );
            Instantiate(toInstantiate,randPos,Quaternion.identity);
        }
    }
}
