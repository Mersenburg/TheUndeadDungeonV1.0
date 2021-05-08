using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject HitEffect;
    public GameObject sound;

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject Effect = Instantiate(HitEffect, transform.position, Quaternion.identity);
        GameObject Sound = Instantiate(sound, transform.position, Quaternion.identity);
        Destroy(Effect, 0.3f);
        Destroy(Sound, 0.3f);
        Destroy(gameObject);
    }
}