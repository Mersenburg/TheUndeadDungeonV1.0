using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float Speed;
    public float Percepcao;
    public GameObject HealthBar; 
    public GameObject CoinsPrefab;
    public GameObject SoundDead;
    public GameObject SoundHit;
    public int MaxLife;
    public float CurrentLife;
    float DamageArrow = 1;
    private Transform Target;
    public Transform SpawnPoint;
    private Animator anim;
    private Rigidbody2D rig;
    private BoxCollider2D box;
    private float Stop = 0;
    //private float DamageArrowC;
    public static EnemyFollow instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        DamageArrow = PlayerPrefs.GetFloat("ArrowDamage", 1);
        anim = GetComponent<Animator>();
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Target != null)
        {
            HealthBar.transform.localScale = new Vector3 (CurrentLife * 5 / MaxLife, 0.64f, 1);
            ShowHealthBar(false);
            anim.SetBool("Run", false);
            if(Vector2.Distance(transform.position, Target.position) < (Percepcao))
            {
                anim.SetBool("Run", true);
                transform.position = Vector2.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
                ShowHealthBar(true);
                if(gameObject.layer == 10)
                {
                    Boss.IBoss.SpawnEnemy();
                }
            }
        }
    }
    public void Dead()
    {
        if(CurrentLife <= 0)
        {
            Percepcao = Stop;
            box.enabled = false;
            Destroy(gameObject, 0.5f);
            GameObject coins = Instantiate(CoinsPrefab, SpawnPoint.position, SpawnPoint.rotation);
        }
        GameObject Sound = Instantiate(SoundDead, transform.position, Quaternion.identity);
        Destroy(Sound, 0.5f);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Arrow")
        {
            GameObject Sound = Instantiate(SoundHit, transform.position, Quaternion.identity);
            Destroy(Sound, 0.5f);
            CurrentLife -= DamageArrow;
            if(CurrentLife <= 0)
            {
                anim.SetBool("Dead", true);
                Dead();
            }
        }
        if(gameObject.tag == "EnemyBomb")
        {
            CurrentLife = 1;
            MaxLife = 1;
            if(collision.gameObject.tag == "Player")
            {
                CurrentLife = CurrentLife - 1;
                if(CurrentLife <= 0)
                {
                    anim.SetBool("Dead", true);
                    Dead();
                }
            }
        }
    }
    public void ShowHealthBar(bool show)
    {
        HealthBar.SetActive(show);
    }
}