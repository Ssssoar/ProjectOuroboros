using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_ParticleStopper : MonoBehaviour{
    [SerializeField] ParticleSystem particle;
    

    public void StopParticle(){
        particle.Stop();
    }
}
