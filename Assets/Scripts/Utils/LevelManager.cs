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
        if (currentLevel<levels.Count)
            LoadLevel();
        else
        {
            currentLevel = 0;
            //do camera fade
            Application.LoadLevel(startLevelName);
        }
    }

    void LoadLevel(int index)
    {
        currentLevel = index;
        LoadLevel();
    }

    void LoadLevel()
    {
        //do camera fade then load level
        Application.LoadLevel(levels[currentLevel]);
    }

}
