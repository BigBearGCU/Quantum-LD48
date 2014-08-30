using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class GameMenu : MonoBehaviour {

    public struct ButtonToggle
    {
        public string name;
        public bool enable;
    }

    public GameObject player;
    public UIAtlas keyboard;
    public UIAtlas xbox360Joypad;
    public UIAtlas PS3Joypad;

    public List<GameObject> uiHints;
    private QuantumBehaviour quantumPowers;
    private GameObject buttonRoot;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        buttonRoot = transform.FindChild("Panel").gameObject;

        //set button state
        quantumPowers = player.GetComponent<QuantumBehaviour>();

        SetUIStates();
        //Get user Prefs for joypad
        ChangeUIHints();
	}


	
    void SetButtonState(string buttonName,UIButtonColor.State colourState,bool enabled)
    {
        GameObject obj = buttonRoot.transform.FindChild(buttonName).gameObject;
        obj.collider.enabled = enabled;
        UIButton button = obj.GetComponent<UIButton>();
        button.state = colourState;
    }
    void SetUIStates()
    {
        if (quantumPowers.leptonEnabled)
        {
            SetButtonState("LeptonButton",UIButtonColor.State.Normal,true);
        }
        if (quantumPowers.photonEnabled)
        {
            SetButtonState("PhotonButton", UIButtonColor.State.Normal, true);
        }
        if (quantumPowers.quarkEnabled)
        {
            SetButtonState("QuarkButton", UIButtonColor.State.Normal, true);
        }
        if (quantumPowers.higgsEnabled)
        {
            SetButtonState("HiggsButton", UIButtonColor.State.Normal, true);
        }


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

    public void EnableButton(ButtonToggle toggle)
    {
        if (toggle.enable)
            SetButtonState(toggle.name + "Button", UIButtonColor.State.Pressed, toggle.enable);
        else
            SetButtonState(toggle.name + "Button", UIButtonColor.State.Normal, toggle.enable);
    }

    public void DisableButton(string name)
    {
        
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
