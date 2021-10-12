using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat : MonoBehaviour
{
    public float Tempo;

    public bool Starttime;
    void Start()
    {
        Tempo = Tempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!Starttime)
        {
          /*  if(Input.anyKeyDown)
            {
                Starttime = true;
            } */
        }else
        {
            transform.position -= new Vector3(0f, Tempo * Time.deltaTime, 0f);
        }

    }
}
