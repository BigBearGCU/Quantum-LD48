using UnityEngine;
using System.Collections;

public class LeptonParticle : FundamentalParticleBehaviour
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void Enable()
    {
        collider.enabled = false;
    }

    public override void Disable()
    {
        collider.enabled = true ;
    }

    public override void Apply()
    {
    }
}
