using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

    GameObject levelManager;
	// Use this for initialization
	void Start () {
        levelManager = GameObject.Find("LevelManager");
#if UNITY_WEBPLAYER
        GameObject exitButton=GameObject.Find("ExitButton");
        exitButton.collider.enabled=false;
#endif
                  }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnStartPressed()
    {
        levelManager.SendMessage("LoadLevel", 0, SendMessageOptions.DontRequireReceiver);
    }

    public void OnOptionsPressed()
    {
        levelManager.SendMessage("LoadOptions",SendMessageOptions.DontRequireReceiver);
    }

    public void OnExitPressed()
    {
        Application.Quit();
    }
}
