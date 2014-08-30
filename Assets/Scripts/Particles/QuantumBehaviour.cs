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

        GameUI.SendMessage("ResetButtons", SendMessageOptions.DontRequireReceiver);
        
        //GameUI.SendMessage("EnableButton", new GameMenu.ButtonToggle { name = "Quark", enable = quark.enabled }, SendMessageOptions.DontRequireReceiver);
        //GameUI.SendMessage("EnableButton", new GameMenu.ButtonToggle { name = "Lepton", enable = lepton.enabled }, SendMessageOptions.DontRequireReceiver);
        //GameUI.SendMessage("EnableButton", new GameMenu.ButtonToggle { name = "Higgs", enable = higgs.enabled }, SendMessageOptions.DontRequireReceiver);
        //GameUI.SendMessage("EnableButton", new GameMenu.ButtonToggle { name = "Photon", enable = photon.enabled }, SendMessageOptions.DontRequireReceiver);
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
                    GameUI.SendMessage("EnableButton", new GameMenu.ButtonToggle { name = "Quark", enable = quark.enabled }, SendMessageOptions.DontRequireReceiver);
                    break;
                }
            case ParticleType.Lepton:
                {
                    lepton.enabled = !lepton.enabled;
                    currentParticle = lepton;
                    GameUI.SendMessage("EnableButton", new GameMenu.ButtonToggle { name = "Lepton", enable = lepton.enabled }, SendMessageOptions.DontRequireReceiver);
                    break;
                }
            case ParticleType.Higgs:
                {
                    higgs.enabled = !higgs.enabled;
                    currentParticle = higgs;
                    GameUI.SendMessage("EnableButton", new GameMenu.ButtonToggle { name = "Higgs", enable = higgs.enabled }, SendMessageOptions.DontRequireReceiver);
                    break;
                }
            case ParticleType.Photon:
                {
                    photon.enabled = !photon.enabled;
                    currentParticle = photon;
                    GameUI.SendMessage("EnableButton", new GameMenu.ButtonToggle { name = "Photon", enable = photon.enabled }, SendMessageOptions.DontRequireReceiver);
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
            ToggleParticle(ParticleType.Lepton);
        }
        if (Input.GetButtonDown("Photon") && photonEnabled)
        {
            ToggleParticle(ParticleType.Photon);
        }
        if (Input.GetButtonDown("Higgs") && higgsEnabled)
        {
            ToggleParticle(ParticleType.Higgs);
        }
        if (Input.GetButtonDown("Quark") && quarkEnabled)
        {   
            ToggleParticle(ParticleType.Quark);
        }
    }
}
