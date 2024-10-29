using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Events;


public class SCR_HoldAndCamera : MonoBehaviour{
    [Header("References")]
    [SerializeField] PlayableDirector director;
    [SerializeField] UnityEvent onUnreadyRelease;

    bool readied = false;

    void OnMouseDown(){
        if (readied) return;
        director.Play();
    }

    void OnMouseUp(){
        if (readied) return;
        director.Stop();
        onUnreadyRelease?.Invoke();
    }

    public void Readied(){
        readied = true;
    }
}
