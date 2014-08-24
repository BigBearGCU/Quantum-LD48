using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(LeptonParticle))]
public class QuantumBehaviour : MonoBehaviour
{
    public LeptonParticle lepton;
    public List<QuarkParticle> quarks = new List<QuarkParticle>();
    // Use this for initialization
    void Start()
    {
        lepton = GetComponent<LeptonParticle>();
        QuarkParticle p = new QuarkParticle();
        p.owner = gameObject;
        quarks.Add(p);
    }

    // Update is called once per frame
    void Update()
    {
        lepton.Apply();
        foreach(QuarkParticle q in quarks)
        {
            q.Apply();
        }
    }
}
