using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 direction = Vector3.right;
    private float speed = 1f;
    private float lifetime = 10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction *speed *Time.deltaTime;
        lifetime-= Time.deltaTime;
        if ( lifetime < 0) { Destroy(gameObject); }
    }

    public void setDirection(Vector3 target) {
        direction = (target - transform.position).normalized;
    }
}
