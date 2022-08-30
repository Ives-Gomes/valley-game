using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private float treeHealth;
    [SerializeField] private Animator anim;

    [SerializeField] private GameObject woodPrefab;
    [SerializeField] private int totalWood;

    [SerializeField] private ParticleSystem leafs; 

    private bool isCut;

    public void OnHit()
    {
        treeHealth--;

        anim.SetTrigger("isHit");
        leafs.Play();

        if (treeHealth <= 0)
        {
            for (int i = 0; i < totalWood; i++)
            { 
                float randomPositionX = Random.Range(-1f, 1f);
                float randomPositionY = Random.Range(-1f, 1f);

                Vector3 randomPosition = new Vector3(randomPositionX, randomPositionY, 0);

                Instantiate(woodPrefab, transform.position + randomPosition, transform.rotation);
            }

            anim.SetTrigger("cut");

            isCut = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Axe") && !isCut)
        {
            OnHit();
        }
    }
}
