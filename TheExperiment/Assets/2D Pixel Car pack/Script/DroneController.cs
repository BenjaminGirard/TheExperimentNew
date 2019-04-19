using UnityEngine;

public class DroneController : MonoBehaviour {

    public Transform droneTarget;
    public float speed;

    void FixedUpdate()
    {        
        // The step size is equal to speed times frame time.
        float step = speed * Time.deltaTime;
        //LookAt droneTarget
        transform.rotation = Quaternion.Euler(0, 0, droneTarget.transform.eulerAngles.z);
        // Move drone a step closer to the target.
        transform.position = Vector3.Lerp(transform.position, droneTarget.position, step);
    }
}
