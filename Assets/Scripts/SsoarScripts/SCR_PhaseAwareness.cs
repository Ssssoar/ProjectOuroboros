using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_PhaseAwareness : MonoBehaviour{
    public static SCR_PhaseAwareness instance;

    private void Awake(){
        if (SCR_PhaseAwareness.instance != null) Destroy(gameObject);
        else instance = this;
    }

    public int phase = 0;
    
    public void Advance(){
        phase++;
    }

    public void SetTo(int newPhase){
        phase = newPhase;
    }
}
