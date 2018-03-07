using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeedLeaf : MonoBehaviour
{
	public float weedSpeed;
	public float rotateAmount;

	public void Activate()
	{
		GetComponent<Rigidbody2D>().velocity = Vector2.down * weedSpeed;
		StartCoroutine(Rotate());
	}

	IEnumerator Rotate()
	{
		int sign = UnityEngine.Random.Range(0, 1) * -2 + 1;
		while (true)
		{
			Vector3 curRot = transform.rotation.eulerAngles;
			transform.rotation = Quaternion.Euler(curRot.x, curRot.y, curRot.z + sign * rotateAmount);
			yield return new WaitForEndOfFrame();
		}
	}
}
