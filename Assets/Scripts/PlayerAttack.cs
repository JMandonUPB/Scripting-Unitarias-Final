using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    private float clickTime = 0.0f;
    [SerializeField] Arm ArmTipe;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && animator.GetBool("Grounded"))
        {
            clickTime += Time.deltaTime;
            
        }
        if(Input.GetMouseButtonUp(0) && animator.GetBool("Grounded") && clickTime < 0.5f)
        {
            clickTime = 0.0f;
            Attacking(1);
            
        }
        if (Input.GetMouseButtonUp(0) && animator.GetBool("Grounded") && clickTime >= 0.5f)
        {
            clickTime = 0.0f;
            Attacking(2);
            
        }
        if (!Input.GetMouseButtonUp(0))
        {
            animator.SetBool("Attack", false);
            animator.SetBool("Attack2", false);
            animator.SetBool("AttackAxe", false);
            animator.SetBool("AttackBroadsword", false);
            animator.SetBool("Attack2Axe", false);
            animator.SetBool("Attack2Broadsword", false);
        }


    }

    private void Attacking(int TheAttackIs)
    {
        if (TheAttackIs == 1 && animator.GetBool("Grounded"))
        {
            Debug.Log(Arm.IS);

            if (Arm.IS)
                animator.SetBool("Attack", true);
            if(Arm.IA)
                animator.SetBool("AttackAxe", true);
            if(Arm.IB)
                animator.SetBool("AttackBroadsword", true);

            TheAttackIs = 0;
            
        }


        if (TheAttackIs == 2 && animator.GetBool("Grounded"))
        {
            if (Arm.IS)
                animator.SetBool("Attack2", true);
            if (Arm.IA)
                animator.SetBool("Attack2Axe", true);
            if (Arm.IB)
                animator.SetBool("Attack2Broadsword", true);
            TheAttackIs = 0;
        }

    }
}
