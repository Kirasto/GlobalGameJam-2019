using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    public static HealthBarController instance;
    [SerializeField]
    GameObject healthBarPrefabs;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
    }

    public static GameObject CreateHealthBar()
    {
        if (instance)
            return instance.CreateHealthBarInstance();
        return null;
    }

    public GameObject CreateHealthBarInstance()
    {
        return Instantiate(healthBarPrefabs, transform.Find("Ennemies"));
    }
}
