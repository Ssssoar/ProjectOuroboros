using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Punch : MonoBehaviour , Damager{
    [System.Serializable]
    struct PunchBuilder{
        public Transform pos1;
        public Transform pos2;
        public GameObject warningZone;
    }
    
    [System.Serializable]
    struct Punch{
        public Vector3 from;
        public Vector3 to;
        public GameObject warningZone;
        
        public Punch(Vector3 From, Vector3 To, GameObject WarningZone) {
            this.from = From;
            this.to = To;
            this.warningZone = WarningZone;
        }
    }

    [Header("References")]
    [SerializeField] PunchBuilder[] prePunches;

    [Header("Parameters")]
    [SerializeField] float lerpStrength;

    [Header("Variables")]
    bool activated = false;
    Punch[] availablePunches;
    Punch activePunch;

    void Start(){
        availablePunches = BuildPunches(prePunches);
    }

    Punch[] BuildPunches(PunchBuilder[] prePunches){
        Punch[] constructed = new Punch[prePunches.Length * 2];
        int i = 0;
        foreach (PunchBuilder builder in prePunches){
            constructed[i]   = new Punch(builder.pos1.position , builder.pos2.position, builder.warningZone);
            constructed[i+1] = new Punch(builder.pos2.position , builder.pos1.position, builder.warningZone);
            i +=2;
        }
        return constructed;
    }

    Punch RandomPunch(){
        return availablePunches[Random.Range(0,availablePunches.Length)];
    }

    void FixedUpdate(){
        if (!activated) return;
        Debug.Log(Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, activePunch.from , lerpStrength * Time.deltaTime);
    }

    public void Initiate(){
        activated = true;
        activePunch = RandomPunch();
        SCR_BulletManager.instance.bullets.Add(this);
    }

    public void Activate(){
    }

    public void Trigger(){
    }

    public void Clean(){
    }
}
