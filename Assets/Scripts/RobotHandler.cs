using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotHandler : MonoBehaviour {

    private Animator robotAnimator;
    private ParticleSystem robotParticles;

	// Use this for initialization
	void Start ()
    {
        robotAnimator = GetComponent<Animator>();
        robotParticles = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void HitAnimation()
    {
        robotParticles.Play();
        robotAnimator.SetTrigger("IsPunched");
    }

    public void DieAnimation()
    {
        robotAnimator.SetBool("Dead", true);
    }

    public void PunchAnimation()
    {
        robotAnimator.SetTrigger("Punch");
    }
}
