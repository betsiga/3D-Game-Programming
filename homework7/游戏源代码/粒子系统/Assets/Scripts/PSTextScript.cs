using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSTextScript : MonoBehaviour {

    public float starRadius;
    ParticleSystem star;
    
    // Use this for initialization
    void Start () {
        starRadius = 0.73f;
        star = GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {
        if (star.shape.radius != starRadius)
        {
            star.Stop();
            var shape = star.shape;
            shape.radius = starRadius;
            star.Play();
        } 
	}
}
