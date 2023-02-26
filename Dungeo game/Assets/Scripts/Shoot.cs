using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject ArrowPrefab;
    public Text Loading;
    public float ArrowForce = 0.01f;
    public float Timer = 1f;
    public int arrows;
    // Update is called once per frame
    void Start()
    {

    }
    void Update()
    {
        Timer -= Time.deltaTime;
        arrows = PlayerPrefs.GetInt("Arrows", 100);
        if (Input.GetButtonDown("Fire1") & arrows > 0)
        {
            Shooting();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shooting();
        }
        if (Timer <= 0)
        {
            Loading.text = ("Shoot");
        }
        if (Timer >= 0)
        {
            Loading.text = ("Loading");
        }
    }
    void Shooting()
    {
        if (Timer <= 0)
        {
            GameObject Arrow = Instantiate(ArrowPrefab, FirePoint.position, FirePoint.rotation);
            Timer = 1;
            arrows--;
            PlayerPrefs.SetInt("Arrows", arrows);
            Rigidbody2D rb = Arrow.GetComponent<Rigidbody2D>();
            rb.AddForce(FirePoint.up * ArrowForce, ForceMode2D.Impulse);
        }
    }
}

