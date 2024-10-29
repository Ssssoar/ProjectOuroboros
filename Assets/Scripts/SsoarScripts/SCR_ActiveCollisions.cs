using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_ActiveCollisions : MonoBehaviour{


    [SerializeField] string tagToWatch;
    [SerializeField] ParticleSystem[] particles;
    [SerializeField] float maxVelocity;
    [SerializeField] SCR_RotManager rotScript;
    
    List<SCR_SpeedCalc> activeCollisions = new List<SCR_SpeedCalc>();
    List<ParticleSystem> activeParticles = new List<ParticleSystem>();
    List<int> particleRanks = new List<int>();

    void OnTriggerEnter2D(Collider2D coll){
        if (coll.tag == tagToWatch){
            SCR_SpeedCalc spdScript = coll.gameObject.GetComponent<SCR_SpeedCalc>();
            activeCollisions.Add(spdScript);
            UpdateParticle(spdScript.velocity,-1);
        }
    }

    void OnTriggerExit2D(Collider2D coll){
        if (coll.tag == tagToWatch){
            SCR_SpeedCalc spdScript = coll.gameObject.GetComponent<SCR_SpeedCalc>();
            int index = activeCollisions.IndexOf(spdScript);
            activeCollisions.Remove(spdScript);
            activeParticles[index].Stop();
            activeParticles.RemoveAt(index);
            particleRanks.RemoveAt(index);
            UpdateRotations();
        }
    }

    void Update(){
        int i = 0;
        foreach(SCR_SpeedCalc spdScript in activeCollisions){
            UpdateParticle(spdScript.velocity,i);
            i++;
        }
    }

    int GetParticleIndexFromVelocity(float velocity){
        for (int i = 0; i<particles.Length; i++){
            if (velocity < (i+1)*(maxVelocity/particles.Length))
                return i;
        }
        return(particles.Length-1);
    }

    void UpdateParticle(float velocity,int index){
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
        }
    }

    void UpdateRotations(){
        rotScript.SetSpeed(GetMaxRank()+1);
    }

    int GetMaxRank(){
        int maxRank = -1;
        foreach(int rank in particleRanks){
            if (maxRank < rank) maxRank = rank;
        }
        return maxRank;
    }
}