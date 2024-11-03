using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SCR_CinemachineShake : MonoBehaviour{
    public static SCR_CinemachineShake instance;

    private void Awake(){
        if (SCR_CinemachineShake.instance != null) Destroy(gameObject);
        else instance = this;
    }
    [SerializeField] CinemachineVirtualCamera virtualCam;
    float decayFactor;
    CinemachineBasicMultiChannelPerlin shake;

    void Start(){
        shake = virtualCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void ShakeCamera(float intensity, float decay){
        shake.m_AmplitudeGain = intensity;
        decayFactor = decay;
    }

    void Update(){
        shake.m_AmplitudeGain = Mathf.Lerp(shake.m_AmplitudeGain , 0f , decayFactor * Time.deltaTime);
    }
}
