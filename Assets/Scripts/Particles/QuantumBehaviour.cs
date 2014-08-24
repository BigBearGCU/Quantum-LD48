using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(LeptonParticle))]
[RequireComponent(typeof(QuarkParticle))]
public class QuantumBehaviour : MonoBehaviour
{
    public LeptonParticle lepton;
    public QuarkParticle quark;
    // Use this for initialization
    void Start()
    {
        lepton = GetComponent<LeptonParticle>();
        quark= GetComponent<QuarkParticle>();

        //lepton.Disable();
        quark.Disable();

        lepton.enabled = true;
        quark.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        lepton.Apply();
        quark.Apply();
    }
}
