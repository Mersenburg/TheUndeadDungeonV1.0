using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private BoxCollider2D boxColl;
    private Animator anim;
    public Transform SpawnPoint;
    public GameObject objPrefab;
    public GameObject SoundOpen;
    private bool opened = false;
    private bool Spawned = false;
    private float Timer = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        boxColl = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }
    public void Update()
    {
        if(Spawned == true)
        {
            Timer -= Time.deltaTime;
            if(Timer < 0)
            {
                GameObject obj = Instantiate(objPrefab, SpawnPoint.position, SpawnPoint.rotation);
                Spawned = false;
            }
        }
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 7 && opened == false)
        {
            GameController.instance.ShowImageF();
            if(Input.GetKeyDown(KeyCode.F))
            {
                GameObject Sound = Instantiate(SoundOpen, transform.position, Quaternion.identity);
                Destroy(Sound, 1f);
                opened = true;
                Spawned = true;
                anim.SetTrigger("Open");
                GameController.instance.ShowImageF();
            }  
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 7)
        {
            GameController.instance.unShowImageF();
        }
    }
}
