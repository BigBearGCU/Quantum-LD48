using UnityEngine;
using System.Collections;

public class QuarkParticle :FundamentalParticle {

    public float range = 10.0f;
    RaycastHit hitInfo = new RaycastHit();
    public GameObject owner;

    public void Enable()
    {
        
    }

    public void Disable()
    {
        
    }


    public void Apply()
    {
        //do a spehere cast, find objects that attriable and pull towards(think tractor beam)
        if (Physics.SphereCast(owner.transform.position, range, owner.transform.forward, out hitInfo))
        {
            //lets grab collider collider 
            Collider c = hitInfo.collider;
            if (c.tag=="Attractable")
            {
                Vector3 direction = (owner.transform.position-c.transform.position);
                float magnitude = direction.magnitude;
                direction.Normalize();
                c.gameObject.rigidbody.AddForce(direction * magnitude);
            }
        }
    }
}
