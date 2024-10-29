using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_BarDisplay : MonoBehaviour{

    [SerializeField] Image barImg;
    [SerializeField] int current,max;
    [SerializeField] float lerpStrength;
    [SerializeField] Transform empty,full;
    float targetFill,currentFill;
    bool moveMode = false;

    void Start(){
        if ((empty != null) && (full != null)){
            moveMode = true;
        }
    }

    void Update(){
        UpdateTarget();
        UpdateBar();
    }

    public void SetBar(int value, int total){
        current = value;
        max = total;
        ClampValue();
        UpdateTarget();
    }

    public void SetBar(int value){
        SetBar(value,max);
    }

    void ClampValue(){
        if (current < 0)
            current = 0;
        else if (current > max)
            current = max;
    }
    
    void UpdateTarget(){
        if (barImg != null){
            float _currentHp = (float)current;
            float fillImage = _currentHp / max;
            targetFill = fillImage;
        }
    }

    void UpdateBar(){
        currentFill = Mathf.Lerp(currentFill , targetFill , lerpStrength);
        if (!moveMode){
            barImg.fillAmount = currentFill;
        }else{
            barImg.transform.position = Vector3.Lerp(empty.position,full.position,currentFill);
        }
    }

    public void ChangeColor(Color color){
        barImg.color = color;
    }
}
