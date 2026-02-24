using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
    public float lifeTime = 10f;
    public float destroyDelay = 1f;
    public int damageToDeal = 1;

    [Header("Effects")]
    public ParticleSystem explosionParticles;

    Transform player;
    float randomSpeed;
    bool isDead = false;

    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        int tempDamageToDeal = damageToDeal;
        damageToDeal = Random.Range(tempDamageToDeal, tempDamageToDeal + 1);

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }

        randomSpeed = Random.Range(20f, 27f);
        agent.speed = randomSpeed;

        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        if (player == null || isDead) return;

        agent.SetDestination(player.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isDead) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            isDead = true;

            agent.enabled = false;

            if (GameManager.instance != null)
            {
                GameManager.instance.TakeDamage(damageToDeal);
            }

            if (explosionParticles != null)
            {
                explosionParticles.Play();
            }

            MeshRenderer renderer = GetComponent<MeshRenderer>();
            if (renderer != null)
            {
                renderer.enabled = false;
            }

            Collider collider = GetComponent<Collider>();
            if (collider != null)
            {
                collider.enabled = false;
            }

            Destroy(gameObject, destroyDelay);
        }
    }
}