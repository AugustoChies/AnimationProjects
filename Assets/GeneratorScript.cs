using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorScript : MonoBehaviour {
    public EmissionType emission;
    public float radius; //Only used on circle and sphere emission

    public TrajectoryType trajectory;
    public Vector3 direction;//direction of movement if particle moves in a line, a positive or negative x value will define the direction and radius if the trajectory is an arc or circle
    public bool randomDirection;//ignores previous value and defines direction randomly
    public float arcradius;//arc or circle radius
    public float lifetime;
    public Color startingColor;
    public Color endingColor;
    public Vector3 startingScale;
    public Vector3 endingScale;
    public bool rotate;
    public float rotationspeed; //only if rotation is active        
    public float movespeed; //only influences line moving speed

    public GameObject particlePrefab;
    public float currentparticles;
    public float maxparticles;
    public float emissionrate;//time between each particle emission

    float emittimer;
	// Use this for initialization
	void Start () {
        emittimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        emittimer += Time.deltaTime;
        if(emittimer >= emissionrate && currentparticles < maxparticles)
        {
            GameObject newparticle;
            currentparticles++;
            emittimer = 0;

            Vector3 spawnposition = this.transform.position;
            switch (emission)
            {               
                case EmissionType.circle:
                    float randx = Random.Range(-1f, 1f);
                    float randz = Random.Range(-1f, 1f);
                    Vector3 randsvec = new Vector3(randx, 0, randz);
                    randsvec = randsvec.normalized;
                    randsvec = randsvec * radius;
                    spawnposition += randsvec;
                    break;
                case EmissionType.sphere:
                    float randsx = Random.Range(-1f, 1f);
                    float randsy = Random.Range(-1f, 1f);
                    float randsz = Random.Range(-1f, 1f);
                    Vector3 randssvec = new Vector3(randsx, randsy, randsz);
                    randssvec = randssvec.normalized;
                    randsvec = randssvec * radius;
                    spawnposition += randssvec;
                    break;
                default:
                    break;
            }

            newparticle = Instantiate(particlePrefab, spawnposition, Quaternion.identity, this.transform);
            newparticle.GetComponent<ParticleScript>().trajectory = trajectory;

            if (randomDirection)
            {
                direction.x = Random.Range(-1f, 1f);
                direction.y = Random.Range(-1f, 1f);
                direction.z = Random.Range(-1f, 1f);
            }
            if(trajectory == TrajectoryType.line)
                direction = direction.normalized;
            newparticle.GetComponent<ParticleScript>().direction = direction;
            newparticle.GetComponent<ParticleScript>().lifetime = lifetime;
            newparticle.GetComponent<ParticleScript>().startingColor = startingColor;
            newparticle.GetComponent<ParticleScript>().endingColor = endingColor;
            newparticle.GetComponent<ParticleScript>().startingScale = startingScale;
            newparticle.GetComponent<ParticleScript>().endingScale = endingScale;
            newparticle.GetComponent<ParticleScript>().rotate = rotate;
            newparticle.GetComponent<ParticleScript>().rotationspeed = rotationspeed;
            newparticle.GetComponent<ParticleScript>().movespeed = movespeed;
            newparticle.GetComponent<ParticleScript>().initialized = true;
        }
	}
}
