using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPulse : MonoBehaviour
{
    public float minRange = 1f;
    public float maxRange = 1.5f;
    public float duration = 0.5f;
    public float smoothness = 0.1f;

    Light LightSource;

    void Start()
    {
        LightSource = gameObject.GetComponent<Light>();
        LightSource.range = minRange;
        StartCoroutine("RangeUP");
    }

    // Increase light range
    IEnumerator RangeUP()
    {
        float progress = 0;
        float increment = smoothness / duration;
        while (progress < 1)
        {
            LightSource.range = Mathf.Lerp(minRange, maxRange, progress);
            progress += increment;
            yield return new WaitForSeconds(smoothness);
        }
        StartCoroutine("RangeDown");
    }

    // Decrease light range
    IEnumerator RangeDown()
    {
        float progress = 0;
        float increment = smoothness / duration;
        while (progress < 1)
        {
            LightSource.range = Mathf.Lerp(maxRange, minRange, progress);
            progress += increment;
            yield return new WaitForSeconds(smoothness);
        }
        StartCoroutine("RangeUP");
    }
}
