using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    private Collider col;
    private MeshRenderer rend;

    private Transform player;

    void Start()
    {
        col = GetComponent<Collider>();
        rend = GetComponent<MeshRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Deactivate();
    }

    private void ReActivate()
    {
        float randomRespawnTime = UnityEngine.Random.Range(4f, 8f);
        Invoke("Activate", randomRespawnTime);
    }

    private void Activate()
    {
        col.enabled = true;
        rend.enabled = true;
        InvokeRepeating("Shoot", 1f, 1f);
    }

    public void Deactivate()
    {
        col.enabled = false;
        rend.enabled = false;
        CancelInvoke();

        ReActivate();
    }

    private void Shoot()
    {
        if (player != null)
        {
            Vector3 toPlayer = (player.position - transform.position).normalized;
            GameObject newBullet = Instantiate(bullet, transform.position + toPlayer, Quaternion.identity);
            newBullet.transform.forward = toPlayer;
        }
    }
}
