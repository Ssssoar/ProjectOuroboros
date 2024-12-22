using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_BulletManager : MonoBehaviour{
    public static SCR_BulletManager instance;
    private void Awake(){
        if (SCR_BulletManager.instance != null) Destroy(gameObject);
        else instance = this;
    }

    internal List<Damager> bullets = new List<Damager>();

    public void RemoveBullet(Damager bullet){
        bullets.Remove(bullet);
    }

    public void ActivateBullets(){
        foreach(Damager bullet in bullets){
            bullet.Activate();
        }
    }

    public void TriggerBullets(){
        foreach(Damager bullet in bullets){
            bullet.Trigger();
        }
    }

    public void CleanBullets(){
        foreach (Damager bullet in bullets){
            bullet.Clean();
        }
    }
}
