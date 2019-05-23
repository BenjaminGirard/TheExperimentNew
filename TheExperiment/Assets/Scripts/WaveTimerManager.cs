using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class WaveTimerManager : MonoBehaviour
{
    private GameObject _spawner;

    private Text _text;


    private string getTime(float sec)
    {
        TimeSpan time = TimeSpan.FromSeconds(sec);
        return time.ToString("mm':'ss':'ff");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _spawner = GameObject.FindGameObjectWithTag("Spawner");
        
        _text = GetComponent<Text>();
        _text.text = "Next wave in " + getTime(_spawner.GetComponent<SpawnerManager>().TimeBetweenWaves);
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = "Next wave in " + getTime(_spawner.GetComponent<SpawnerManager>().TimeBetweenWaves);        
    }
}
