using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_MusicManager : MonoBehaviour{
    [SerializeField] AudioClip[] musicPerStage;
    [SerializeField] AudioSource audioSource;
    [SerializeField] float fadeOutTime;
    float fadeOutTimer = -1f;

    void Update(){
        if (fadeOutTimer <= 0f) return;
        fadeOutTimer -= Time.deltaTime;
        audioSource.volume = Mathf.Lerp(0f,1f,fadeOutTimer/fadeOutTime);
    }

    public void FadeOut(){
        fadeOutTimer = fadeOutTime;
    }

    public void Switch(){
        audioSource.clip = musicPerStage[SCR_PhaseAwareness.instance.phase];
    }
}
