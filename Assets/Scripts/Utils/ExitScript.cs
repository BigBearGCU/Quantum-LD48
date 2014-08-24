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

    void OnTriggerStay(Collider c)
    {
        if (c.tag=="Player")
        {
            levelManager.SendMessage("EndOfLevel", SendMessageOptions.DontRequireReceiver);
        }
    }
}
