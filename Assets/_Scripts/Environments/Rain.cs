using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    public ParticleSystem rainParticle;
    public Material cloudMaterial;
    public AudioSource audioSource;
    public AudioClip rainSound;
    public AudioClip thunderSound;

    public float minRainDuration = 30.0f;
    public float maxRainDuration = 300.0f;
    public float delayRain = 5.0f;
    private float RainProbability = 100;
    private bool isRaining = false;

    private Color originalColor;

    void Start()
    {
        StopRain();
        StartCoroutine(UpdateRainProbabilityRoutine());
    }


    private void Update()
    {
        if (!isRaining) // 비가 내리지 않고 있는 상태에서만 실행
        {
            if (GameManager.Instance.RainProbability > RainProbability)
            {
                StartCoroutine(RainCoroutine());
                isRaining = true;
            }
        }
    }

    IEnumerator RainCoroutine()
    {
        isRaining = true;
        PlayThunderSound();
        yield return new WaitForSeconds(delayRain); // 비가 시작되기 전에 지연
        StartRain();
        RainProbability = 100;
        yield return new WaitForSeconds(Random.Range(minRainDuration, maxRainDuration));
        StopRain();
        
        isRaining = false;
        cloudMaterial.color = originalColor;
    }

    IEnumerator UpdateRainProbabilityRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(60.0f);
            if (!isRaining)
            {
                RainProbability = Random.Range(0, 100);
            }
        }
    }

    void StartRain()
    {
        rainParticle.Play();
        audioSource.clip = rainSound;
        audioSource.loop = true;
        audioSource.Play();
        GameManager.Instance.IncreaseTemperature -= 5;
    }

    void StopRain()
    {
        rainParticle.Stop();
        audioSource.Stop();
        GameManager.Instance.IncreaseTemperature += 5;
    }

    void PlayThunderSound()
    {
        if (thunderSound != null)
        {
            audioSource.PlayOneShot(thunderSound);
        }
    }
}
