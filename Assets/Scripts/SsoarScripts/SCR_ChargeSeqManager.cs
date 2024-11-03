
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SCR_ChargeSeqManager : MonoBehaviour{
    [SerializeField] PlayableDirector[] chargeSequences;
    public void ChargeTriggered(){
        int phase = SCR_PhaseAwareness.instance.phase;
        if (phase < 0) phase = 0;
        else if (phase >= chargeSequences.Length) phase = chargeSequences.Length - 1;
        chargeSequences[phase].Play();
    }
}
