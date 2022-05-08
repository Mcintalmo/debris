using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;
    public Material waterMaterial;

    public float amplitudeX = 1f;
    public float amplitudeZ = 1f;
    public float frequencyX = Mathf.PI / 4;
    public float frequencyZ = Mathf.PI / 4;
    public float waveSpeedX = 1f;
    public float waveSpeedZ = 1f;

    private float offsetX = 0f;
    private float offsetZ = 0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
        waterMaterial.SetFloat("amplitudeX", amplitudeX);
        waterMaterial.SetFloat("amplitudeY", amplitudeZ);
        waterMaterial.SetFloat("frequencyX", frequencyX);
        waterMaterial.SetFloat("frequencyZ", frequencyZ);
        waterMaterial.SetFloat("waveSpeedX", waveSpeedX);
        waterMaterial.SetFloat("waveSpeedZ", waveSpeedZ);
    }

    private void FixedUpdate()
    {
        offsetX += Time.deltaTime * waveSpeedX;
        offsetZ += Time.deltaTime * waveSpeedZ;
    }

    public float GetWaveHeight(float _x, float _z)
    {
        return amplitudeX * Mathf.Sin(_x * frequencyX + offsetX) + amplitudeZ * Mathf.Sin(_z * frequencyZ + offsetZ);
    }
}
