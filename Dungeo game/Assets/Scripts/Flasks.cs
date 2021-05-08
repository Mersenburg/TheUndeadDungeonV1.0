using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flasks : MonoBehaviour
{
    private SpriteRenderer sr;
    private BoxCollider2D box;    
    public GameObject Collected;
     public GameObject SoundConsume;
    public static Flasks instance;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    
        void OnTriggerEnter2D(Collider2D collider)
    {
        if(gameObject.tag == "Flask")
        {
            if(Player.instance.CurrentLife == Player.instance.MaxLife)
            {
              GameController.instance.ShowImageFullLife();
            }
            else if(collider.gameObject.tag == "Player")
            {
                sr.enabled = false;
                box.enabled = false;
                Collected.SetActive(true);
                Player.instance.CurrentLife += 1;
                Destroy(gameObject, 1);
                GameObject Sound = Instantiate(SoundConsume, transform.position, Quaternion.identity);
                Destroy(Sound, 1f);
            }
        }
        if(gameObject.tag == "FlaskBig")
        {
            if(collider.gameObject.tag == "Player")
            {
                if(Player.instance.MaxLife == 10)
                {
                    GameController.instance.ShowImageMaxLife();
                }
                else
                {
                    sr.enabled = false;
                    box.enabled = false;
                    Collected.SetActive(true);
                    Player.instance.CurrentLife += 1;
                    Player.instance.MaxLife += 1;
                    Destroy(gameObject, 1);
                    GameObject Sound = Instantiate(SoundConsume, transform.position, Quaternion.identity);
                    Destroy(Sound, 2f);
                }
            }
        }    
    } 
    void OnTriggerExit2D(Collider2D collider)   
    {
        GameController.instance.unShowImageFullLife();
        GameController.instance.unShowImageMaxLife();
    }
}
