using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SCR_ChaseBullet : MonoBehaviour{
    [SerializeField] float speed;
    [SerializeField] float handling;
    public Transform target;
    [SerializeField] float lifeTime;
    [SerializeField] UnityEvent onBeginChase;
    [SerializeField] UnityEvent onDie;
    bool began = false;

    void Start(){
        transform.right = target.position - transform.position;
        SCR_BulletManager.instance.bullets.Add(this);
    }

    void FixedUpdate(){
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0f){
            Kill();
        }else if (speed != 0f){
            if (!began){
                onBeginChase?.Invoke();
                began = true;
            }
            Vector3 directLine = target.position - transform.position;
            float angle = Vector2.SignedAngle(transform.right,directLine);
            float angleSign = 0f;
            if (angle != 0f) angleSign = angle / Mathf.Abs(angle);
            float finalRot = angleSign * handling * Time.deltaTime;
            if (Mathf.Abs(finalRot) > Mathf.Abs(angle)) finalRot = angle;
            transform.Rotate(0f,0f,angleSign * handling * Time.deltaTime);


            /*transform.right = Vector3.RotateTowards(transform.right , directLine , handling * Time.deltaTime , 0f);
            transform.eulerAngles = new Vector3(0f,0f,transform.eulerAngles.z);*/
            transform.Translate(Vector3.right * speed * Time.deltaTime); 
        }
    }

    public void Kill(){
        onDie?.Invoke();
        Destroy(gameObject);
    }

    void OnDestroy(){
        SCR_BulletManager.instance.RemoveBullet(this);
    }
}
