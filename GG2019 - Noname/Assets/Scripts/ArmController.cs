using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour
{
    List<Transform> enemies;

    private void Awake()
    {
        enemies = new List<Transform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.transform.GetComponent<Ennemy>())
            return;
        if (!enemies.Contains(other.transform))
            enemies.Add(other.transform);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.transform.GetComponent<Ennemy>())
            return;
        if (enemies.Contains(other.transform))
            enemies.Remove(other.transform);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (enemies.Count != 0)
            {
                enemies[0].GetComponent<Ennemy>().SetDamage(10);
            }
        }
    }
}
