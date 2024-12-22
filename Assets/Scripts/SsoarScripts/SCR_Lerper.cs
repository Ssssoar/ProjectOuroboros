using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Lerper : MonoBehaviour{
    [System.Serializable]
    struct Move{
        public Vector3 pos;
        public Vector3 point;
        public float lerpStrength;
        
        public Move(Vector3 Pos, Vector3 Point, float LerpStrength) {
            this.pos = Pos;
            this.point = Point;
            this.lerpStrength = LerpStrength;
        }
    }

    [Header("Parameters")]
    [SerializeField] float defaultLerp;
    public float controlValue;

    [Header("Variables")]
    Move activeMove;
    Move defaultMove;
    Move moveStart;
    bool controlled = false;

    void Start(){
        defaultMove = new Move(transform.position,transform.right,defaultLerp);
        moveStart = defaultMove;
    }

    public void StartMove(Vector3 toPos, Vector3 toPoint , float lerp){
        activeMove = new Move(toPos,toPoint,lerp);
    }

    public void StartMove(Vector3 toPos, Vector3 toPoint){
        activeMove = new Move(toPos,toPoint,defaultLerp);
    }

    public void StartControl(){
        controlled = true;
        moveStart = new Move(transform.position,transform.right,defaultLerp);
    }

    public void EndControl(){
        controlled = false;
    }

    public void ReturnMove(){
        activeMove = defaultMove;
    }

    void FixedUpdate(){
        if (!controlled){
            transform.position = Vector3.Lerp (transform.position, activeMove.pos  , activeMove.lerpStrength * Time.deltaTime);
            transform.right    = Vector3.Slerp(transform.right   , activeMove.point, activeMove.lerpStrength * Time.deltaTime);
        }else{
            transform.position = Vector3.Lerp (moveStart.pos     , activeMove.pos  , controlValue);
            transform.right    = Vector3.Lerp (moveStart.point   , activeMove.point, controlValue);
        }
    }
}
