using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_FadeAudio : MonoBehaviour{
    [SerializeField] AudioSource audioComp;
    [SerializeField] float lerpStrength;
    [SerializeField] float[] volumes;
    int currentIndex;
    
    void Update(){
        audioComp.volume = Mathf.Lerp(audioComp.volume,volumes[currentIndex],lerpStrength);   
    }

    public void SetVolume(int rank){
        currentIndex = rank;
    }
}
