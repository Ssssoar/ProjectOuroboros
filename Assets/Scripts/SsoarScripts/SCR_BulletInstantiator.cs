using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_BulletInstantiator : MonoBehaviour{    
    [System.Serializable] public struct Shot{
        public Transform target;
        public SCR_ChaseBullet bulletPrefab;
    }
    
    [SerializeField] SCR_Lerper lerper;
    [SerializeField] Animator animComp;
    [SerializeField] Shot[] shots;
    [SerializeField] Transform[] shotPositions;
    [SerializeField] float posControl;
    [SerializeField] string shootAnim, shootEndAnim;

    bool controlling;
    float shotPosition; //RELATIVE TO CURRENT ACTIVE PUNCH, NOT A TRUE END POSITION

    public void PreShoot(){
        Transform chosenPos = shotPositions[Random.Range(0,shotPositions.Length)];
        lerper.StartControl();
        lerper.StartMove(chosenPos.position, -transform.position.normalized);
        animComp.Play(shootAnim);
        controlling = true;
    }

    void Update(){
        if (controlling){
            lerper.controlValue = posControl;
        }
    }

    public void ShootIndex(int i){
        SCR_ChaseBullet newBullet = Instantiate(shots[i].bulletPrefab , transform.position , Quaternion.identity);
        newBullet.target = shots[i].target;
    }

    public void ShootEnd(){
        animComp.Play(shootEndAnim);
        lerper.EndControl();
        lerper.ReturnMove();
        controlling = false;
    }
}
