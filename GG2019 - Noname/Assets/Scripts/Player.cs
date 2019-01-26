using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 1f;
    [SerializeField]
    bool canMove;

    [SerializeField]
    Rigidbody rigidbody;

    private void Awake()
    {
        canMove = true;
        rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (!canMove)
            return;

        Vector3 velocity = new Vector3(0, 0, 0);
        if (Input.GetKey(KeysStore.GetKeyCode("Up")))
        {
            velocity.z += moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeysStore.GetKeyCode("Down")))
        {
            velocity.z -= moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeysStore.GetKeyCode("Left")))
        {
            velocity.x -= moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeysStore.GetKeyCode("Right")))
        {
            velocity.x += moveSpeed * Time.deltaTime;
        }

        transform.position += velocity;
    }
}
