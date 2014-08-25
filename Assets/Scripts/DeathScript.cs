using UnityEngine;
using System.Collections;

public class DeathScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider c)
    {
        Debug.Log(c.name);
        if (c.name=="DeathCollision")
        {
            c.transform.parent.gameObject.SendMessage("Respawn", SendMessageOptions.DontRequireReceiver);
        }
    }
}
