using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SCR_TextWriter : MonoBehaviour{
    [SerializeField] TMP_Text textComp;
    [SerializeField] string[] texts;
    int currentText = 0;

    public void AdvanceText(){
        currentText++;
        if (currentText >= texts.Length) currentText = texts.Length -1;
        textComp.text = texts[currentText];
    }

    public void Reset(){
        currentText = -1;
        AdvanceText();
    }
}
