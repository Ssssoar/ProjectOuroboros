using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SCR_ChaseBullet : MonoBehaviour , Damager{
    [SerializeField] float speed;
    [SerializeField] float speedFactor;
    [SerializeField] float handling;
    public Transform target;
    [SerializeField] float lifeTime;
    [SerializeField] UnityEvent beginChase;
    [SerializeField] UnityEvent onTrigger;
    [SerializeField] UnityEvent onClean;

    bool turning = false;
    bool moving = false;

    void Start(){
        transform.right = target.position - transform.position;
        SCR_BulletManager.instance.bullets.Add(this);
    }

    void FixedUpdate(){
        if (turning){
            Vector3 directLine = target.position - transform.position;
            float angle = Vector2.SignedAngle(transform.right,directLine);
            float angleSign = 0f;
            if (angle != 0f) angleSign = angle / Mathf.Abs(angle);
            float finalRot = angleSign * handling * Time.deltaTime;
            if (Mathf.Abs(finalRot) > Mathf.Abs(angle)) finalRot = angle;
            transform.Rotate(0f,0f,angleSign * handling * Time.deltaTime);
        }


        /*transform.right = Vector3.RotateTowards(transform.right , directLine , handling * Time.deltaTime , 0f);
        transform.eulerAngles = new Vector3(0f,0f,transform.eulerAngles.z);*/
        if (moving)
            transform.Translate(Vector3.right * speed * speedFactor * Time.deltaTime);
    }

    public void Activate(){
        //BEGIN CHASING
        turning = true;
        moving = true;
        beginChase?.Invoke();
    }

    public void Trigger(){
        onTrigger?.Invoke();
    }

    public void Clean(){
        onClean?.Invoke();
    }

    public void Eliminate(){
        Destroy(gameObject);
    }

    void OnDestroy(){
        SCR_BulletManager.instance.RemoveBullet(this);
    }

    public void Stop(){
        speed = 0f;
        turning = false;
        moving = false;
    }
}
