using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_SoundSender : MonoBehaviour{
    [SerializeField] AudioClip clip;
    [SerializeField] LibreriaDeSonidos lib;
    [SerializeField] bool send;
    bool sent;

    void Update(){
        if (send&&!sent){
            Send();
            sent = true;
        }else if(!send&&sent)
            sent = false;
    }

    public void Send(){
        if (clip ==  null){
            SoundFXManager.instance.ReproducirSFX(lib);
        }else{
            SoundFXManager.instance.ReproducirSFX(clip);
        }
    } 
}
