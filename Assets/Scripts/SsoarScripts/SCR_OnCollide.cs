using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SCR_OnCollide : MonoBehaviour{

    [SerializeField] string tagToWatch;
    [SerializeField] UnityEvent eventToHappen;

    void OnTriggerEnter2D(Collider2D coll){
        if (coll.tag == tagToWatch){
            eventToHappen?.Invoke();
        }
    }

    public void Debugger(){
        Debug.Log("HAPPENED");
    }
}
