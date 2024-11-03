using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SCR_GameOverManager : MonoBehaviour{
    [SerializeField] PlayableDirector[] gameOverSequences;
    public void GameOver(){
        int phase = SCR_PhaseAwareness.instance.phase;
        if (phase < 0) phase = 0;
        else if (phase >= gameOverSequences.Length) phase = gameOverSequences.Length - 1;
        gameOverSequences[phase].Play();
    }
}
