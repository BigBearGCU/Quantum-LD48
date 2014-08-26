using UnityEngine;
using System.Collections;

public class DoorMoveScript : MonoBehaviour {

    public Transform targetPosition;
    public float moveTime = 5.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTrigger()
    {
        iTween.MoveTo(gameObject, targetPosition.position, moveTime);
    }
}
