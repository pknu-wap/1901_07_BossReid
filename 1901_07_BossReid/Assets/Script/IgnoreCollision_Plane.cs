using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision_Plane : MonoBehaviour
{
	public GameObject Step;
	public GameObject Demon;

	// Start is called before the first frame update
	void Start()
	{
		Physics.IgnoreCollision(Step.GetComponent<Collider>(), Demon.GetComponent<Collider>());
	}
}
