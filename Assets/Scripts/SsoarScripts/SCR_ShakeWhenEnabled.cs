using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_ShakeWhenEnabled : MonoBehaviour{
    [Header("Parameters")]
    [SerializeField] float shakeDistance;

    [Header("Variables")]
    Vector3 startPos;

    void Start(){
        startPos = transform.localPosition;
    }

    void Update(){
        float angle = Mathf.Rad2Deg * Random.Range(0f,360f);
        Vector3 displacement = new Vector3(
            Mathf.Cos(angle),
            Mathf.Sin(angle),
            0f
        );
        displacement *= shakeDistance;
        transform.localPosition = startPos + displacement;
    }

    void OnDisable(){
        transform.localPosition = startPos;
    }
}
