using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

        //if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Wall")
        //{
        //    Destroy(gameObject, 5);
        //}
    }
    private void Update()
    {
        Destroy(gameObject, 5);
    }
}
