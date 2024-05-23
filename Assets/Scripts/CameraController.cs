using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    private CinemachineVirtualCamera virtualCamera;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(gameObject);

        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }
    public void SetNoiseAmplitude(int value = 1)
    {
        virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = value;
    }
    public void SetFollowTargetNull()
    {
        virtualCamera.Follow = null;
    }
}
