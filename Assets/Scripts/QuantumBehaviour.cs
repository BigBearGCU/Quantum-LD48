using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(LeptonParticle))]
public class QuantumBehaviour : MonoBehaviour
{
    public LeptonParticle lepton;
    // Use this for initialization
    void Start()
    {
        lepton = GetComponent<LeptonParticle>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
