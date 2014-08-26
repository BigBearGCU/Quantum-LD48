using UnityEngine;
using System.Collections;

public class PressurePad : Switch {

    public float triggerValue = 10.0f;

    public Color orginalColour;
    public Color triggerColour;
	// Use this for initialization
	void Start () {
        orginalColour = renderer.material.color;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider c)
    {
        if (c.tag=="Player")
        {
            renderer.material.color = Color.Lerp(orginalColour, triggerColour, c.gameObject.rigidbody.mass / triggerValue);
            if (c.gameObject.rigidbody.mass>triggerValue)
            {
                renderer.material.color = triggerColour;
                Fire();
            }
        }
    }
}
