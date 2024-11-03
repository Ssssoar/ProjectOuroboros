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
    [SerializeField] UnityEvent onExecuted;
    [SerializeField] CinemachineVirtualCamera defaultCam , focusCam;

    [Header("Parameters")]
    [SerializeField] float treshold;

    [Header("Variables")]
    Vector2 startPos;
    Vector2 endPos;

    

    bool readied = false;

    void Update(){
        if ((startPos != Vector2.zero)&&(readied)){
            endPos = Input.mousePosition;
            Vector2 displacement = endPos - startPos;
            if (displacement.x >= treshold){
                onExecuted?.Invoke();
            }
        }
    }

    void OnMouseDown(){
        if (readied) {
            startPos = Input.mousePosition;
            return;
        }
        focusCam.Priority = 10;
        defaultCam.Priority = 0;
        director.Play();
    }

    void OnMouseUp(){
        startPos = Vector2.zero;
        if (readied) return;
        focusCam.Priority = 0;
        defaultCam.Priority = 10;
        director.Stop();
        onUnreadyRelease?.Invoke();
    }

    public void Readied(){
        startPos = Input.mousePosition;
        readied = true;
    }
}
