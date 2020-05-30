using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskInstantiator : MonoBehaviour
{
	public GameObject DiskObject;
	// arctan(1/2^(1/2)) in deg
	private const float Arctan = 35.2643897f;

	// Start is called before the first frame update
	void Start()
	{
		// 6
		Generate6(CreateSphere(new Vector3(0, 0, 0), 6), 2);
		// 14
		Generate14(CreateSphere(new Vector3(4, 0, 0), 14), 1.025f);
		// 26
		Generate26(CreateSphere(new Vector3(8, 0, 0), 26), 0.625f);
		// 50
		Generate50(CreateSphere(new Vector3(12, 0, 0), 50), 0.4f);
	}

	private void Generate50(GameObject sphere, float scale)
	{
		Generate26(sphere, scale);
		// 4 around faces
		// sides
		for (var i = 0; i < 4; i++)
		{
			CreateFace(sphere, +Arctan / 2, i * 90 + 22.5f, scale);
			CreateFace(sphere, +Arctan / 2, i * 90 - 22.5f, scale);
			CreateFace(sphere, -Arctan / 2, i * 90 + 22.5f, scale);
			CreateFace(sphere, -Arctan / 2, i * 90 - 22.5f, scale);
		}
		// top
		for (var i = 0; i < 4; i++)
		{
			CreateFace(sphere, (90 + Arctan)/2, i * 90 + 45, scale);
		}
		// bottom
		for (var i = 0; i < 4; i++)
		{
			CreateFace(sphere, -(90 + Arctan)/2, i * 90 + 45, scale);
		}
	}

	private void Generate26(GameObject sphere, float scale)
	{
		Generate14(sphere, scale);
		// lat and long
		for (var i = 0; i < 4; i++)
		{
			CreateFace(sphere, 0, i * 90 + 45, scale);
		}
		for (var i = 0; i < 4; i++)
		{
			CreateFace(sphere, i * 90 + 45, 0, scale);
		}
		for (var i = 0; i < 4; i++)
		{
			CreateFace(sphere, i * 90 + 45, 90, scale);
		}
	}

	private void Generate14(GameObject sphere, float scale)
	{
		Generate6(sphere, scale);
		// corners
		for (var i = 0; i < 4; i++)
		{
			CreateFace(sphere, Arctan, i * 90 + 45, scale);
			CreateFace(sphere, -Arctan, i * 90 + 45, scale);
		}
	}

	public double ConvertToRadians(float angle) =>
		Math.PI / 180 * angle;

	private void Generate6(GameObject sphere, float scale)
	{
		// faces
		for (var i = 0; i < 4; i++)
		{
			CreateFace(sphere, 0, i * 90, scale);
		}
		CreateFace(sphere, 90, 0, scale);
		CreateFace(sphere, 270, 0, scale);
	}

	private static GameObject CreateSphere(Vector3 position, int faces)
	{
		var sphere = Instantiate(new GameObject(), position, new Quaternion());
		sphere.name = $"Sphere_{faces}";
		return sphere;
	}

	private void CreateFace(
		GameObject sphere,
		float xRot,
		float yRot,
		float scale)
	{
		// create parent
		var parent = Instantiate(new GameObject(), sphere.transform);
		parent.name = $"{sphere.name}_parent";
		// create disk
		var disk = Instantiate(DiskObject, parent.transform.position + new Vector3(0, 0, -1), new Quaternion(), parent.transform);
		disk.transform.localScale *= scale;
		disk.name = $"{sphere.name}_disk";
		// rotate parent
		parent.transform.rotation = Quaternion.Euler(new Vector3(xRot, yRot));
	}
}
