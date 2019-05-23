using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveCounter : MonoBehaviour
{
    private SpawnerManager _spawner;
    // Start is called before the first frame update
    void Start()
    {
        _spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<SpawnerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "Wave " + _spawner.DifficultyIdx;
    }
}
