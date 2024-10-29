using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SCR_ChargeManager : MonoBehaviour{
    public static SCR_ChargeManager instance;
    private void Awake(){
        if (SCR_ChargeManager.instance != null)
            Destroy(gameObject);
        else
            SCR_ChargeManager.instance = this;
    }

    [SerializeField] UnityEvent onFullCharge;
    [SerializeField] SCR_MultiBar barScript;
    [SerializeField] int maxCharge,currentCharge;
    [SerializeField] float drainTime;
    
    float drainTimer;
    bool drain;
    bool blocked = false;

    public void Update(){
        if (!drain) return;
        drainTimer -= Time.deltaTime;
        if (drainTimer <= 0f){
            currentCharge--;
            barScript.ChangeValue(currentCharge,maxCharge);
            if (currentCharge != 0)
                drainTimer += drainTime/maxCharge;
            else
                drain = false;
        }
    }

    public float GetChargeProportion(){
        return (float)currentCharge/(float)maxCharge;
    }

    public void Charge(){
        if (blocked) return;
        currentCharge++;
        if (currentCharge > maxCharge){
            blocked = true;
            onFullCharge?.Invoke();
            currentCharge = maxCharge;
        }
        barScript.ChangeValue(currentCharge,maxCharge);

    }


    [ContextMenu("Deplete")]
    public void Deplete(){
        currentCharge = 0;
        barScript.ChangeValue(0);
    }

    public void TESTDEBUG(){
        Debug.Log ("I HAVE BEEN TRIGGERED");
    }

    public void Drain(){
        drain = true;
        drainTimer = drainTime/maxCharge;
    }
}