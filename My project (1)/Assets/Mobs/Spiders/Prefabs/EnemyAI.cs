using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    Rigidbody rb;
    Transform target;
    Vector2 moveDirection;
    public float Distance;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        {
            Vector3 direction = (target.position - transform.position).normalized;
           // float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
           // float zRotation = angle - 360f;
            // Subtracting 360 degrees to correctly align the rotation
          //  Quaternion rotation = Quaternion.Euler(0, 0, 0);
           // rb.rotation = rotation;
            moveDirection = direction;
            transform.LookAt(target);
            transform.Rotate(0, 180, 0);

        }
    }

    private void FixedUpdate()
    {
        if(target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }





}