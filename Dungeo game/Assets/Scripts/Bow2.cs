using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow2 : MonoBehaviour
{
    public Camera cam;
    public int arrows;
    public Rigidbody2D rb;
    public float Timer = 0.5f;
    Vector2 mousePos;
    public Transform player;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        arrows = PlayerPrefs.GetInt("Arrows");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Timer);
        Timer -= Time.deltaTime;
        arrows = PlayerPrefs.GetInt("Arrows");
        if(Input.GetButtonDown("Fire1") & arrows > 0)
            {
                if(Timer<=0)
                {
                    anim.SetTrigger("Shoot");
                    arrows--;
                    Timer = 0.5f;
                }
            }
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 0.6f, transform.position.z);
    }
    void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y ,lookDir.x) * Mathf.Rad2Deg ;
        rb.rotation = angle;
    }
}
