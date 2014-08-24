using UnityEngine;
using System.Collections;

public class ExitScript : MonoBehaviour {

    public GameObject levelManager;
	// Use this for initialization
	void Start () {
        levelManager = GameObject.Find("LevelManager");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider c)
    {
        if (c.tag=="Player")
        {
            if (levelManager != null)
                levelManager.SendMessage("EndOfLevel", SendMessageOptions.DontRequireReceiver);
            else
                Application.LoadLevel(0);
        }
    }
}
