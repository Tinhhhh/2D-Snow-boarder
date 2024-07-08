using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMagnet : MonoBehaviour
{
    public float CoinSpeed;

    public Transform player;
    private bool ReadyToMove;

    // Update is called once per frame
   
    void Update()

    {
        if (ReadyToMove == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, CoinSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ReadyToMove = true;
            player = GameObject.FindWithTag("Player").transform;
        }
    }
}
