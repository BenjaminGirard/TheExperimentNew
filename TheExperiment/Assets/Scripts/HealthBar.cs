using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform _bar;
    private float _fillPercent = 100;

    // Start is called before the first frame update
    void Start()
    {
        _bar = transform.Find("ScaleFixed");
    }

    public void SubFillBar(float percentage)
    {
        _fillPercent -= percentage;
        if (_fillPercent <= 0)
            _fillPercent = 0;
        _bar.localScale = new Vector3(_fillPercent/100, 1f, 1f);
    }
}
