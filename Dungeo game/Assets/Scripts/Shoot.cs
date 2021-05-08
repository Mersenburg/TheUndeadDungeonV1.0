using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject ArrowPrefab;
    public float ArrowForce = 0.01f;
    // Update is called once per frame
    void Update()
    {   
            if(Input.GetButtonDown("Fire1"))
            {
                Shooting ();
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Shooting ();
            }
        
    }
    void Shooting()
    {
       GameObject Arrow = Instantiate(ArrowPrefab, FirePoint.position, FirePoint.rotation);
       Rigidbody2D rb = Arrow.GetComponent<Rigidbody2D>();
       rb.AddForce(FirePoint.up * ArrowForce, ForceMode2D.Impulse);
    }
}

