using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    private bool attach;
    private Transform Target;
    public float Speed;
    public float Percepcao = 5;
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();   
    }

    // Update is called once per frame
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 7 && attach == false)
        {
            GameController.instance.ShowImageF();
            if(Input.GetKey(KeyCode.F))
            {  
               if(Vector2.Distance(transform.position, Target.position) < (Percepcao))
               {
               transform.position = Vector2.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
               }
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
