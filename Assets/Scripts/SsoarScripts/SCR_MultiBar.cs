using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_MultiBar : MonoBehaviour{
    [Header("References")]
    [SerializeField] SCR_BarDisplay effectBar;
    [SerializeField] SCR_BarDisplay actualBar;

    [Header("Parameters")]
    [SerializeField] float catchupTime;
    [SerializeField] Color lossColor,gainColor;

    [Header("Variables")]
    int max,current;
    bool gain;
    float timer = -1f;

    void Update(){
        if (timer <= 0f) return;
        timer -= Time.deltaTime;
        if (timer <= 0f){
            actualBar.SetBar(current,max);
            effectBar.SetBar(current,max);
        }
    }

    public void ChangeValue(int value, int total){
        gain = (value >= current);
        current = value;
        max = total;
        effectBar.ChangeColor( (gain)? gainColor : lossColor );
        if(gain)
            effectBar.SetBar(value,total);
        else
            actualBar.SetBar(value,total);
        timer = catchupTime;
    }

    public void ChangeValue(int value){
        ChangeValue(value,max);
    }
}
