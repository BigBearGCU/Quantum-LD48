using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainMenuScript : MonoBehaviour {

    GameObject levelManager;
    List<GameObject> Buttons=new List<GameObject>();
    bool joypadControlsEnabled = false;
    Vector2 lastMousePos=Vector2.zero;

    public UISprite promptSprite;

    public UIAtlas xbox360Atlas;
    public UIAtlas ps3Atlas;
    public GameObject prompt;

	// Use this for initialization
	void Start () {
        //Grab and cache all buttons
        Transform buttonPanel=transform.FindChild("ButtonPanel");
        prompt.SetActive(false);
        for (int i = 0; i < buttonPanel.childCount; ++i)
        {
            Buttons.Add(buttonPanel.GetChild(i).gameObject);
        }
        levelManager = GameObject.Find("LevelManager");
#if UNITY_WEBPLAYER
        DisableExitButton();
#endif

#if UNITY_PSM
        PlayerPrefs.SetInt("usejoypad", 1);
        SwitchAtlas(ps3Atlas);
        prompt.SetActive(true);
#endif
                  }

    void SwitchAtlas(UIAtlas atlas)
    {
        promptSprite.atlas = atlas;
    }

    void ToggleJoypadControls(bool toggle)
    {
        if (toggle && !joypadControlsEnabled)
        {
            foreach (GameObject go in Buttons)
            {
                UIKeyNavigation nav = go.GetComponent<UIKeyNavigation>();
                nav.enabled = true;
            }
            joypadControlsEnabled = true;
            prompt.SetActive(toggle);
            PlayerPrefs.SetInt("usejoypad", 1);
#if UNITY_WEBPLAYER
            DisableExitButton();
#endif
        }
        else if (!toggle && joypadControlsEnabled)
        {
            foreach (GameObject go in Buttons)
            {
                UIKeyNavigation nav = go.GetComponent<UIKeyNavigation>();
                UIButton button=go.GetComponent<UIButton>();
                button.state=UIButton.State.Normal;
                nav.enabled = false;
            }
            prompt.SetActive(toggle);
            joypadControlsEnabled = false;
            PlayerPrefs.SetInt("usejoypad", 0);
#if UNITY_WEBPLAYER
            DisableExitButton();
#endif
        }
    }
	// Update is called once per frame
	void Update () 
    {
        float axis = Input.GetAxis("JoypadVertical");
        Vector2 currentMousePos=Input.mousePosition;
        if (axis != 0.0f)
        {
            ToggleJoypadControls(true);
        }

        if (Vector2.Distance(currentMousePos,lastMousePos)>0.5f)
        {
            ToggleJoypadControls(false);
        }
        lastMousePos = currentMousePos;
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

    public void DisableExitButton()
    {
        GameObject exitButton = GameObject.Find("ExitButton");
        UIButton button = exitButton.GetComponent<UIButton>();
        button.state = UIButton.State.Disabled;
        exitButton.collider.enabled = false;
    }
}
