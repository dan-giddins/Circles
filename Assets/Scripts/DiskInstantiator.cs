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
		Instantiate(DiskObject, Position(centre, 0.5f, 0, 0), Quaternion.Euler(new Vector3(0, 90, 0)));
		Instantiate(DiskObject, Position(centre, -0.5f, 0, 0), Quaternion.Euler(new Vector3(0, 90, 0)));
		Instantiate(DiskObject, Position(centre, 0, 0.5f, 0), Quaternion.Euler(new Vector3(90, 0, 0)));
		Instantiate(DiskObject, Position(centre, 0, -0.5f, 0), Quaternion.Euler(new Vector3(90, 0, 0)));
		Instantiate(DiskObject, Position(centre, 0, 0, 0.5f), Quaternion.Euler(new Vector3(0, 0, 0)));
		Instantiate(DiskObject, Position(centre, 0, 0, -0.5f), Quaternion.Euler(new Vector3(0, 0, 0)));
	}

	private Vector3 Position(Vector3 centre, float x, float y, float z) =>
		centre + new Vector3(x, y, z);

	private void RotateDisk(GameObject disk, Vector3 rotation) =>
		disk.transform.Rotate(rotation);

	private GameObject CreateAndMoveDisk(Vector3 centre, Vector3 offset, float size)
	{
		var disk = Instantiate(DiskObject);
		disk.transform.localPosition = centre + offset;
		return disk;
	}
}
