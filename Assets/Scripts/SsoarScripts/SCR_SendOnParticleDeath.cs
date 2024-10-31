using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_SendOnParticleDeath : MonoBehaviour{

    [SerializeField] ParticleSystem particleSyst;
    [SerializeField] LibreriaDeSonidos sounds;
    [SerializeField] float audioChance;
    private ParticleSystem.Particle[] _particles;

    void Start(){
        _particles = new ParticleSystem.Particle[particleSyst.main.maxParticles];
    }

    void Update(){
        int particleCount = particleSyst.GetParticles(_particles);
        for (int i = 0; i < particleCount; i++){
            if (_particles[i].remainingLifetime <= 0){
                SCR_ChargeManager.instance.Charge();
                if (audioChance >= Random.value)
                    SoundFXManager.instance.ReproducirSFX(sounds);
            }
        }
    }
}
