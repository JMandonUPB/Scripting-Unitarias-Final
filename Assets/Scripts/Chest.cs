using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    private LootableObject Ib;
    float timeOut = 1;
    float timeOut1 = 1;
    bool Tiem= true;
    public GameObject[] Iteam;
    public GameObject posicion ;
    int  i;
    [SerializeField] Animator animatiors;
   

    // Start is called before the first frame update
    void Drop()
    {
        i = Random.Range(0, (Iteam.Length));
        GameObject disparar = Instantiate(Iteam[i], posicion.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Tiem)
        {

            animatiors.Play("chet");
            timeOut -= Time.deltaTime;
            if (timeOut<0)
            {
                timeOut = timeOut1;
                Tiem = true;
            }
        }
    }
     void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player") && timeOut== timeOut1)
        {
            Drop();
            Tiem = false;
        }
    }
}
