using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour {
    public TrajectoryType trajectory;
    public Vector3 direction;
    public float lifetime;
    public Color startingColor;
    public Color endingColor;
    public Vector3 startingScale;
    public Vector3 endingScale;
    public bool rotate;
    public float rotationspeed; //only if rotation is active    
    public float movespeed;

    public bool initialized;//particle has been configured by generator, false by default 

    public float currentlifetime;
    Vector3 arcCenterPoint;
    public GameObject mygenerator;

    // Use this for initialization
    void Start () {
        currentlifetime = 0;
        arcCenterPoint = this.gameObject.transform.position + new Vector3(direction.x,0,0);
        mygenerator = this.transform.parent.gameObject;

    }
	
	// Update is called once per frame
	void Update () {
		if(initialized)
        {
            currentlifetime += Time.deltaTime;
            switch (trajectory)
            {
                case TrajectoryType.line:
                    this.gameObject.transform.position += direction * movespeed * Time.deltaTime;
                    break;
                case TrajectoryType.arc:
                    if ((currentlifetime/lifetime)* Mathf.PI < Mathf.PI)
                    {
                        Vector3 pt;
                        if(direction.x < 0)
                            pt.x = arcCenterPoint.x + Mathf.Abs(direction.x) * Mathf.Cos((currentlifetime / lifetime) * Mathf.PI);
                        else
                            pt.x = arcCenterPoint.x + Mathf.Abs(direction.x) * (Mathf.Cos((currentlifetime / lifetime) * Mathf.PI) * -1);
                        pt.y = arcCenterPoint.y + Mathf.Abs(direction.x) * Mathf.Sin((currentlifetime / lifetime) * Mathf.PI);
                        pt.z = this.transform.position.z;
                        this.transform.position = pt;
                    }
                    break;
                case TrajectoryType.circle:
                    if ((currentlifetime / lifetime) * Mathf.PI * 2 < Mathf.PI * 2)
                    {
                        Vector3 pt;
                        if (direction.x < 0)
                            pt.x = arcCenterPoint.x + Mathf.Abs(direction.x) * Mathf.Cos((currentlifetime / lifetime) * Mathf.PI * 2);
                        else
                            pt.x = arcCenterPoint.x + Mathf.Abs(direction.x) * (Mathf.Cos((currentlifetime / lifetime) * Mathf.PI * 2) * -1);
                        pt.y = arcCenterPoint.y + Mathf.Abs(direction.x) * Mathf.Sin((currentlifetime / lifetime) * Mathf.PI * 2);
                        pt.z = this.transform.position.z;
                        this.transform.position = pt;
                    }
                    break;
                default:
                    break;
            }

            this.gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(startingColor, endingColor, (currentlifetime / lifetime));
            this.gameObject.transform.localScale = Vector3.Lerp(startingScale, endingScale, (currentlifetime / lifetime));

            if(rotate)
            {
                if(direction.x > 0)
                {
                    this.transform.Rotate(0,0,-1 * rotationspeed * Time.deltaTime);
                }
                else
                {
                    this.transform.Rotate(0,0,rotationspeed * Time.deltaTime);
                }
            }


            if(currentlifetime >= lifetime)
            {
                mygenerator.GetComponent<GeneratorScript>().currentparticles -= 1;
                Destroy(this.gameObject);
            }
        }
	}
}
