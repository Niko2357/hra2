using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    NavMeshAgent agent;
    public Transform[] waypoints;
    public float followDistance = 10f;
    public float returnDistance = 15f;
    public int currentWaypoint = 0;
    Vector3 spawnpoint = new Vector3(8, 2, -18);
    GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindAnyObjectByType<GameManager>();
        agent = GetComponent<NavMeshAgent>();
        if(waypoints.Length > 0)
        {
            agent.SetDestination(waypoints[currentWaypoint].position);
        }
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Neexistuje");
        }
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
        
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer < followDistance)
        {
            agent.SetDestination(player.transform.position); 
        }
        else if (distanceToPlayer >= returnDistance)
        {
            Patrol();
        }
        
    }

    void Patrol()
    {
        if(agent.remainingDistance < agent.stoppingDistance + 1)
        {
            currentWaypoint = (currentWaypoint +1) % waypoints.Length;
        }
        agent.SetDestination(waypoints[currentWaypoint].position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = spawnpoint;
            player.GetComponent<CharacterController>().enabled = true;
            manager.score -= 10;
            manager.scoreText.text = manager.scoreText.ToString();
        }
    }
}
