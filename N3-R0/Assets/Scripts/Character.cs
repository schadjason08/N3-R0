using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    private Animator myAnimator;

	[SerializeField]
	private Transform bulletPos;

	[SerializedField]
	private float movementSpeed;

    private bool faceingRight;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
