using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    public float Speed;   
    [SerializeField]
    public int MaxLife;
    [SerializeField]
    public int CurrentLife;
    [SerializeField]
    private HealtBar healtBar;
    private Animator anim;
    private Rigidbody2D rig;
    public static Player instance;
    float RunS;
    float Run;
    // Start is called before the first frame update
    void Start()
    {
        Speed = PlayerPrefs.GetFloat("Speed", 5);
        RunS = PlayerPrefs.GetFloat("Run", 7);
        instance = this;
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        MaxLife = PlayerPrefs.GetInt("MaxLife", 5);
        CurrentLife = PlayerPrefs.GetInt("CurrentLife", 5);
    }
    // Update is called once per frame
    void Update()
    {
        Dead();
        Move();
        UpdateHealthBarUI();
    }
    void Move()
    {
        float movementx = Input.GetAxis("Horizontal");
        float movementy = Input.GetAxis("Vertical");
        //Run
        if(Input.GetKey(KeyCode.LeftShift))
        {
            rig.velocity = new Vector2(movementx * RunS, movementy * RunS);
        }
        //Walk
        else
        {
            rig.velocity = new Vector2(movementx * Speed, movementy * Speed);
        }
        //Animator
        Vector3 movement = new Vector3(movementx, movementy, 0f);
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.magnitude);   
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "EnemyBomb")
        {
            CurrentLife -= 1;
        }
        if(collision.gameObject.tag == "Enemy")
        {
            CurrentLife -= 3;
        }
        if(collision.gameObject.tag == "EnemyBig")
        {
            CurrentLife -= CurrentLife;
        }
        if(collision.gameObject.tag == "Spike")
        {
            CurrentLife -= CurrentLife;
        }
    }
    public void UpdateHealthBarUI()
    {
        healtBar.UpdateHealtPlayer(CurrentLife, MaxLife);
        PlayerPrefs.SetInt("CurrentLife", CurrentLife);
        PlayerPrefs.SetInt("MaxLife", MaxLife);
    }
    public void Dead()
    {
        if(CurrentLife <= 0)
        {
            Destroy(gameObject);
            Time.timeScale = 0;
            GameController.instance.ShowDead();
            CurrentLife = 5; 
            MaxLife = 5;  
        }
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "NextLevel")
        {
            Time.timeScale = 0;
            GameController.instance.ShowNextLevel(); 
        }
        if(collider.gameObject.tag == "FinalLevel")
        {
            Time.timeScale = 0;
            GameController.instance.FinalLevel(); 
        }
    }

}

