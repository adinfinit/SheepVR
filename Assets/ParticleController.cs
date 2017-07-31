using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour {

    public GameObject RightHand;
    public GameObject ParticleContainer;

	void Start () {
		
	}
	
	void Update () {
        ParticleSystem particles = ParticleContainer.GetComponent<ParticleSystem>();
        ParticleSystem.ShapeModule shape = particles.shape;

        shape.position = RightHand.transform.position;
        shape.rotation = RightHand.transform.rotation.eulerAngles;
    }
}
