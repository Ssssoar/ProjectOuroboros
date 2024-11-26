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
    [SerializeField] Animator animComp;

    [Header("Parameters")]
    [SerializeField] float lerpStrength;
    [SerializeField] float returnLerpStrength;
    [SerializeField] float punchPosition;
    [SerializeField] string chargeAnimation;
    [SerializeField] string punchAnimation;

    [Header("Variables")]
    bool activated = false;
    bool punching = false;
    bool initiated = false;
    Punch[] availablePunches;
    Punch activePunch;
    Vector3 activeDirection;
    Vector3 restingPosition;
    Vector3 restingRight;

    void Start(){
        availablePunches = BuildPunches(prePunches);
        restingPosition = transform.position;
        restingRight = transform.right;
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
        if (!activated){
            transform.position = Vector3.Lerp(transform.position, restingPosition, returnLerpStrength * Time.deltaTime);
            transform.right = Vector3.Slerp(transform.right, restingRight, returnLerpStrength * Time.deltaTime);
            return;
        }
        if(!punching){
            transform.position = Vector3.Lerp(transform.position, activePunch.from , lerpStrength * Time.deltaTime);
            transform.right = Vector3.Slerp(transform.right, activeDirection, lerpStrength * Time.deltaTime);
        }else{
            transform.position = Vector3.Lerp(transform.position, activePunch.to, punchPosition);
            if (punchPosition >= 1f)
                EndPunch();
        }
    }

    public void Initiate(){
        if (initiated) return;
        initiated = true;
        activePunch = RandomPunch();
        SCR_BulletManager.instance.bullets.Add(this);
        activeDirection = (activePunch.to - activePunch.from).normalized;
    }

    public void Activate(){
        activated = true;
        animComp.Play(chargeAnimation);
    }

    public void Trigger(){
        activePunch.warningZone.SetActive(true);
    }

    public void Clean(){
        punching = true;
        activePunch.warningZone.SetActive(false);
        animComp.Play(punchAnimation);
    }

    public void EndPunch(){
        if (!initiated) return;
        punching = false;
        activated = false;
        initiated = false;
        SCR_BulletManager.instance.RemoveBullet(this);
    }
}
