using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_BulletInstantiator : MonoBehaviour{
    [System.Serializable] public struct Shot{
        public Transform target;
        public SCR_ChaseBullet bulletPrefab;
    }
    
    [SerializeField] Shot[] shots;

    public void ShootIndex(int i){
        SCR_ChaseBullet newBullet = Instantiate(shots[i].bulletPrefab , transform.position , Quaternion.identity);
        newBullet.target = shots[i].target;
    }

}
