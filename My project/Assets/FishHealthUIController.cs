using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishHealthUIController : MonoBehaviour
{
    public Slider slider;
    private float coroutineTime = 0f;
    private bool isCoroutineActive = false;

    private void Start()
    {
        slider.gameObject.SetActive(false);
    }

    public void UpdateHealth(float percent)
    {
        slider.value = percent;
        slider.gameObject.SetActive(true);
        coroutineTime = 0f;
        if (isCoroutineActive)
            return;
        StartCoroutine("OnDisableTime");
    }

    IEnumerator OnDisableTime()
    {
        yield return null;
        isCoroutineActive = true;
        
        while (coroutineTime < 2f)
        {
            coroutineTime += Time.deltaTime;
            yield return null;
        }
        slider.gameObject.SetActive(false);
        isCoroutineActive = false;
    }
}
