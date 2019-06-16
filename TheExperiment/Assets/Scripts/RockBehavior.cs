using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;

public class RockBehavior : MonoBehaviour
{
    private Vector2 _targetPos;
	[SerializeField]
    private float _speed = 10;
	[SerializeField]
    private float _arcHeight = 1;

	private Animator _animator;
	
	
        private Vector2 _startPos;
	
        void Start() {
            // Cache our start position, which is really the only thing we need
            // (in addition to our current position, and the target).
            _targetPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
	        _animator = transform.GetComponent<Animator>();
            _startPos = transform.position;
        }
	
        void Update() {
            // Compute the next position, with arc added in
            float x0 = _startPos.x;
            float x1 = _targetPos.x;
            float dist = x1 - x0;
            float nextX = Mathf.MoveTowards(transform.position.x, x1, _speed * Time.deltaTime);
            float baseY = Mathf.Lerp(_startPos.y, _targetPos.y, (nextX - x0) / dist);
            float arc = _arcHeight * (nextX - x0) * (nextX - x1) / (-0.25f * dist * dist);
            Vector2 nextPos = new Vector2(nextX, baseY + arc);
		
            // Rotate to face the next position, and then move there
            transform.rotation = LookAt2D(nextPos - (Vector2)transform.position);
            transform.position = nextPos;
		
            // Do something when we reach the target
            if (nextPos == _targetPos)
	            _animator.Play("RockDisapear");
        }

	public void DestroyRock()
	{
		Destroy(gameObject);
	}
	
        /// 
        /// This is a 2D version of Quaternion.LookAt; it returns a quaternion
        /// that makes the local +X axis point in the given forward direction.
        /// 
        /// forward direction
        /// Quaternion that rotates +X to align with forward
        static Quaternion LookAt2D(Vector2 forward) {
            return Quaternion.Euler(0, 0, Mathf.Atan2(forward.y, forward.x) * Mathf.Rad2Deg);
        }
}
