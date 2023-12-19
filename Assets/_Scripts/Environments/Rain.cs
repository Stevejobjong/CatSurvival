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

    
    public float minRainDuration = 10.0f;
    public float maxRainDuration = 300.0f;
    public float delayRain = 5.0f;
    private float RainProbability = 100;
    private bool isRaining = false;

    private Color originalColor;

    void Start()
    {
        StopRain();
        originalColor = cloudMaterial.color;
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
        cloudMaterial.color = Color.gray;
        //어두워지고 먹구름
        yield return new WaitForSeconds(delayRain); // 비가 시작되기 전에 지연
        StartRain();  
        yield return new WaitForSeconds(Random.Range(minRainDuration, maxRainDuration));
        StopRain();
        
        isRaining = false;
        cloudMaterial.color = originalColor;
    }

    IEnumerator UpdateRainProbabilityRoutine()
    {
        yield return new WaitForSeconds(10.0f);
        RainProbability = Random.RandomRange(0, 100);

        while (true)
        {
            yield return new WaitForSeconds(10.0f);
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
