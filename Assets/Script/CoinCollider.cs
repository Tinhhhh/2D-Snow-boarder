using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollider : MonoBehaviour
{
//    [SerializeField] private int value;
    public GameObject parent;
    //private bool hasTriggered;
    //private CoinManager coinManager;
    // Start is called before the first frame update
    //private void Start()
    //{
    //    //Lay gia tri hien tai 
    //    coinManager = CoinManager.instance;

    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player") && !hasTriggered)
    //    {
    //        hasTriggered = true;
    //        coinManager.ChangeCoins(value);
    //        Destroy(gameObject);
    //    }
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {

          
            Destroy(parent);

        }

    }
}
