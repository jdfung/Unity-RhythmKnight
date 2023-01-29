using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer spriteRen;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public KeyCode keyToPress;
    

    // Start is called before the first frame update
    void Start()
    {
        spriteRen = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress)) 
        {
            spriteRen.sprite = pressedImage;
        }

        if(Input.GetKeyUp(keyToPress))
        {
            spriteRen.sprite = defaultImage;
        }
    }
}
