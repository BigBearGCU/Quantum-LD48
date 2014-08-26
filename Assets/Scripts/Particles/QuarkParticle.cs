using UnityEngine;
using System.Collections;

public class QuarkParticle : FundamentalParticleBehaviour
{
    public LayerMask layer;
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



    public override void Disable()
    {
        iTween.Stop();
        /*
        GameObject[] attractables = GameObject.FindGameObjectsWithTag("Attractable");
        foreach(GameObject o in attractables)
        {
            o.SendMessage("Captured", false);
        }*/
    }


    public override void Apply()
    {
        if (enabled)
        {
            GameObject[] attractables = GameObject.FindGameObjectsWithTag("Attractable");
            foreach(GameObject o in attractables)
            {
                Vector3 direction = (transform.position - o.transform.position);
                float magnitude = direction.magnitude;
                if (magnitude<range)
                {
                    Vector3 position = o.transform.position;
                    position.x = transform.position.x;
                    iTween.MoveTo(o, position, 10.0f);
                    o.SendMessage("Captured", false);
                }
                
            }

            ////do a spehere cast, find objects that attriable and pull towards(think tractor beam)
            //if (Physics.SphereCast(transform.position, range, transform.forward, out hitInfo, Mathf.Infinity, layer.value))
            //{
            //    //lets grab collider collider 
            //    Collider c = hitInfo.collider;
            //    Debug.Log("In Something "+c.name);
            //    if (c.tag == "Attractable")
            //    {
            //        Debug.Log("Grabbed Something");
            //        //send message to say that has been captured
            //        c.gameObject.SendMessage("Captured", true);
            //        Vector3 direction = (transform.position - c.transform.position);
            //        float magnitude = direction.magnitude;
            //        direction.Normalize();
            //        c.gameObject.rigidbody.AddForce(direction * magnitude);

            //    }
            //}
        }
    }
}
