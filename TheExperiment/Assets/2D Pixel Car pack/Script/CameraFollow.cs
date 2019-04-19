using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform CameraTarget;
    public float speed;
	
	// Update is called once per frame
	void FixedUpdate () {
        {
            TrackTarget();
        }
    }
    private void TrackTarget()
    {
        //move camera's position to the target position        
        transform.position = new Vector2(Mathf.Lerp(transform.position.x, CameraTarget.transform.position.x +1, Time.deltaTime * speed), 0);
    }
}
