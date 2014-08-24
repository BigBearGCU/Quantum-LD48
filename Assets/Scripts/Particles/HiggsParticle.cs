using UnityEngine;
using System.Collections;

public class HiggsParticle : FundamentalParticleBehaviour
{

    public float orginalMass=1.0f;
    public float updateMassAmount = 1.0f;

	// Use this for initialization
	void Start () {
	    orginalMass=rigidbody.mass;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void Disable()
    {
        rigidbody.mass = orginalMass;
    }

    public override void Apply()
    {
        if(enabled)
        {
            rigidbody.mass += updateMassAmount*Time.deltaTime;
        }
    }
}
