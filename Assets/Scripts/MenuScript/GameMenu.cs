using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class GameMenu : MonoBehaviour {

    public GameObject player;
    public UIAtlas keyboard;
    public UIAtlas xbox360Joypad;
    public UIAtlas PS3Joypad;

    public List<GameObject> uiHints;

    private QuantumBehaviour quantumPowers;
    
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        //set button state
        quantumPowers = player.GetComponent<QuantumBehaviour>();
        //Get user Prefs for joypad
        ChangeUIHints();
	}
	
	// Update is called once per frame
	void Update () 
    {

	}

    void ChangeUIHints()
    {
        bool joyPad = Convert.ToBoolean(PlayerPrefs.GetInt("usejoypad"));
        if (joyPad)
        {
            UISprite s = null;
            foreach(GameObject go in uiHints)
            {
                s = go.GetComponent<UISprite>();
                s.atlas = xbox360Joypad;
            }
        }
    }

    public void OnNucleonButtonDown()
    {
        player.SendMessage("ToggleParticle", QuantumBehaviour.ParticleType.Nucleon);
    }

    public void OnQuarkButtonDown()
    {
        player.SendMessage("ToggleParticle", QuantumBehaviour.ParticleType.Quark);
    }

    public void OnLeptonButtonDown()
    {
        player.SendMessage("ToggleParticle", QuantumBehaviour.ParticleType.Lepton);
    }

    public void OnHiggsButtonDown()
    {
        player.SendMessage("ToggleParticle", QuantumBehaviour.ParticleType.Higgs);
    }

    public void OnPhotonButtonDown()
    {
        player.SendMessage("ToggleParticle", QuantumBehaviour.ParticleType.Photon);
    }
}
