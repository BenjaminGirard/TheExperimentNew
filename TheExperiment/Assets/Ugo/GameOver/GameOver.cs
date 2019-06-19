using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public float speed;
    public float amount;
    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(pos.x + Mathf.Sin(Time.time * speed) * amount, pos.y + Mathf.Sin(Time.time * speed) * amount, pos.z);

    }
}
