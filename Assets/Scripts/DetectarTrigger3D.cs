using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class DetectarTrigger3D : MonoBehaviour
{
    public string tagg;

    public UnityEvent OnEnter;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(tagg))
        {
            OnEnter.Invoke();
        }
    }
}
