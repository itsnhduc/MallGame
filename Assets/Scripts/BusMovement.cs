using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusMovement : MonoBehaviour
{
    public float offsetX;
    public float offsetY;
    public float minSpeed;
    public float maxSpeed;
	public float goRightPercentage;
	public Sprite goLeftSprite;

    Rigidbody2D rb { get { return GetComponent<Rigidbody2D>(); } }
    SpriteRenderer sr { get { return GetComponent<SpriteRenderer>(); } }

    void Start()
    {
		bool isGoingRight = UnityEngine.Random.Range(0, 1f) <= goRightPercentage / 100 ? true : false;
		int zIndex = UnityEngine.Random.Range(-1, 2);
		int sign = isGoingRight ? -1 : 1;
		float speed = UnityEngine.Random.Range(minSpeed, maxSpeed);

		if (!isGoingRight) sr.sprite = goLeftSprite;
		sr.sortingOrder = zIndex;
		transform.localPosition = new Vector2(sign * offsetX, transform.localPosition.y + offsetY * -zIndex);
		rb.velocity = -sign * Vector2.right * speed;
    }

	void Update()
	{
		if (Mathf.Abs(transform.localPosition.x) > offsetX) Destroy(gameObject);
	}
}
