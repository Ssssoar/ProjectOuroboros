using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This one overrides the FaceSprite Script when it is enabled
public class SCR_LipSync : MonoBehaviour{
    [System.Serializable]
    public struct MouthShapes{
        public Mood mood;
        public Sprite ah;
        public Sprite eh;
        public Sprite ooh;
        public Sprite juh;
        public Sprite ph;
        public Sprite mmh;
    }
    public enum Phoneme {ah,eh,ooh,juh,ph,mmh}

    [Header("References")]
    [SerializeField] SCR_FaceSprite toOverride;
    [SerializeField] SCR_FaceSpritesHandler faceScript;
    [SerializeField] MouthShapes[] shapeLib;

    [Header("DEBUG")]
    public bool DEBUG;

    void Update(){
        if (!DEBUG) return;
        if (Input.GetKeyDown("q"))
            SetPhoneme(Phoneme.ah);
        if (Input.GetKeyDown("w"))
            SetPhoneme(Phoneme.eh);
        if (Input.GetKeyDown("e"))
            SetPhoneme(Phoneme.ooh);
        if (Input.GetKeyDown("a"))
            SetPhoneme(Phoneme.juh);
        if (Input.GetKeyDown("s"))
            SetPhoneme(Phoneme.ph);
        if (Input.GetKeyDown("d"))
            SetPhoneme(Phoneme.mmh);
        if (
            (!Input.GetKey("q"))&&
            (!Input.GetKey("w"))&&
            (!Input.GetKey("e"))&&
            (!Input.GetKey("a"))&&
            (!Input.GetKey("s"))&&
            (!Input.GetKey("d"))
        ){
            ReleaseOverride();
        }
    }

    public void SetPhoneme(Phoneme phon){
        toOverride.overtake = true;
        toOverride.sr.sprite = GetSprite(faceScript.currentMood,phon);
    }
    
    public void ReleaseOverride(){
        toOverride.overtake = false;
    }

    Sprite GetSprite(Mood mood, Phoneme phon){
        if (mood == Mood.any){
            mood = (Mood)Random.Range(1,4); //quick and dirty
        }
        foreach (MouthShapes moodLib in shapeLib){
            if (moodLib.mood == mood){
                switch(phon){
                    case(Phoneme.ah):
                        return moodLib.ah;
                    case(Phoneme.eh):
                        return moodLib.eh;
                    case(Phoneme.ooh):
                        return moodLib.ooh;
                    case(Phoneme.juh):
                        return moodLib.juh;
                    case(Phoneme.ph):
                        return moodLib.ph;
                    case(Phoneme.mmh):
                        return moodLib.mmh;
                }
            }
        }
        return null;
    }
}
