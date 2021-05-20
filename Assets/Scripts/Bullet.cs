using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        transform.position += transform.right * 0.15f;
    }
}
