using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour
{
    void Update()
    {
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        }
    }
}