using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    //여기서 비 딸깍하자
    //비에 추가효과? 물안개 먹구름 번개 비내리는 소리까지
    //시간마다 확률이 찍히고 온도가 몇 이하면 비, 아니면 눈 이건 따로?

    public ParticleSystem rainParticle;
    public Material cloudMaterial;
    public AudioSource audioSource;
    public AudioClip rainSound;
    public AudioClip thunderSound;

    public float minRainDuration = 10.0f;
    public float maxRainDuration = 60.0f;
    public float rainProbability = 10.0f;
    public float delayRain = 5.0f;
    public float temperatureThreshold = 20.0f; // 비와 눈을 구분하기 위한 온도 임계치

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
            //어두워지고 먹구름
            yield return new WaitForSeconds(delayRain); // 비가 시작되기 전에 지연
            StartRain();

            yield return new WaitForSeconds(Random.Range(minRainDuration, maxRainDuration));

            StopRain();
            isRaining = false;
            cloudMaterial.color = originalColor;
        }
    }

    bool ShouldStartRain()
    {  
        //온도가 낮으면 눈
        float temperature = GetTemperature(); // 온도를 가져오는 함수 호출 필요
        if (temperature < temperatureThreshold)
        {
            // 눈이 내리는 로직 추가
            return false;
        }

        // 확률적으로 비 시작 결정
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
        // 온도를 가져오는 로직 구현 필요
        // 예를 들어 날씨 API 호출 또는 게임 내에서 설정된 온도 값을 반환
        return 25.0f; // 임의의 온도 값 반환, 실제 온도를 가져오는 로직으로 대체해야 함
    }
}