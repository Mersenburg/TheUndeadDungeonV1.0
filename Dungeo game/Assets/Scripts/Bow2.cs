using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow2 : MonoBehaviour
{
    public Camera cam;
    public Rigidbody2D rb;
    Vector2 mousePos;
    public Transform player;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
            {
                anim.SetTrigger("Shoot");
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
