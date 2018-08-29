using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMotion : MonoBehaviour {
    Vector3 pt,pi;
    public float r;
    float t;
	// Use this for initialization
	void Start () {
        t = 0;
        pi = this.transform.position;
        pt.z = pi.z + this.transform.position.z;
    }
	
	// Update is called once per frame
	void Update () {
        if (t < 2 * Mathf.PI)
        {
            t += Time.deltaTime;
            pt.x = pi.x + r * Mathf.Cos(t);
            pt.y = pi.y +r * Mathf.Sin(t);


            this.transform.LookAt(pt);
            this.transform.position = pt;
        }
        if (Input.GetKeyDown("r"))
        {
            t = 0;
        }
    }
}
