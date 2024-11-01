using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SCR_ChaseBullet : MonoBehaviour{
    [SerializeField] float speed;
    [SerializeField] float handling;
    public Transform target;
    [SerializeField] float lifeTime;
    [SerializeField] UnityEvent onDie;

    void FixedUpdate(){
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0f){
            onDie?.Invoke();
            Destroy(gameObject);
        }else{
            Vector3 directLine = target.position - transform.position;
            transform.right = Vector3.RotateTowards(transform.right , directLine , handling * Time.deltaTime , 0f);
            transform.eulerAngles = new Vector3(0f,0f,transform.eulerAngles.z);
            transform.Translate(Vector3.right * speed * Time.deltaTime); 
        }
    }
}
