using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    //���⼭ �� ��������
    //�� �߰�ȿ��? ���Ȱ� �Ա��� ���� �񳻸��� �Ҹ�����
    //�ð����� Ȯ���� ������ �µ��� �� ���ϸ� ��, �ƴϸ� �� �̰� ����?

    public ParticleSystem rainParticle;
    public Material cloudMaterial;
    public AudioSource audioSource;
    public AudioClip rainSound;
    public AudioClip thunderSound;

    public float minRainDuration = 10.0f;
    public float maxRainDuration = 60.0f;
    public float rainProbability = 10.0f;
    public float delayRain = 5.0f;
    public float temperatureThreshold = 20.0f; // ��� ���� �����ϱ� ���� �µ� �Ӱ�ġ

    public DateManager dateManager;

    private bool isRaining = false;

    private Color originalColor;

    void Start()
    {
        StopRain();
        originalColor = cloudMaterial.color;
        dateManager = FindObjectOfType<DateManager>();
    }

    private void Update()
    {
        if (isRaining == false)
        { 
            StartCoroutine(RainCoroutine());
        }
    }

    IEnumerator RainCoroutine()
    {
        if (ShouldStartRain())
        {
            isRaining = true;
            PlayThunderSound();
            cloudMaterial.color = Color.gray;
            //��ο����� �Ա���
            yield return new WaitForSeconds(delayRain); // �� ���۵Ǳ� ���� ����
            StartRain();

            yield return new WaitForSeconds(Random.Range(minRainDuration, maxRainDuration));

            StopRain();
            isRaining = false;
            cloudMaterial.color = originalColor;
        }
    }

    bool ShouldStartRain()
    {  
        //�µ��� ������ ��
        float temperature = GetTemperature(); // �µ��� �������� �Լ� ȣ�� �ʿ�
        if (temperature < temperatureThreshold)
        {
            // ���� ������ ���� �߰�
            return false;
        }

        // Ȯ�������� �� ���� ����
        float randomValue = Random.Range(0f, 100f);
        return randomValue < rainProbability;
    }

    void StartRain()
    {
        rainParticle.Play();
        audioSource.clip = rainSound;
        audioSource.loop = true;
        audioSource.Play();
    }

    void StopRain()
    {
        rainParticle.Stop();
        audioSource.Stop();
    }

    void PlayThunderSound()
    {
        if (thunderSound != null)
        {
            audioSource.PlayOneShot(thunderSound);
        }
    }

    float GetTemperature()
    {
        // �µ��� �������� ���� ���� �ʿ�
        // ���� ��� ���� API ȣ�� �Ǵ� ���� ������ ������ �µ� ���� ��ȯ
        return 25.0f; // ������ �µ� �� ��ȯ, ���� �µ��� �������� �������� ��ü�ؾ� ��
    }
}