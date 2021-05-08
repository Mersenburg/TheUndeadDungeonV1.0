using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private Animator animS;
    public Animator anim;
    private BoxCollider2D boxS;
    
    private GameObject Spikes;
    public GameObject Spike;

    // Start is called before the first frame update
    void Start()
    {
        boxS = Spike.gameObject.GetComponent<BoxCollider2D>();
        animS = Spike.gameObject.GetComponent<Animator>();
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Crate")
        {
            animS.SetBool("SpikeOFF",true);
            anim.SetBool("ButtonON" ,true);
            boxS.enabled = false;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Crate")
        {
            animS.SetBool("SpikeOFF",false);
            anim.SetBool("ButtonON" ,false);
            boxS.enabled = true;
        }
    }
}
