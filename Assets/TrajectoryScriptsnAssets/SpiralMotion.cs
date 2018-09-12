using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralMotion : MonoBehaviour {
    Vector3 pt,pc,a,b; 
    public Transform pi, pl, pe;
    public float r,speed;
    float t;
    short stage;
    // Use this for initialization
    void Start()
    {
        t = 0;
        stage = 1;
        pc = pl.position + new Vector3(0, r, 0);

        a.x = pl.position.x - pi.position.x;
        a.y = pl.position.y - pi.position.y;
        a.z = pl.position.z - pi.position.z;

        b.x = pe.position.x - pl.position.x;
        b.y = pe.position.y - pl.position.y;
        b.z = pe.position.z - pl.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        switch (stage)
        {
            case 1:
                if (t < 1.0f)
                {
                    t += Time.deltaTime;
                    if (t > 1)
                        t = 1;
                    pt.x = pi.position.x + a.x * t;
                    pt.y = pi.position.y + a.y * t;
                    pt.z = pi.position.z + a.z * t;

                    this.transform.LookAt(pt);
                    this.transform.position = pt;
                }
                else
                {
                    t = 0;
                    stage = 2;
                }
                break;
            case 2:
                if (t < 2 * Mathf.PI)
                {
                    t += Time.deltaTime * speed;
                    pt.x = pc.x + r * Mathf.Cos(t - Mathf.PI / 2);
                    pt.y = pc.y + r * Mathf.Sin(t - Mathf.PI / 2);


                    this.transform.LookAt(pt);
                    this.transform.position = pt;
                }
                else
                {
                    t = 0;
                    stage = 3;
                }
                break;
            case 3:
                if (t < 1.0f)
                {
                    t += Time.deltaTime;
                    if (t > 1)
                        t = 1;
                    pt.x = pl.position.x + b.x * t;
                    pt.y = pl.position.y + b.y * t;
                    pt.z = pl.position.z + b.z * t;

                    this.transform.LookAt(pt);
                    this.transform.position = pt;
                }
                break;
            default:
                break;
        }
        
        if (Input.GetKeyDown("r"))
        {
            this.transform.position = pi.position;
            t = 0;
            stage = 1;
        }
    }
}
