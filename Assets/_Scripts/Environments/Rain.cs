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

    void Start()
    {
        StopRain();
        StartCoroutine(UpdateRainProbabilityRoutine());
    }


    private void Update()
    {
        if (!isRaining) // �� ������ �ʰ� �ִ� ���¿����� ����
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
        cloudMaterial.color = new Color(0f, 0f, 0f);
        PlayThunderSound();
        yield return new WaitForSeconds(delayRain); // �� ���۵Ǳ� ���� ����
        StartRain();
        RainProbability = 100;
        yield return new WaitForSeconds(Random.Range(minRainDuration, maxRainDuration));
        StopRain();

        isRaining = false;
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
        GameManager.Instance._isWet = true;
        audioSource.clip = rainSound;
        audioSource.loop = true;
        audioSource.Play();
        GameManager.Instance.IncreaseTemperature -= 5;
    }

    void StopRain()
    {
        rainParticle.Stop();
        audioSource.Stop();
        GameManager.Instance._isWet = false;
        GameManager.Instance.IncreaseTemperature += 5;
        cloudMaterial.color = new Color(255f, 255f, 255f);
    }

    void PlayThunderSound()
    {
        if (thunderSound != null)
        {
            audioSource.PlayOneShot(thunderSound);
        }
    }
}
