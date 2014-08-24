using UnityEngine;
using System.Collections;

public interface FundamentalParticle {

    void Enable();
    void Disable();

    void Apply();
}

public class FundamentalParticleBehaviour: MonoBehaviour,FundamentalParticle
{

    public void OnEnable()
    {
        Enable();
    }

    public void OnDisable()
    {
        Disable();
    }

    public virtual void Enable()
    {

    }

    public virtual void Disable()
    {

    }

    public virtual void Apply()
    {

    }
}
