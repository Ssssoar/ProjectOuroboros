using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SCR_TimeSetter : MonoBehaviour{
    public PlayableDirector sequence;

    public void ResetTime(){
        sequence.initialTime = 0f;
    }

    public void SetTime(){
        sequence.initialTime = SCR_PhaseAwareness.instance.startFraction * sequence.duration;
    }
}
