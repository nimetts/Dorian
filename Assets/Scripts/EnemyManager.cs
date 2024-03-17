using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{ public PlayerScript playerScript;
    public Slider slider;
    public float health;
    private bool playerCollider = false;
    public float damage;
    public GameObject playerGameObject;
    // Start is called before the first frame update
    void Start()
    {
        playerGameObject = GameObject.Find("Player");
        slider.maxValue = health;
        slider.value = health;
        playerScript = playerGameObject.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !playerCollider)
        {
            playerCollider = true;
            other.GetComponent<PlayerScript>().getDamage(damage);
        }
        else if (other.tag == "Bullet")
        {
            getDamage(other.GetComponent<BulletManager>().bulletDamage);
            Destroy(other.gameObject);
        }
    }
    public void getDamage(float damage)
    {
        if (health - damage >= 0)
        {
            health -= damage;
            slider.value = health;
        }
        else
        {
            health = 0;
        }
    }

    void isDead()
    {
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerCollider = false;
        }
    }
}

