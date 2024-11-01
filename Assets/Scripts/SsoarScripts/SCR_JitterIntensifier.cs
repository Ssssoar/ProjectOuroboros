using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_JitterIntensifier : MonoBehaviour{
    [System.Serializable]
    public struct Intensity{
        public float radius;
        public float minTime;
        public float maxTime;
        public float lerpStrength;
    }

    [SerializeField] Intensity[] intensities;
    [SerializeField] SCR_FloatyJitter[] jitterers;

    void Start(){
        changeIntensity(0);
    }

    public void changeIntensity(int i){
        if (i < 0){
            Debug.Log("Sent an intensity too low, normalizing to 0");
            i = 0;
        }else if(i >= intensities.Length){
            Debug.Log("Sent an intensity too high, normalizing to max");
            i = intensities.Length-1;
        }
        foreach(SCR_FloatyJitter jitterer in jitterers){
            jitterer.radius = intensities[i].radius;
            jitterer.minTime = intensities[i].minTime;
            jitterer.maxTime = intensities[i].maxTime;
            jitterer.lerpStrength = intensities[i].lerpStrength;
        }
    }
}
