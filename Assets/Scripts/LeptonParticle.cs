using UnityEngine;
using System.Collections;

public class LeptonParticle : MonoBehaviour,FundamentalParticle{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnEnable()
    {
        Enable();
    }

    public void OnDisable()
    {
        Disable();
    }

    public void Enable()
    {
        collider.enabled = true;
    }

    public void Disable()
    {
        collider.enabled = false;
    }
}
