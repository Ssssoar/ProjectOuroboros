using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Events;
using Cinemachine;


public class SCR_HoldAndCamera : MonoBehaviour{
    [Header("References")]
    [SerializeField] PlayableDirector director;
    [SerializeField] UnityEvent onUnreadyRelease;
    [SerializeField] CinemachineVirtualCamera defaultCam , focusCam;

    bool readied = false;

    void OnMouseDown(){
        if (readied) return;
        focusCam.Priority = 10;
        defaultCam.Priority = 0;
        director.Play();
    }

    void OnMouseUp(){
        if (readied) return;
        focusCam.Priority = 0;
        defaultCam.Priority = 10;
        director.Stop();
        onUnreadyRelease?.Invoke();
    }

    public void Readied(){
        readied = true;
    }
}
