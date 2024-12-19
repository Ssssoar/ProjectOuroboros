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
    [SerializeField] float chargeBlockTime;
    [SerializeField] int gameOversBeforeIncrease = 2;
    [SerializeField] [Range(0f,1f)] float chargeLoss;
    float blockTimer = -1f;    
    float drainTimer;
    bool drain;
    bool blocked = false;
    int debugCount = 0;
    int chargeCount = 1;
    int gameOverCount = 0;

    public void Update(){
        if (blockTimer >= 0f){
            blockTimer -= Time.deltaTime;
        }
        if (!drain) return;
        drainTimer -= Time.deltaTime;
        if (drainTimer <= 0f){
            currentCharge--;
            barScript.ChangeValue(currentCharge,maxCharge);
            if (currentCharge != 0)
                drainTimer += drainTime/maxCharge;
            drain = false;
        }
    }

    public float GetChargeProportion(){
        return (float)currentCharge/(float)maxCharge;
    }

    public void Charge(){
        //Debug.Log(debugCount);
        debugCount += chargeCount;
        if ((blocked)||(blockTimer >= 0f)) return;
        currentCharge += chargeCount;
        if (currentCharge > maxCharge){
            blocked = true;
            onFullCharge?.Invoke();
            currentCharge = maxCharge;
        }
        barScript.ChangeValue(currentCharge,maxCharge);
    }

    public void SignalGameOver(){
        gameOverCount ++;
        if (gameOverCount >= gameOversBeforeIncrease){
            chargeCount++;
            gameOverCount = 0;
        }
    }

    [ContextMenu("Deplete")]
    public void Deplete(){
        blockTimer = chargeBlockTime;
        int lost = (int)Mathf.Floor(maxCharge * chargeLoss);
        currentCharge -= lost;
        if (currentCharge < 0) currentCharge = 0;
        barScript.ChangeValue(currentCharge);
        debugCount = 0;
        SCR_PhaseAwareness.instance.startFraction = (double)currentCharge / (double)maxCharge;
    }

    public void TESTDEBUG(){
        Debug.Log ("I HAVE BEEN TRIGGERED");
    }

    public void Drain(){
        drain = true;
        drainTimer = drainTime/maxCharge;
    }

    public void CancelDrain(){
        drain = false;
        currentCharge = maxCharge;
        barScript.ChangeValue(currentCharge,maxCharge);
    }

    public void NewMaxCharge(int maxx){
        maxCharge = maxx;
        currentCharge = 0;
        barScript.ChangeValue(currentCharge,maxCharge);
        blocked = false;
    }
}