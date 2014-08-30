using UnityEngine;
using System.Collections;
using System.Text;
using System;

public class ScoreGUIScript : MonoBehaviour {

    public UILabel scoreLbl;
    public GameObject levelManagerObj;
	// Use this for initialization
	void Start () {
        levelManagerObj = GameObject.Find("LevelManager");
        if (levelManagerObj != null) { 
            LevelManager levelManager=levelManagerObj.GetComponent<LevelManager>();
            StringBuilder sb = new StringBuilder();
            for (int i=0;i<levelManager.scores.Count;i++)
            {
                sb.Append("Level ");
                sb.Append(i + 1).Append("                    ");
                sb.Append(levelManager.scores[i]);
                sb.Append("\n");
            }
	        //Grab Level Manager
            scoreLbl.text = sb.ToString();
        }
        bool joyPad = Convert.ToBoolean(PlayerPrefs.GetInt("usejoypad"));
        if (joyPad)
        {
            GameObject restartButton = GameObject.Find("RestartButton");
            UIKeyNavigation nav = restartButton.GetComponent<UIKeyNavigation>();
            nav.startsSelected = true;
            nav.enabled = true;

            GameObject exitButon = GameObject.Find("ExitButton");
            nav = restartButton.GetComponent<UIKeyNavigation>();
            nav.enabled = true;
        }
#if UNITY_WEBPLAYER
        DisableExitButton();
#endif
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnRestartButton()
    {
        if (levelManagerObj)
        {
            Destroy(levelManagerObj);
        }
        Application.LoadLevel(0);
    }

    public void OnExitButton()
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
