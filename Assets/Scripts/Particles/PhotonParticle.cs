using UnityEngine;
using System.Collections;

public class PhotonParticle : FundamentalParticleBehaviour
{
    public float repulseAmount = 10.0f;
    public float distance = 0.2f;
    public bool grounded = false;
    

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        
	}


    public override void Apply()
    {
        Ray groundRay = new Ray(transform.position, Vector3.down);
        grounded = Physics.Raycast(groundRay, transform.localScale.y + distance);
        if (enabled && grounded)
        {
            rigidbody.AddForce(Vector3.up * repulseAmount);
        }
    }
}
