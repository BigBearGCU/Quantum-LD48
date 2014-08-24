using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

    public GameObject triggerTarget;
    public string triggerMethodName = "OnTrigger";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    protected void Fire()
    {
        triggerTarget.SendMessage(triggerMethodName, SendMessageOptions.DontRequireReceiver);
    }
}
