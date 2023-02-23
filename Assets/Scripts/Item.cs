using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    Rigidbody2D R;

    public GameObject player;

    void Start()
    {
        R = GetComponent<Rigidbody2D>();
        R.gravityScale = 0.2F;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
    }

    public void Move()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("아이템터치");
            if (this.gameObject.tag == "PowerItem")
            {
                Player P = player.GetComponent<Player>();
                P.power += 1;
                if (P.power > 3) P.power = 3;
                Destroy(gameObject);
            }

            if (this.gameObject.tag == "CoinItem")
            {
                GameManager.instance.gameScore += 777;
                Destroy(gameObject);
            }

            if (this.gameObject.tag == "BoomItem")
            {
                GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
                Debug.Log(enemys[0]);
                for (int i = 0; i < enemys.Length; i++)
                {
                    Destroy(enemys[i]);
                    }

                Destroy(gameObject);
            }

        }
        if (collision.gameObject.tag == "Border")
        {
            Destroy(gameObject);
        }
    }

   
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (this.gameObject.name == "Power")
            {
                Player P = player.GetComponent<Player>();
                P.power += 1;
                if (P.power > 3) P.power = 3;
                Destroy(this);
            }

            if (this.gameObject.name == "Coin")
            {
                GameManager.instance.gameScore += 777;
                Destroy(this);
            }
        }
    }
    */

}
