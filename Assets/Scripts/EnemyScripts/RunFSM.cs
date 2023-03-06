using UnityEngine;

public class RunFSM : MonoBehaviour {

	private Steering_Seek_Flee _steeringSeekFlee;
	public GameObject SteeringTarget;

	// Use this for initialization
	void Start() {
		//_steeringSeekFlee = FindObjectOfType<Steering_Seek_Flee>();
		//_steeringSeekFlee.setSteeringTarget(SteeringTarget);
	}


	void FixedUpdate() {
		_steeringSeekFlee = FindObjectOfType<Steering_Seek_Flee>();
		//_steeringSeekFlee.setSteeringTarget(SteeringTarget);
		//_steeringSeekFlee.StateFixedUpdate();

	}
	
	
}
