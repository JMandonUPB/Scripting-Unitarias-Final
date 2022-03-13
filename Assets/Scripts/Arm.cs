using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    bool IsAttacking = false;//tambien se utilizara para llamar la animacion 
    bool IsFromPlayer = true; //Es verdadero por pruebas, cuando esten las animaciones de las espadas sera falso, por favor contacta con camargo.

    //Tipo de arma
    public bool IsASword;
    public bool IsABroadsword;
    public bool IsASAxe;

    //esto es para ponerlo comunicar con otros scrpit
    public static bool IS = false;
    public static bool IB = true;
    public static bool IA = false;

    [SerializeField] Transform hand;
    private GameObject sword;

    private Transform Tsword;

    int damage = 1; //daño de la espada
    [SerializeField] float AttackTime;
    private float attackCode;
    private CapsuleCollider thecapsule;

    private void Awake()
    {

        thecapsule = gameObject.GetComponent<CapsuleCollider>();
        sword = gameObject;
        Tsword = gameObject.GetComponent<Transform>();
    }

    private void Start()
    {
        
        
        
        thecapsule.enabled = false;
        sword.transform.SetParent(hand);
        attackCode = AttackTime;
    }

    // Update is called once per frame
    void Update()
    {
        IS = IsASword;
        IB = IsABroadsword;
        IA = IsASAxe;

        Tsword.localPosition = new Vector3(0, 0, 0);
        if (IsFromPlayer) //si el objecto lo tiene el jugador entonces funcionara
        {
            if (Input.GetMouseButtonUp(0) || IsAttacking)//llamado a la funcion de atacar al apretar clic izquierdo
            {
                IsAttacking = true;
                thecapsule.enabled = true;
                Attack();
            }
        }
    }

    void Attack() //funcion para atacar.
    {
        if (IsAttacking)
        {
            attackCode -= Time.deltaTime;
            if (attackCode <= 0)
            {
                Debug.Log("ya no estoy atacando :c");
                IsAttacking = false;
                thecapsule.enabled = false;
                attackCode = AttackTime;
            }

        }

    }
}