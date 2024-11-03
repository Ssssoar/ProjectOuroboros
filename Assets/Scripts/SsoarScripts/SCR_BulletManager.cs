using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_BulletManager : MonoBehaviour{
    public static SCR_BulletManager instance;
    private void Awake(){
        if (SCR_BulletManager.instance != null) Destroy(gameObject);
        else instance = this;
    }

    internal List<SCR_ChaseBullet> bullets = new List<SCR_ChaseBullet>();

    public void RemoveBullet(SCR_ChaseBullet bullet){
        bullets.Remove(bullet);
    }

    public void KillBullets(){
        foreach (SCR_ChaseBullet bullet in bullets){
            bullet.Kill();
        }
    }
}
