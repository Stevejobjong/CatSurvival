using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core.Easing;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    [SerializeField] Transform Propellor;
    [SerializeField] GameObject UIPanel;
    [SerializeField] GameObject Smoke;
    [SerializeField] GameObject Fire;
    [SerializeField] GameObject Airplane;
    [SerializeField] Image black;

    void Start()
    {
        
    }

    void Update()
    {
    }
    private void FixedUpdate()
    {
        Propellor.transform.Rotate(new Vector3(0, 45, 0));

    }

    public void OnStartButton()
    {
        StartCoroutine(GameStart());
    }

    IEnumerator GameStart()
    {
        UIPanel.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        Smoke.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        Fire.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        Airplane.transform.DORotate(new Vector3(0, 0, -15f), 2);
        Airplane.transform.DOMove(new Vector3(43.81f, 3.81f, 4.72f), 3);
        yield return new WaitForSeconds(3.0f);
        yield return null;
        Color c = black.color;
        while (c.a < 1)
        {
            c.a += 0.01f;
            black.color = c;
            yield return null;
        }
        SceneManager.LoadScene("jwScene");
    }
}
