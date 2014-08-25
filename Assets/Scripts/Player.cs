using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float Speed = 1.0f;
    public Animation mainAnimation;
    public Vector3 respawnPosition;
    public int levelAttempts=0;

	// Use this for initialization
	void Start () {
        respawnPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float direction = Input.GetAxis("Horizontal");
        mainAnimation["Take 001"].speed = direction*-1;
        rigidbody.angularVelocity = Vector3.back * Speed * direction;
	}

    void Respawn()
    {
        levelAttempts++;
        transform.position = respawnPosition;
        //return states back to normal
        SendMessage("SetInitialState");
    }
}
