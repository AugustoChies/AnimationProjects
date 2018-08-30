using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierMotion : MonoBehaviour {
    Vector3 pt;
    public Transform [] points;
    public float speed = 1;
    public float pointsize;
    public bool endbreak,accelerate;
    public float t;
    short current;
	// Use this for initialization
	void Start () {
        t = 0;
        current = 0;       
    }
	
	// Update is called once per frame
	void Update () {
        if (t < 1.0f)
        {
            if (endbreak)
            {                
                t += (Time.deltaTime * speed) * (1.1f - t);                
            }
            else if (accelerate)
            {
                t += (Time.deltaTime * speed) * (t + 0.3f);
            }
            else
            {
                t += Time.deltaTime * speed;
            }
            //tentativa para usar mais de 4 pontos,não funcionou direito
            if (t> 0.33 && pointsize - current > 4)
            {
                t = 0;
                current++;
            }
            /////////////////////
            pt.x = Mathf.Pow(1 - t, 3) * points[current].position.x + 3 * t * Mathf.Pow(1 - t, 2) * points[current + 1].position.x + 3 * Mathf.Pow(t, 2) * (1 - t) * points[current + 2].position.x + Mathf.Pow(t, 3) * points[current + 3].position.x;
            pt.y = Mathf.Pow(1 - t, 3) * points[current].position.y + 3 * t * Mathf.Pow(1 - t, 2) * points[current + 1].position.y + 3 * Mathf.Pow(t, 2) * (1 - t) * points[current + 2].position.y + Mathf.Pow(t, 3) * points[current + 3].position.y;
            pt.z = Mathf.Pow(1 - t, 3) * points[current].position.z + 3 * t * Mathf.Pow(1 - t, 2) * points[current + 1].position.z + 3 * Mathf.Pow(t, 2) * (1 - t) * points[current + 2].position.z + Mathf.Pow(t, 3) * points[current + 3].position.z;

            this.transform.LookAt(pt);
            this.transform.position = pt;
        }
        if (Input.GetKeyDown("r"))
        {
            t = 0;
            current = 0;
        }
    }
}
