using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineShake : MonoBehaviour
{
    public static CinemachineShake Instance { get; private set;}
    CinemachineVirtualCamera vCamera;
    float shakeTimer;
    float shakeTimeTotal;
    float startingIntensity;

    private void Awake()
    {
        Instance = this;
        vCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin multiChannelPerlin = 
            vCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        shakeTimer = intensity;
        multiChannelPerlin.m_AmplitudeGain = intensity;
        shakeTimer = time;
        shakeTimeTotal = time;
    }

    void Update()
    {
        if(shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if(shakeTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin multiChannelPerlin = 
                    vCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                multiChannelPerlin.m_AmplitudeGain = 
                    Mathf.Lerp(startingIntensity, 0f, shakeTimer / shakeTimeTotal);
            }
        }
    }
}
