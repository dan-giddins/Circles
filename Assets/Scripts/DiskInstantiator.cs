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
		Generate14(new Vector3(4, 0, 0));
	}

	private void Generate14(Vector3 centre)
	{
		const float scale = 1;
		// 6
		InstantiateAndScale(centre, 1, 0, 0, 0, 90, 0, scale);
		InstantiateAndScale(centre, -1, 0, 0, 0, 90, 0, scale);
		InstantiateAndScale(centre, 0, 1, 0, 90, 0, 0, scale);
		InstantiateAndScale(centre, 0, -1, 0, 90, 0, 0, scale);
		InstantiateAndScale(centre, 0, 0, 1, 0, 0, 0, scale);
		InstantiateAndScale(centre, 0, 0, -1, 0, 0, 0, scale);
		// 8
		InstantiateAndScale(centre, GetPos(45), GetPos(45), GetPos(45), -45, 45, 0, scale);
	}

	private float GetPos(float angle) =>
		(float) Math.Pow(Math.Sin(ConvertToRadians(angle)),1.5);

	public double ConvertToRadians(float angle) =>
		Math.PI / 180 * angle;

	private void Generate6(Vector3 centre)
	{
		const float scale = 2;
		InstantiateAndScale(centre, 1, 0, 0, 0, 90, 0, scale);
		InstantiateAndScale(centre, -1, 0, 0, 0, 90, 0, scale);
		InstantiateAndScale(centre, 0, 1, 0, 90, 0, 0, scale);
		InstantiateAndScale(centre, 0, -1, 0, 90, 0, 0, scale);
		InstantiateAndScale(centre, 0, 0, 1, 0, 0, 0, scale);
		InstantiateAndScale(centre, 0, 0, -1, 0, 0, 0, scale);
	}

	private void InstantiateAndScale(
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
