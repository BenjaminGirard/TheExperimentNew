using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
 
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == ("WarpLeft"))
        {
            WarpLeft();
        }
        if (col.gameObject.tag == ("WarpRight"))
        {
            WarpRight();
        }
    }
    
    void WarpLeft()
    {
        transform.position = new Vector3(transform.position.x -35, transform.position.y, transform.position.z);
    }

    void WarpRight()
    {
        transform.position = new Vector3(transform.position.x +35, transform.position.y, transform.position.z);
    }
}
