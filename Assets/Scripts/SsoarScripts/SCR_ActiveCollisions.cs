using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_ActiveCollisions : MonoBehaviour{


    [SerializeField] string tagToWatch;
    [SerializeField] ParticleSystem[] particles;
    [SerializeField] float maxVelocity;
    [SerializeField] SCR_RotManager rotScript;
    [SerializeField] SCR_Glow glowScript;
    [SerializeField] SCR_FadeAudio audioScript;
    [SerializeField] bool grazingEnabled;
    [SerializeField] float[] speedTresholds;
    
    List<SCR_SpeedCalc> activeCollisions = new List<SCR_SpeedCalc>();
    List<ParticleSystem> activeParticles = new List<ParticleSystem>();
    List<int> particleRanks = new List<int>();

    public void EnableGrazing(){
        grazingEnabled = true;
    }

    void OnTriggerEnter2D(Collider2D coll){
        if (!grazingEnabled) return;
        if (coll.tag == tagToWatch){
            SCR_SpeedCalc spdScript = coll.gameObject.GetComponent<SCR_SpeedCalc>();
            activeCollisions.Add(spdScript);
            UpdateParticle(spdScript.velocity,-1);
        }
    }

    void OnTriggerExit2D(Collider2D coll){
        if (!grazingEnabled) return;
        if (coll.tag == tagToWatch){
            SCR_SpeedCalc spdScript = coll.gameObject.GetComponent<SCR_SpeedCalc>();
            int index = activeCollisions.IndexOf(spdScript);
            activeCollisions.Remove(spdScript);
            activeParticles[index].Stop();
            if (!gameObject.activeInHierarchy)
                Destroy(activeParticles[index].gameObject);
            activeParticles.RemoveAt(index);
            particleRanks.RemoveAt(index);
            UpdateRotations();
            UpdateGlow();
        }
    }

    void Update(){
        if (!grazingEnabled) return;
        int i = 0;
        foreach(SCR_SpeedCalc spdScript in activeCollisions){
            UpdateParticle(spdScript.velocity,i);
            i++;
        }
    }

    int GetParticleIndexFromVelocity(float velocity){
        int i = 0;
        foreach (float speed in speedTresholds){
            if (velocity < speed)
                return i;
            else
                i++;
        }
        return particles.Length-1;
    }

    void UpdateParticle(float velocity,int index){
        if (!grazingEnabled) return;
        int particleRank = GetParticleIndexFromVelocity(velocity);
        if ((index == -1)||(particleRank != particleRanks[index])){
            ParticleSystem newParticle = Instantiate(particles[particleRank] , transform.position, Quaternion.identity, transform);
            newParticle.gameObject.SetActive(true);
            if (index != -1) {
                activeParticles[index].Stop();
                activeParticles[index] = newParticle;
                particleRanks[index] = particleRank;
            }else{
                activeParticles.Add(newParticle);
                particleRanks.Add(particleRank);
            }
            UpdateRotations();
            UpdateGlow();
        }
    }

    void UpdateRotations(){
        if (!grazingEnabled) return;
        int rank = GetMaxRank()+1;
        rotScript.SetSpeed(rank);
        audioScript.SetVolume(rank);
    }

    void UpdateGlow(){
        if (!grazingEnabled) return;
        if (GetMaxRank() >= 1)
            glowScript.Glow();
        else
            glowScript.Dull();
    }

    int GetMaxRank(){
        int maxRank = -1;
        foreach(int rank in particleRanks){
            if (maxRank < rank) maxRank = rank;
        }
        return maxRank;
    }
}