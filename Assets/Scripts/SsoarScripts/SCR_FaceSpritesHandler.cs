using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; //for List<something>.Union

public enum Mood {any,normal,angry,fear}
public class SCR_FaceSpritesHandler : MonoBehaviour{

    [System.Serializable]
    public struct PartGroup{
        public SCR_FaceSprite partScript;
        public List<Sprite> normalSprites;
        public List<Sprite> angerSprites;
        public List<Sprite> fearSprites;
        public List<Sprite> wildcardSprites;
    }

    [Header("References")]
    [SerializeField] PartGroup[] faceParts;

    [Header("Parameters")]
    [SerializeField] bool DEBUGMODE;
    [SerializeField] float DEBUGTIME;

    [Header("Variables")]
    float DEBUGTIMER = 0f;
    internal Mood currentMood;


    void Start(){
        ChangeMood(Mood.any);
    }

    void Update(){
        DEBUGTIMER -= Time.deltaTime;
        if ((DEBUGMODE)&&(DEBUGTIMER <= 0f)){
            DEBUGTIMER += DEBUGTIME;
            SendBeat();
        }
    }

    void SendBeat(){
        foreach(PartGroup part in faceParts){
            part.partScript.TryChange();
        }
    }

    void ChangeMood(Mood newMood){
        currentMood = newMood;
        foreach(PartGroup part in faceParts){
            List<Sprite> totalSprites = part.wildcardSprites;
            if ((newMood == Mood.any) || (newMood == Mood.normal)){
                totalSprites = totalSprites.Concat(part.normalSprites).ToList();
            }
            if ((newMood == Mood.any) || (newMood == Mood.angry)){
                totalSprites = totalSprites.Concat(part.angerSprites).ToList();
            }
            if ((newMood == Mood.any) || (newMood == Mood.fear)){
                totalSprites = totalSprites.Concat(part.fearSprites).ToList();
            }
            part.partScript.NewList(totalSprites);
        }
    }
}
