﻿using System;
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
		//Generate14(new Vector3(2, 0, 0));
	}

	private void Generate14(Vector3 centre)
	{
		throw new NotImplementedException();
	}

	private void Generate6(Vector3 centre)
	{
		InstantiateAndSize(centre, 0.5f, 0, 0, 0, 90, 0, 1);
		InstantiateAndSize(centre, -0.5f, 0, 0, 0, 90, 0, 1);
		InstantiateAndSize(centre, 0, 0.5f, 0, 90, 0, 0, 1);
		InstantiateAndSize(centre, 0, -0.5f, 0, 90, 0, 0, 1);
		InstantiateAndSize(centre, 0, 0, 0.5f, 0, 0, 0, 1);
		InstantiateAndSize(centre, 0, 0, -0.5f, 0, 0, 0, 1);
	}

	private void InstantiateAndSize(
		Vector3 centre,
		float xPos,
		float yPos,
		float zPos,
		float xRot,
		float yRot,
		float zRot,
		float scale)
	{
		Instantiate(
			DiskObject,
			Position(centre, xPos, yPos, zPos),
			Quaternion.Euler(new Vector3(xRot, yRot, zRot)))
			.transform.localScale *= scale;
	}

	private Vector3 Position(Vector3 centre, float x, float y, float z) =>
		centre + new Vector3(x, y, z);

}
