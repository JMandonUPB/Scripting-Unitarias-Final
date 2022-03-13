using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCoreAI : MonoBehaviour
{
    //General nav logic
    public NavMeshAgent agent;

    //Timers
    private float roamTimer = 0f;
    private float roamTimerMax = 4f;

    //debug
    private Renderer renderer;

    //Main enemy personality options
    [SerializeField] float triggerEnemyDistance = 10f;
    [SerializeField] float triggerEnemyExitDistance = 14;

    private float idleTimerMax = 3f;
    private float idleTimerMin = 1f;

    

    bool isCurrentlyMovingToWaypoint = false;

    private float distanceFromPlayer = 0f;

    //References
    [SerializeField]  GameObject playerBaseGameObject;

    [SerializeField] private Material materialGrey; //these are for debugging!
    [SerializeField] private Material materialRed;
    [SerializeField] private Material materialRedPurple;
    [SerializeField] private Material materialGreen;
    [SerializeField] private Material materialBlue;

    [SerializeField] private GameObject roamPoint1;
    [SerializeField] private GameObject roamPoint2;
    [SerializeField] private GameObject roamPoint3;

    private Vector3 roamPosition1;
    private Vector3 roamPosition2;
    private Vector3 roamPosition3;
    private GameObject debugStateBall;

    private GameObject playerArmature; //this one has the "proper" transform of the actual player

    //Melee logic
    private GameObject meleeHitbox;
    private float meleeTimer = 0;
    private float meleeTimerMax = 0.3f;

    private float triggerEnemyMeleeDistance = 2.9f;
    private float rangedAttackDistance; //unused 4 now

    private bool canMeleeAttack = false;

    //idle logic
    private float idleTimer = 0;

    //Quick temporal debug variables
    [SerializeField] int currentPathInt = 0;
    [SerializeField] int randomIntGenerator;

    private enum State
    {
        Idle,
        RoamingAround,
        ChasingPlayer,
        AttackPlayer,
        ReturnToRoamPoint
    }

    [SerializeField] private State state;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        renderer = transform.Find("DebugStateBall").GetComponent<Renderer>();
        playerArmature = playerBaseGameObject.transform.Find("PlayerArmature").gameObject; //if null ref error triggers here, you must find (type the name) the gameobject that holds the actual character sin dezface
        meleeHitbox = transform.Find("MeleeHitbox").gameObject;
    }
    
    private void Start()
    {
        roamPosition1 = roamPoint1.GetComponent<Transform>().position;
        roamPosition2 = roamPoint2.GetComponent<Transform>().position;
        roamPosition3 = roamPoint3.GetComponent<Transform>().position;
        state = State.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        StateSwitcher();
        DistanceFromPlayer(); //for debugging
    }

    void StateSwitcher()    //manages states
    {
            switch (state)
            {
                case State.Idle:
                Idle();
                //Debug.Log("Idle");
                break;

            case State.RoamingAround:
                RoamingAround();
                //Debug.Log("RoamingAround");
                break;

                case State.ChasingPlayer:
                 ChasePlayer();
                 //Debug.Log("ChasingPlayer");
                    break;

            case State.AttackPlayer:
                AttackPlayer();
                 //Debug.Log("AttackingPlayer");
                    break;

            case State.ReturnToRoamPoint:
                RoamingAround();
                  //Debug.Log("ReturnToRoamPoints");
                    break;

                default:
                Idle();
                    break;
            }
        }

    void Idle() //Enemy se mantiene en animacion idle, comienza a moverse si el temporizador idle se acaba o si ve al player
    {
        
        agent.isStopped = true; //stops agent

        renderer.material = materialGrey; //para simular cambio de estado
       // Debug.Log("Im currently idle");
        idleTimer += Time.deltaTime;

        if (idleTimer > Random.Range(idleTimerMin, idleTimerMax)) //va (enemigo) a diambular si se cumple
        {
            idleTimer = 0;
            state = State.RoamingAround;
        }

        if (IsPlayerInTriggerDistance())
        {
            state = State.ChasingPlayer;
        }
    }
    float DistanceFromPlayer() //calcula la distancia del enemigo al player 
    {
        //Debug.Log("Distancia " + (distanceFromPlayer = Vector3.Distance(playerArmature.transform.position, transform.position))); //for debbuging
        return distanceFromPlayer = Vector3.Distance(playerArmature.transform.position, transform.position); //calcula distancia

        
    }
    bool IsPlayerInMeleeAttackDistance()
    {
        if (DistanceFromPlayer()<= triggerEnemyMeleeDistance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    bool IsPlayerInTriggerDistance() //se activa al estar suficientemente cerca al player
    {
        bool isPlayerClose = false;
        if (DistanceFromPlayer() <= triggerEnemyDistance)
        {
            isPlayerClose = true;
        }
        else isPlayerClose = false;

        return isPlayerClose;
    }

    bool IsPlayerInExitDistance()
    {
        bool isPlayerFar = false;
        

        if (DistanceFromPlayer() >= triggerEnemyExitDistance)
        {
            isPlayerFar = true;
        }
        else isPlayerFar = false;

        return isPlayerFar;
    }
    void RoamingAround()
    {

      
       //[SerializeField] int currentPathInt = 0;
       // [SerializeField]int randomIntGenerator;
        meleeHitbox.SetActive(false);

        agent.isStopped = false; //permite movimiento

        renderer.material = materialGreen;

        roamTimer += Time.deltaTime;
        float roamTimerMaxRandom = Random.Range(2, roamTimerMax);

        if (IsPlayerInTriggerDistance())
        {
            state = State.ChasingPlayer;
        }

        
        if (roamTimer > roamTimerMaxRandom) //nota, este codigo puede mejorarse si se identifica que haya llegado a cada waypoint
        {
            randomIntGenerator = Random.Range(1, 5);
            //Debug.LogWarning("Random int " + randomIntGenerator);

            if(randomIntGenerator == currentPathInt) //if the path is the same, change the number
            {
                randomIntGenerator = Random.Range(1, 5);
            }
            else //si el path no es el mismo, continuar
            {
                
                switch (randomIntGenerator)
                {
                    case 1:
                        ReachedWaypoint(); //goes idle if waypoint is reached
                        currentPathInt = randomIntGenerator;
                        MoveAgent(roamPosition1);
                        //Debug.Log("Poing to pos 1");
                        roamTimer = 0;
                        break;

                    case 2:
                        ReachedWaypoint();
                        currentPathInt = randomIntGenerator;
                        MoveAgent(roamPosition2);
                       // Debug.Log("Poing to pos 2");
                        roamTimer = 0;
                        break;

                    case 3:
                        ReachedWaypoint();
                        currentPathInt = randomIntGenerator;
                        MoveAgent(roamPosition3);
                       // Debug.Log("Poing to pos 3");
                        roamTimer = 0;
                        break;

                    case 4:
                        roamTimer = 0;
                        state = State.Idle;
                        break;
                }
            }

          
        }
    }
    void AttackPlayer()
    {

        if (canMeleeAttack)
        {
            meleeTimer += Time.deltaTime;

            renderer.material = materialRedPurple;

            if (meleeTimer > meleeTimerMax)
            {
                meleeHitbox.SetActive(true);
            }

            if (meleeTimer > meleeTimerMax + 0.3f)
            {
                meleeHitbox.SetActive(false);
                meleeTimer = 0f;
            }
        }

        if (!IsPlayerInMeleeAttackDistance())
        {
            canMeleeAttack = false;
            state = State.ChasingPlayer;
        }

    }
    void ChasePlayer()
    {
        meleeHitbox.SetActive(false);

        agent.isStopped = false; //permite movimiento

        if (IsPlayerInTriggerDistance())
        {
            MoveAgent(playerArmature.transform.position);
            renderer.material = materialRed;
        }
        else if (IsPlayerInExitDistance())
        {
            state = State.Idle;
        }

        if (IsPlayerInMeleeAttackDistance())
        {
            canMeleeAttack = true;
            state = State.AttackPlayer;
        }
        else canMeleeAttack = false;
    }

    void ReachedWaypoint() 
    {
        if (agent.pathStatus == NavMeshPathStatus.PathComplete)
        {
            state = State.Idle;
            //reachedWaypoint = true;
        }

     }
    void MoveAgent(Vector3 moveDestinationVec3)
    {
        agent.SetDestination(moveDestinationVec3);
        isCurrentlyMovingToWaypoint = true;
        //if (isCurrentlyMovingToWaypoint) unfinished
        //{

        //}
    }

}
