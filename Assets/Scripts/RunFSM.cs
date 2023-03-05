using UnityEngine;

public class RunFSM : MonoBehaviour {

	private Steering_Seek_Flee _steeringSeekFlee;

	// Use this for initialization
	void Start() {
		_steeringSeekFlee = FindObjectOfType<Steering_Seek_Flee>();
	}

	// Update is called once per frame


	void FixedUpdate() {
		_steeringSeekFlee.StateFixedUpdate();
	}
}
