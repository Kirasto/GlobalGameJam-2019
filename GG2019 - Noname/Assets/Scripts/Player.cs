using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField]
    float moveSpeed = 1f;
    [SerializeField]
    float rotationSpeed = 1f;
    [SerializeField]
    public bool canMove;
    [SerializeField]
    Transform ground;
    [SerializeField]
    Transform body;

    private void Awake()
    {
        canMove = true;
        body = transform.Find("Body");
    }

    // Start is called before the first frame update
    void Start()
    {
        DialogPanelController.setDialog("Ceci est un truc de test, il ne sert à rien, sauf à test logique non? une Blague ca vous dit ???!!", true);
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

        Vector3 mouse_pos = Input.mousePosition;
        Vector3 object_pos = Camera.main.WorldToScreenPoint(transform.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        float angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        body.rotation = Quaternion.Euler(new Vector3(0, -angle, 0));
    }
}
