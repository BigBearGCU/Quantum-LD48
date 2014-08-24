using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float Speed = 1.0f;
    public Animation mainAnimation;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        rigidbody.angularVelocity = Vector3.back * Speed*Input.GetAxis("Horizontal");
	}
}
