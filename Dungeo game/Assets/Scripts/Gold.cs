using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D circle;    
    public GameObject Collected;
    public GameObject SoundCoin;
    //public int Score;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            sr.enabled = false;
            circle.enabled = false;
            Collected.SetActive(true);

            Store.instance.UpdateScoreText();
            GameObject Sound = Instantiate(SoundCoin, transform.position, Quaternion.identity);

            Destroy(Sound, 0.5f);
            Destroy(gameObject, 0.25f);
        }
    }
}
