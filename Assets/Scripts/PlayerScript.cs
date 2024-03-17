using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public bool dead = false;
    public float health;
    public float bulletSpeed;
    public Transform Bullet, Muzzle, damageText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bulletShoot();
        }
    }

    public void getDamage(float damage)
    {
        Instantiate(damageText, transform.position, Quaternion.identity).GetComponent<TextMesh>().text=damage.ToString();
        if (health - damage >= 0)
        {
            health -= damage;
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
            dead = true;
        }
    }

   public void bulletShoot()
    {
        Transform tempBullet;
        tempBullet = Instantiate(Bullet, Muzzle.position, Quaternion.identity);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(Muzzle.forward * bulletSpeed);
    }
}
