using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDetect : MonoBehaviour
{
    public bool isPressed;

    public KeyCode keyToPress;

    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(keyToPress))
        {
            if(isPressed)
            {
                gameObject.SetActive(false);

                //Manager.instance.NoteHit();

                if(Mathf.Abs( transform.position.y) > 0.25)
                {
                    Debug.Log("Hit");
                    Manager.instance.NormalHit();
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);

                } else if (Mathf.Abs(transform.position.y) > 0.05f)
                {
                    Debug.Log("Good");
                    Manager.instance.GoodHit();
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                } else
                {
                    Debug.Log("Perfect");
                    Manager.instance.PerfectHit();
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                }
                        
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            isPressed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            isPressed = false;

            Manager.instance.NoteMiss();
            Instantiate(missEffect, transform.position, missEffect.transform.rotation);
        }
    }
}
