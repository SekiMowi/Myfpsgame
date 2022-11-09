using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyManager : MonoBehaviour
{
    //Variables

    public int health = 100;
    public int damage = 15;
    public float atkDistance = 1f;
    public float maxFollowDistance = 10f;

    public Transform player;
    public NavMeshAgent enemy;
    public Animator m_anim;
    public Collider enemyCollider;
    public Collider headCollider;
    // Start is called before the first frame update
    void Start()
    {
        //Getting players transform
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //If enemy isnt dead and player is within maxFollowDistance range, Start following the player
        if(Vector3.Distance(transform.position, player.transform.position) <= maxFollowDistance && health > 0)
        {   
            m_anim.SetBool("isMoving", true);
            enemy.SetDestination(player.position);
        }
        else
            m_anim.SetBool("isMoving", false);
        //if enemmy is within atkDistance range, stop following player
        if (Vector3.Distance(transform.position, player.transform.position) <= atkDistance)
        {
            m_anim.SetBool("isClose", true);
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
        }
        else
            m_anim.SetBool("isClose", false);
            gameObject.GetComponent<NavMeshAgent>().enabled = true;
        
    
    }
    //Gizmos for the enemy
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, maxFollowDistance);
        Gizmos.DrawWireSphere(transform.position, atkDistance);
    }
    //Function to take damage. if enemys health goes 0 or less call Dead function
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Dead();
        }
    }
    //Function to add 1 kill to kill manager, stop enemys animations, collider, navmeshagent and destroy it whenever called 
    void Dead()
    {
        KillManager.kills++;
        m_anim.SetBool("isDead", true);
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
        enemyCollider.enabled = false;
        headCollider.enabled = false;
        Destroy(gameObject,3f);
    }
    //if enemy hits player, call PlayerManagers TakeDamage function
    public void OnTriggerEnter(Collider other)
    {
        PlayerManager playerManager = other.gameObject.GetComponent<PlayerManager>();
        if(playerManager != null)
            playerManager.TakeDamage(damage);
    }
}
