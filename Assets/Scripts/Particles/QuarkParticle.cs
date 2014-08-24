using UnityEngine;
using System.Collections;

public class QuarkParticle : MonoBehaviour,FundamentalParticle
{

    public float range = 10.0f;
    RaycastHit hitInfo = new RaycastHit();

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
        
    }

    public void Disable()
    {
        GameObject[] attractables = GameObject.FindGameObjectsWithTag("Attractable");
        foreach(GameObject o in attractables)
        {
            o.SendMessage("Captured", false);
        }
    }


    public void Apply()
    {
        if (enabled)
        {
            //do a spehere cast, find objects that attriable and pull towards(think tractor beam)
            if (Physics.SphereCast(transform.position, range, transform.forward, out hitInfo))
            {
                //lets grab collider collider 
                Collider c = hitInfo.collider;
                if (c.tag == "Attractable")
                {
                    //send message to say that has been captured
                    c.gameObject.SendMessage("Captured", true);
                    Vector3 direction = (transform.position - c.transform.position);
                    float magnitude = direction.magnitude;
                    direction.Normalize();
                    c.gameObject.rigidbody.AddForce(direction * magnitude);

                }
            }
        }
    }
}
