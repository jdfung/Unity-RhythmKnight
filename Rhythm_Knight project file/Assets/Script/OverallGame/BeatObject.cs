using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;
    public bool obtained = false;
    public GameObject hitEffect, missEffect;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;
            if(!obtained)
            {
                GameManager.instance.beatMiss();
                Instantiate(missEffect);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        {
            if(canBePressed)
            {
                GameManager.instance.beatHit();
                obtained = true;
                gameObject.SetActive(false);
                Instantiate(hitEffect);
            }
            else
            {
                obtained = false;
            }
        }
    }
}
