using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootableSpawner : MonoBehaviour
{

    public GameObject item;
    public int probability;

    private bool spawn = false;
    // Start is called before the first frame update

    private int rng;
    void Start()
    {
    }

    void Awake() {
         rng = Random.Range(0, 100);
    }

    // Update is called once per frame
    void Update()
    {

        if (GetComponent<HealthManager>().IsDead && spawn == false && rng < probability) {
            Instantiate(item, transform.position, transform.rotation);
            spawn = true;
        }
    }
}
