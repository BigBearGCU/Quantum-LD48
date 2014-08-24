﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(LeptonParticle))]
[RequireComponent(typeof(QuarkParticle))]
[RequireComponent(typeof(HiggsParticle))]
[RequireComponent(typeof(PhotonParticle))]
[RequireComponent(typeof(NucleonParticle))]
public class QuantumBehaviour : MonoBehaviour
{
    public LeptonParticle lepton;
    public QuarkParticle quark;
    public HiggsParticle higgs;
    public PhotonParticle photon;
    public NucleonParticle nucleon;
    public List<FundamentalParticleBehaviour> particles = new List<FundamentalParticleBehaviour>();

    public enum ParticleType
    {
        Nucleon,
        Quark,
        Lepton,
        Photon,
        Higgs
    }

    // Use this for initialization
    void Start()
    {
        lepton = GetComponent<LeptonParticle>();
        quark= GetComponent<QuarkParticle>();
        higgs = GetComponent<HiggsParticle>();
        photon = GetComponent<PhotonParticle>();
        nucleon = GetComponent<NucleonParticle>();

        //lepton.Disable();
        quark.Disable();

        lepton.enabled = true;
        quark.enabled = false;
        higgs.enabled = false ;
        photon.enabled = false;
        nucleon.enabled = false;

        particles.AddRange(GetComponents<FundamentalParticleBehaviour>());
    }

    public void ToggleParticle(ParticleType pType)
    {
        switch (pType)
        {
            case ParticleType.Nucleon:
                {
                    nucleon.enabled = !nucleon.enabled;
                    break;
                }
            case ParticleType.Quark:
                {
                    quark.enabled = !quark.enabled;
                    break;
                }
            case ParticleType.Lepton:
                {
                    lepton.enabled = !lepton.enabled;
                    break;
                }
            case ParticleType.Higgs:
                {
                    higgs.enabled = !higgs.enabled;
                    break;
                }
            case ParticleType.Photon:
                {
                    photon.enabled = !photon.enabled;
                    break;
                }
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(FundamentalParticleBehaviour particle in particles)
        {
            particle.Apply();
        }
    }
}
