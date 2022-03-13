using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCreator : MonoBehaviour
{
    [SerializeField] GameObject floor;
    // Start is called before the first frame update
    void Awake()
    {
        Instantiate(floor, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
