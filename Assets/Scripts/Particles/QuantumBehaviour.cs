using UnityEngine;
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

    void SetInitialState()
    {
        lepton.enabled = true;
        quark.enabled = false;
        higgs.enabled = false;
        photon.enabled = false;
        nucleon.enabled = false;
    }
    // Use this for initialization
    void Start()
    {
        lepton = GetComponent<LeptonParticle>();
        quark= GetComponent<QuarkParticle>();
        higgs = GetComponent<HiggsParticle>();
        photon = GetComponent<PhotonParticle>();
        nucleon = GetComponent<NucleonParticle>();
        particles.AddRange(GetComponents<FundamentalParticleBehaviour>());
        SetInitialState();
    }

    public void ToggleParticle(ParticleType pType)
    {
        FundamentalParticleBehaviour currentParticle = null;
        switch (pType)
        {
            case ParticleType.Nucleon:
                {
                    nucleon.enabled = !nucleon.enabled;
                    currentParticle = nucleon;
                    break;
                }
            case ParticleType.Quark:
                {
                    quark.enabled = !quark.enabled;
                    currentParticle = quark;
                    break;
                }
            case ParticleType.Lepton:
                {
                    lepton.enabled = !lepton.enabled;
                    currentParticle = lepton;
                    break;
                }
            case ParticleType.Higgs:
                {
                    higgs.enabled = !higgs.enabled;
                    currentParticle = higgs;
                    break;
                }
            case ParticleType.Photon:
                {
                    photon.enabled = !photon.enabled;
                    currentParticle = photon;
                    break;
                }
        }
        if (currentParticle!=null)
            audio.PlayOneShot(currentParticle.sound);
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
