using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour {

    public GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
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
