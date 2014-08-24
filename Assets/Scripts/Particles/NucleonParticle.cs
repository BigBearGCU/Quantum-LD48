using UnityEngine;
using System.Collections;

public class NucleonParticle : FundamentalParticleBehaviour {

    public float currentBalanceValue=2;
    public float startBalanceValue;

    public float upperLimit = 2.0f;
    public float lowerLimit = 0.1f;

    public float upperLimitModifier = 2.0f;
    public float lowerLimitModifier = 0.1f;

	// Use this for initialization
	void Start () {
        currentBalanceValue = transform.localScale.x;
        startBalanceValue = currentBalanceValue;
        upperLimit = currentBalanceValue * upperLimitModifier;
        lowerLimit = currentBalanceValue * lowerLimitModifier;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UpdateBalance(float value)
    {
        if ((currentBalanceValue + value) > upperLimit)
            currentBalanceValue = upperLimit;
        else if ((currentBalanceValue + value) < lowerLimit)
            currentBalanceValue = lowerLimit;
        else
            currentBalanceValue += value;
    }

    public override void Disable()
    {
        currentBalanceValue = startBalanceValue;
    }

    public override void Apply()
    {
        transform.localScale = new Vector3(currentBalanceValue,currentBalanceValue,currentBalanceValue);
    }
}
