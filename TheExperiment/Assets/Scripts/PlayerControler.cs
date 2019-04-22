using System;
using System.Collections;
using System.Collections.Generic;
using QInventory;
using System.Numerics;
using UnityEngine;
using UnityEngine.Tilemaps;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerControler : MonoBehaviour
{
    public GameObject inventory;
    [SerializeField]
    private float _speed = 50;
    private Rigidbody2D _rb;
    private Vector2 _moveVelocity;
    public Grid Grid;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _moveVelocity = moveInput.normalized * _speed;

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int coordinate = Grid.WorldToCell(mouseWorldPos);

            GameObject go = (GameObject)Instantiate(Resources.Load("crate_0"));
            go.transform.position = coordinate;
            // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            // if (hit)
            // {
            //     Debug.Log(hit.collider.gameObject.name);
            // }
        }

    }
    private void FixedUpdate()
    {
        _rb.AddForce(_moveVelocity); 
    }
}
