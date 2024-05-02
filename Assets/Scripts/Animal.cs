using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    // Start is called before the first frame update
    private bool walkVertical = true;
    private int verticalDir = 1;
    private int horizontalDir = 1;
    [SerializeField]
    private float speed = 1f;
    private float maxWalkTime = 2f;
    private float minWalkTime = 1f;
    private float walkingTime = 0f;

    //ENCAPSULATION
    protected float WalkingTime { get { return walkingTime; } set { walkingTime = value; } }
    protected SpawnManager spawnManager;
    private float timeRemain;
    //ENCAPSULATION
    protected float TimeRemain { get { return timeRemain; } set { timeRemain = value; } }
    private void Awake()
    {
        InvokeRepeating("Walk", 2f, 2f);
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (walkingTime > 0)
        {
            if (walkVertical)
            {
                transform.Translate(Vector3.forward * speed * verticalDir * Time.deltaTime);
            } else
            {
                transform.Translate(Vector3.right * speed * horizontalDir * Time.deltaTime);
            }
            walkingTime -= Time.deltaTime;
        }

        DestroyCheck();
    }

    public virtual void Walk()
    {
        RandomWalk();
    }

    public virtual void DestroyCheck()
    {
        BoundryCheck();
    }

    //ABSTRACTION
    protected void TimeAliveCheck()
    {
        if (timeRemain <= 0)
        {
            Destroy(gameObject);
        } else
        {
            timeRemain -= Time.deltaTime;
        }
    }

    //ABSTRACTION
    protected void BoundryCheck()
    {
        if (!spawnManager.ValideAnimalPosition(transform.position))
        {
            Destroy(gameObject);
        }
    }


    //ABSTRACTION
    public void RandomWalk()
    {
        walkingTime = Random.Range(minWalkTime, maxWalkTime);
        walkVertical = !walkVertical;
    }
    private void OnCollisionEnter(Collision collision)
    {
 
        if (collision.gameObject.CompareTag("Barrier"))
        {
            if (walkVertical)
            {
                verticalDir = -verticalDir;
            }
            else
            {
                horizontalDir = -horizontalDir;
            }
        } else
        {
            Debug.Log(collision.gameObject.name);
        }

    }
}
