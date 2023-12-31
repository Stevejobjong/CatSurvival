﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class WetConditionController : MonoBehaviour
{
    private PlayerConditions playerConditions;
    private Coroutine dryCoroutine;

    public AudioSource audioSource;
    public AudioClip WaterSound;

    private void Awake()
    {
        playerConditions = GetComponent<PlayerConditions>(); //현재 player에 달려있는 playercondition 가져오기
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            Debug.Log("물에빠짐");
            audioSource.clip = WaterSound;
            audioSource.Play();
            if (!playerConditions.isWet)
                playerConditions.temperature.Subtract(5);
            if (dryCoroutine != null) StopCoroutine(dryCoroutine);
            playerConditions.isWet = true;

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            dryCoroutine = StartCoroutine(Dry());
        }
    }

    IEnumerator Dry()
    {
        yield return new WaitForSeconds(10f);

        playerConditions.isWet = false;
        Debug.Log("물이 마름");
    }
}
