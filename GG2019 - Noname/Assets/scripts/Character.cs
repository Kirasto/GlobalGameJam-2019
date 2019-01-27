using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    protected float maxHealth = 100;
    [SerializeField]
    protected float currentHealth = 100;
    [SerializeField]
    protected float damage = 10;
    [SerializeField]
    protected float defense = 10;
    [SerializeField]
    protected float moveSpeed = 1;
    [SerializeField]
    public bool canMove = true;

    void Start()
    {
    }
}
