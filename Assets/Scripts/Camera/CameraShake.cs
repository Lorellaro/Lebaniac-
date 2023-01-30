using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    CinemachineVirtualCamera vCam;
    CinemachineBasicMultiChannelPerlin vCamNoise;

    float shakeTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        vCam = GetComponent<CinemachineVirtualCamera>();
        vCamNoise = vCam.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
    }

    public void cameraShake(float frequency, float amplitude, float duration)
    {
        if(shakeTime > 0)
        {
            return;
        }

        vCamNoise.m_FrequencyGain = frequency;
        vCamNoise.m_AmplitudeGain = amplitude;
        shakeTime = duration;
    }

    private void Update()
    {
        if(shakeTime > 0)
        {
            shakeTime -= Time.deltaTime;
        }

        else
        {
            vCamNoise.m_FrequencyGain = 0f;
            vCamNoise.m_AmplitudeGain = 0f;
        }
    }
}
