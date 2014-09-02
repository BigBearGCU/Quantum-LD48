using UnityEngine;
using System.Collections;

public class OptionsScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject levelManager = GameObject.Find("LevelManager");
        Destroy(levelManager);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void BackButtonPressed()
    {
        Application.LoadLevel(0);
    }
}
