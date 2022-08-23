using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float timeFromStart;

    private void Awake()
    {
        timeFromStart = 0f;
    }

    private void Update()
    {
        timeFromStart += Time.deltaTime;
    }
}
