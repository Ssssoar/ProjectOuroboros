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
    [SerializeField] SCR_Lerper lerper;

    [Header("Parameters")]
    [SerializeField] float lerpStrength;
    [SerializeField] float returnLerpStrength;
    [SerializeField] float punchPosition;
    [SerializeField] string chargeAnimation;
    [SerializeField] string punchAnimation;
    [SerializeField] string defaultAnimation;
    [SerializeField] bool facingRight;

    [Header("Variables")]
    bool activated = false;
    bool punching = false;
    bool initiated = false;
    Punch[] availablePunches;
    Punch activePunch;
    Vector3 activeDirection;

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
        if (punching){
            lerper.controlValue = punchPosition;
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
        if (activated) return;
        if (punching) animComp.Play(defaultAnimation);
        activated = true;
        animComp.Play(chargeAnimation);
        lerper.StartMove(activePunch.from , (facingRight)? activeDirection : -activeDirection, lerpStrength);
    }

    public void Trigger(){
        activePunch.warningZone.SetActive(true);
        if (punching) animComp.Play(defaultAnimation);
    }

    public void Clean(){
        initiated = false;
        punching = true;
        activePunch.warningZone.SetActive(false);
        animComp.Play(punchAnimation);
        lerper.StartMove(activePunch.to, transform.right);
        lerper.StartControl();
    }

    public void EndPunch(){
        punching = false;
        activated = false;
        initiated = false;
        SCR_BulletManager.instance.RemoveBullet(this);
        animComp.Play(defaultAnimation);
        lerper.EndControl();
        lerper.ReturnMove();
    }
}
