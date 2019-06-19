using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JeremyHead : MonoBehaviour
{
    public float spinSpeed;
    public float growFactor;
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
        transform.Rotate(0, 0, spinSpeed * Time.deltaTime);
        transform.localScale -= new Vector3(244.5651F, 244.5651F, 1) * Time.deltaTime * growFactor;
        transform.position = new Vector3(pos.x + Mathf.Sin(Time.time * speed) * amount, pos.y + Mathf.Sin(Time.time * speed) * amount, pos.z);
        if (transform.localScale.x < 1f)
        {
            SceneManager.LoadScene(0);
        }
    }
}
