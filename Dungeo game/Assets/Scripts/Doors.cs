using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    private BoxCollider2D boxColl;
    private Animator anim;
    //public Transform SpawnPoint;
    public GameObject Door;
    private bool opened;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 7 && opened == false)
        {
            GameController.instance.ShowImageF();
            if(Input.GetKeyDown(KeyCode.F))
            {  
                Door.SetActive(false);
                opened = true;
                anim.SetBool("Close", true);
                anim.SetBool("Open", false);
                GameController.instance.unShowImageF();
            }
        }
        if (collider.gameObject.layer == 7 && opened == true)
        {
            GameController.instance.ShowImageE();
            if(Input.GetKeyDown(KeyCode.E))
            {  
                Door.SetActive(true);
                opened = false;
                anim.SetBool("Open", true);
                anim.SetBool("Close", false);
                GameController.instance.unShowImageE();
            }
        }
    }
     
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 7)
        {
            GameController.instance.unShowImageF();
            GameController.instance.unShowImageE();
        }
    }
}
