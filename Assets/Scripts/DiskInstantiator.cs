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
		//Generate14(new Vector3(4, 0, 0));
	}

	private void Generate14(Vector3 centre)
	{
		const float scale = 1;
		// 6
	}

	private float GetPos(float angle) =>
		(float)Math.Pow(Math.Sin(ConvertToRadians(angle)), 1.5);

	public double ConvertToRadians(float angle) =>
		Math.PI / 180 * angle;

	private void Generate6(Vector3 position)
	{
		const float scale = 2;
		var sphere = Instantiate(new GameObject(), position, new Quaternion());
		sphere.name = "6Sphere";
		CreateFace(sphere, 0, 0, scale, 0);
		CreateFace(sphere, 0, 90, scale, 0);
		CreateFace(sphere, 0, 180, scale, 0);
		CreateFace(sphere, 0, 270, scale, 0);
		CreateFace(sphere, 90, 0, scale, 0);
		CreateFace(sphere, 270, 0, scale, 0);
	}

	private void CreateFace(
		GameObject sphere,
		float xRot,
		float yRot,
		float scale, 
		int i)
	{
		// create parent
		var parent = Instantiate(new GameObject(), sphere.transform);
		parent.name = $"{sphere.name}_{i}_parent";
		// create disk
		var disk = Instantiate(DiskObject, new Vector3(0, 0, -1), new Quaternion(), parent.transform);
		disk.transform.localScale *= scale;
		disk.name = $"{sphere.name}_{i}_disk";
		// rotate parent
		parent.transform.rotation = Quaternion.Euler(new Vector3(xRot, yRot));
	}
}
