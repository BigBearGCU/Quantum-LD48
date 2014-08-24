using UnityEngine;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
    public List<string> levels=new List<string>();
    public int currentLevel = 0;

    public string startLevelName="MainMenu";
    public string optionsLevelName = "Options";

	void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void EndOfLevel()
    {
        currentLevel++;
        Debug.Log("Current level is "+currentLevel.ToString());
        if (currentLevel>=levels.Count){
            currentLevel = 0;
            Application.LoadLevel(startLevelName);
        }
        else
        {
            LoadLevel();
        }
    }

    void LoadLevel(int index)
    {
        currentLevel = index;
        LoadLevel();
    }

    void LoadLevel()
    {
        Debug.Log("Load Level");
        iTween.CameraFadeAdd();
        iTween.CameraFadeTo(1.0f, 0.5f);
        iTween.CameraFadeFrom(iTween.Hash("delay", 0.4f, "amount", 0.0f, "time", 0.5f, "oncomplete", "ActualLoadLevel", "oncompletetarget",gameObject));
    }

    void ActualLoadLevel()
    {
        //Complete load level
        Debug.Log("Complete Loading Level "+currentLevel.ToString());
        Application.LoadLevel(levels[currentLevel]);
    }

}
