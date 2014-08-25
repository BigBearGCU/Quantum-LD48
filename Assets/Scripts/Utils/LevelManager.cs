using UnityEngine;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
    public List<string> levels=new List<string>();
    public List<int> scores = new List<int>();
    public int currentLevel = 0;

    public string startLevelName="MainMenu";
    public string optionsLevelName = "Options";
    GameObject cameraFade;

	void Start () {
        DontDestroyOnLoad(gameObject);
        cameraFade= iTween.CameraFadeAdd();
        DontDestroyOnLoad(cameraFade);
        scores.Clear();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void EndOfLevel(int attempts)
    {
        currentLevel++;
        scores.Add(attempts);
        Debug.Log("Current level is "+currentLevel.ToString());
        if (currentLevel>=levels.Count){
            currentLevel = 0;
            LoadLevel(startLevelName);
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


    void LoadLevel(string name)
    {
        Application.LoadLevel(name);
    }
    void LoadLevel()
    {
        Debug.Log("Load Level");
        LoadLevel(levels[currentLevel]);
        //iTween.CameraFadeTo(1.0f, 1.0f);
        //iTween.CameraFadeFrom(iTween.Hash("delay", 0.9f, "amount", 0.0f, "time", 0.4f, "oncomplete", "ActualLoadLevel", "oncompletetarget",gameObject));
        
    }

    void ActualLoadLevel()
    {
        //Complete load level
        Debug.Log("Complete Loading Level "+currentLevel.ToString());
        
    }

}
