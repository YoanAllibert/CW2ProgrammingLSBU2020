using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private bool isEnemyBullet = false;
    [SerializeField] private float bulletSpeed = 8f;

    private PlayerController player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        Destroy(this.gameObject, 8f);
    }

    void Update()
    {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player") && isEnemyBullet)
        {
            if (player != null)
                player.LoseOneLife();
            
            Destroy(gameObject);
        }
        else if (!other.CompareTag("Player"))
        {
            other.GetComponent<Enemy>().Deactivate();
            Destroy(gameObject);
        }
    }
}