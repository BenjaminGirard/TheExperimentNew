using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace DefaultNamespace
{
    public class SpiderAI : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 10.0f;
        private Transform _target;
        private bool _isIdle = true;
        private Animator _animator;
        private Rigidbody2D _rb;
        private Vector2 _direction;
        private SpriteRenderer _spriteRenderer;
        private HealthManager _healthManager;

        public int Sight = 40;
        private float cd = 0.0f;
        private Vector2 currentPositionTarget = new Vector2(0.0f, 0.0f);

        void SetNextPositionTarget() {

            if (Vector2.Distance(_target.transform.position, transform.position) < Sight)
            {
                currentPositionTarget = _target.transform.position;
            }
            else {
                currentPositionTarget = new Vector2(Random.Range(transform.position.x - Sight, transform.position.x + Sight), 
                    Random.Range(transform.position.y - Sight, transform.position.y + Sight));
            }
        }
        
        void Start() {            
            _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
                        
            _animator = transform.GetComponentInChildren<Animator>();
            _spriteRenderer = transform.GetComponentInChildren<SpriteRenderer>();
            _healthManager = transform.GetComponent<HealthManager>();

            _rb = transform.GetComponent<Rigidbody2D>();

            SetNextPositionTarget();
        }
 
        void Update()
        {
            if (_healthManager.IsDead)
            {
                _rb.Sleep();
                _rb.velocity = Vector2.zero;
                _rb.angularVelocity = 0;
                return;            
            }
            
            
            _spriteRenderer.flipX = _rb.velocity.x < 0;            
            
            if (_rb.velocity.magnitude > 0.3)
            {
                if (_isIdle)
                    _animator.SetBool("isIdle", false);
                _isIdle = false;
            }
            else
            {
                if (!_isIdle)
                    _animator.SetBool("isIdle", true);
                _isIdle = true;
            }

            if (cd <= 0)
            {
                if (Vector2.Distance(transform.position, currentPositionTarget) < 1.4)
                {
                    cd = 1.0f;
                } else
                {
                    _rb.AddForce((currentPositionTarget - (Vector2)transform.position) * _speed);   
                }    
            } else {
                cd = cd - Time.deltaTime;
                if (cd <= 0)
                    SetNextPositionTarget();
            }
        }
        
        void OnCollisionEnter2D(Collision2D col)
        {
            if (cd <= 0)
            {
                _rb.AddForce((currentPositionTarget - (Vector2)transform.position) * _speed);
                cd = 1.0f;                
            }
        }
    }
}