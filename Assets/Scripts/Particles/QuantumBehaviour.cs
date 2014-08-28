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
    public GameObject GameUI;

    public bool leptonEnabled = false;
    public bool quarkEnabled = false;
    public bool higgsEnabled = false;
    public bool photonEnabled = false;
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
        lepton.enabled = false;
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

        GameUI = GameObject.Find("GameUI");
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
        if (Input.GetButtonDown("Lepton") && leptonEnabled)
        {
            GameUI.SendMessage("EnableButton", "Lepton",SendMessageOptions.DontRequireReceiver);
            ToggleParticle(ParticleType.Lepton);
        }
        if (Input.GetButtonDown("Photon") && photonEnabled)
        {
            GameUI.SendMessage("EnableButton", "Photon", SendMessageOptions.DontRequireReceiver);
            ToggleParticle(ParticleType.Photon);
        }
        if (Input.GetButtonDown("Higgs") && higgsEnabled)
        {
            GameUI.SendMessage("EnableButton", "Higgs", SendMessageOptions.DontRequireReceiver);
            ToggleParticle(ParticleType.Higgs);
        }
        if (Input.GetButtonDown("Quark") && quarkEnabled)
        {
            GameUI.SendMessage("EnableButton", "Quark", SendMessageOptions.DontRequireReceiver);
            ToggleParticle(ParticleType.Quark);
        }
    }
}
