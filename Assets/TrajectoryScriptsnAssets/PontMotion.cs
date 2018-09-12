using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PontMotion : MonoBehaviour {
    public Transform pi, pf;
    Vector3 pt,a;
    float t;
	// Use this for initialization
	void Start () {
        this.transform.position = pi.position;
        t = 0;
        a.x = pf.position.x - pi.position.x;
        a.y = pf.position.y - pi.position.y;
        a.z = pf.position.z - pi.position.z;
    }
	
	// Update is called once per frame
	void Update () {
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
        if (Input.GetKeyDown("r"))
        {
            t = 0;
        }
    }
}
