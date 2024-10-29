using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_SetPositionToCharge : MonoBehaviour{
    [SerializeField] Transform fullPos,emptyPos;
    [SerializeField] SCR_ChargeManager chargeScript;

    void Update(){
        float chargeAmmount = chargeScript.GetChargeProportion();
        Vector3 pos = Vector3.Lerp(emptyPos.position , fullPos.position , chargeAmmount);
        transform.position = pos;
    }
}
