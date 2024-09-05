using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class CatController : MonoBehaviour, InteractableObject
{

    Cat cat;
    Player player;

    //import da navScript
    [SerializeField] protected Transform[] points;
    private int destPoint = 0;
    [SerializeField] protected float speed = 2.0f;

    Animator catAnimator;

    NavMeshAgent agent;
    private float sphereRadius = 2f;

    [SerializeField] public Transform playerTransform;

    bool isRunning, isWalking, idle;

    [SerializeField] public LayerMask mask;



    CatManager catManager;

    void Start()
    {
        this.cat = FindObjectOfType<CatLoader>().cat;
        this.player = FindObjectOfType<PlayerLoader>().player;
        Stat stat = cat.stats.FirstOrDefault(obj => obj.catTag == CatTag.FELICITA);

        catAnimator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        catManager = FindObjectOfType<CatManager>();

        isRunning = false;
        isWalking = true;
        idle = false;

        // da navScript
        agent.speed = speed;
        GotoNextPoint();
    }

    void Update()
    {

        if (!agent.pathPending && agent.remainingDistance < 0.5f && !idle)
            GotoNextPoint();

        if(!Physics.CheckSphere(transform.position, sphereRadius, mask) && idle)
        {
            idle = false;
            agent.speed = speed;
            catAnimator.SetBool("isIdle", idle);
        }

        if(Physics.CheckSphere(transform.position, sphereRadius, mask) && idle)
        {
            transform.LookAt(playerTransform.position);
        }
    }

    public void Interact()
    {
        
        Debug.Log("Miao!");

        idle = true;
        catAnimator.SetBool("isIdle", idle);
        agent.speed = 0f;
        transform.LookAt(playerTransform.position);

        CatItem item = player.equippedItem;

        if(item != null){
            foreach(CatModifier modifier in item.catModifiers)
                catManager.ApplyModifier(modifier);
            
            item.useItem();
            if(!item.isUsable())
                player.unequip();
            
        }

        

    }
    
    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;
        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;
        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }
}

/*
    public bool collidoConAgosto()
    {
        if (!Physics.CheckSphere(transform.position, sphereRadius, mask))
        {
            return true;
        }
        return false;
    }

}


 * agent.speed = 3.5f;
            idle = false;
            isWalking = true;
*/