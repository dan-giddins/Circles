using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskInstantiator : MonoBehaviour
{
	public GameObject DiskObject;

	// Start is called before the first frame update
	void Start()
	{
		Generate6(new Vector3(0, 0, 0));
		Generate14(new Vector3(2, 0, 0));

	}

	private void Generate14(Vector3 vector3)
	{
		throw new NotImplementedException();
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void Generate6(Vector3 centre)
	{
		RotateDisk(CreateAndMoveDisk(centre, new Vector3(0.5f, 0, 0)), new Vector3(0, 90, 0));
		RotateDisk(CreateAndMoveDisk(centre, new Vector3(-0.5f, 0, 0)), new Vector3(0, 90, 0));
		RotateDisk(CreateAndMoveDisk(centre, new Vector3(0, 0.5f, 0)), new Vector3(90, 0, 0));
		RotateDisk(CreateAndMoveDisk(centre, new Vector3(0, -0.5f, 0)), new Vector3(90, 0, 0));
		CreateAndMoveDisk(centre, new Vector3(0, 0, 0.5f));
		CreateAndMoveDisk(centre, new Vector3(0, 0, -0.5f));
	}

	private void RotateDisk(GameObject disk, Vector3 rotation) =>
		disk.transform.Rotate(rotation);

	private GameObject CreateAndMoveDisk(Vector3 centre, Vector3 offset)
	{
		var disk = Instantiate(DiskObject);
		disk.transform.localPosition = centre + offset;
		return disk;
	}
}
