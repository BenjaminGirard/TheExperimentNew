using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

    public Transform firePoint;

	void FixedUpdate ()
    {
        // Shot
        if (Input.GetKey(KeyCode.Mouse0))
            firePoint.GetComponent<ParticleSystem>().Emit(1);
    }
}
