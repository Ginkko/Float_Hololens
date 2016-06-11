using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class FauxGravityBody : MonoBehaviour {

	public FauxGravityAttractor attractor;
	private Transform myTransform;
    private Rigidbody myRigidBody;

    public float thrust;

	void Start () {
        myRigidBody = GetComponent<Rigidbody>();
		GetComponent<Rigidbody>().useGravity = false;
		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

		myTransform = transform;
        myRigidBody.AddForce(Vector3.up * .2f, ForceMode.Impulse);
	}

	void FixedUpdate () {

        //myRigidBody.AddForce(transform.forward * thrust);

		if (attractor){
			attractor.Attract(myTransform);
		}
	}
	
}
