using UnityEngine;
using System.Collections;

public class ExitScript : MonoBehaviour {

    public GameObject levelManager;
    public float levelLoadCountDown = 0.4f;
    int attempts;
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
            attempts = c.gameObject.GetComponent<Player>().levelAttempts;
            StartCoroutine(DoExit());
        }
    }

    IEnumerator DoExit()
    {
        yield return new WaitForSeconds(levelLoadCountDown);
        if (levelManager != null)
            levelManager.SendMessage("EndOfLevel", attempts,SendMessageOptions.DontRequireReceiver);
        else
            Application.LoadLevel(0);
    }
}
