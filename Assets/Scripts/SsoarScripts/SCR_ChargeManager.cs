using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_ChargeManager : MonoBehaviour{
    public static SCR_ChargeManager instance;
    private void Awake(){
        if (SCR_ChargeManager.instance != null)
            Destroy(gameObject);
        else
            SCR_ChargeManager.instance = this;
    }

    [SerializeField] SCR_MultiBar barScript;
    [SerializeField] int maxCharge,currentCharge;

    public float GetChargeProportion(){
        return (float)currentCharge/(float)maxCharge;
    }

    public void Charge(){
        currentCharge++;
        if (currentCharge > maxCharge) currentCharge = maxCharge;
        barScript.ChangeValue(currentCharge,maxCharge);
    }


    [ContextMenu("Deplete")]
    public void Deplete(){
        currentCharge = 0;
        barScript.ChangeValue(0);
    }
}