using UnityEngine;
using System.Collections;

public class PressurePad : Switch {

    public float triggerValue = 10.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionStay(Collision c)
    {
        if (c.collider.tag=="Player")
        {
            if (c.gameObject.rigidbody.mass>triggerValue)
            {
                Fire();
            }
        }
    }
}
