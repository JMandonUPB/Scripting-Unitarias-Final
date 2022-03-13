using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] GameObject Jugador;
    public bool LifePlayer = false;
    private Transform spawn;

    private void Start()
    {
        spawn = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!LifePlayer)
        {
            Instantiate(Jugador, new Vector3(spawn.position.x, spawn.position.y + 2f, spawn.position.z), Quaternion.identity);
            LifePlayer = true;
        }
    }
}
