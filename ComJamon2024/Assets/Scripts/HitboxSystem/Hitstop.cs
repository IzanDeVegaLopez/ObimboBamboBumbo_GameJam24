using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitstop : MonoBehaviour
{
    [HideInInspector]
    public static Hitstop Instance;

    private bool waiting;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

    }

    public void Stop(float duration)
    {
        if (waiting) return;
        Time.timeScale = 0.0f;
        StartCoroutine("Wait",duration);
    }

    IEnumerator Wait(float duration)
    {
        waiting = true;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1.0f;
        waiting = false;
    }
}
