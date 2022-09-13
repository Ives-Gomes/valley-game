using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Skeleton : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float radius;
    [SerializeField] private LayerMask layer;
    [SerializeField] private float currentHealth;
    [SerializeField] private float totalHealth;
    [SerializeField] private Image healthBar;
    [SerializeField] private bool isDead;

    [Header("Components")]
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private AnimationControl animControl;

    private Player player;
    private bool detectPlayer;

    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public Image HealthBar { get => healthBar; set => healthBar = value; }
    public float TotalHealth { get => totalHealth; set => totalHealth = value; }
    public bool IsDead { get => isDead; set => isDead = value; }

    private void Start()
    {
        player = FindObjectOfType<Player>();

        agent.updateRotation = false;
        agent.updateUpAxis = false;

        currentHealth = TotalHealth;
    }

    private void Update()
    {
        if (!isDead && detectPlayer)
        {
            agent.isStopped = false;

            agent.SetDestination(player.transform.position);

            if (Vector2.Distance(transform.position, player.transform.position) <= agent.stoppingDistance)
            {
                animControl.PlayAnim(2);
            }
            else
            {
                animControl.PlayAnim(1);
            }

            float posX = player.transform.position.x - transform.position.x;

            if (posX > 0)
            {
                transform.eulerAngles = new Vector2(0, 0);
            }
            else
            {
                transform.eulerAngles = new Vector2(0, 180);
            }
        }
    }

    private void FixedUpdate()
    {
        DetectPalyer();
    }

    public void DetectPalyer()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, layer);

        if (hit != null)
        {
            detectPlayer = true;
        }
        else
        {
            detectPlayer = false;

            animControl.PlayAnim(0);

            agent.isStopped = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
