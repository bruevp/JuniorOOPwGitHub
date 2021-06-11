using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Shape : MonoBehaviour
{
	[SerializeField] protected float maxSpeed = 5;
	[SerializeField] protected float maxTurnSpeed = 1500;

	protected Rigidbody Rigidbody;

	private Bounds Bounds => GameManager.Instance.Bounds;
		private Vector3 RandomWithinBounds => 
		new Vector2(Random.Range(-Bounds.size.x, Bounds.size.x), Random.Range(-Bounds.size.y, Bounds.size.y));

	private float RandomRotation => Random.Range(-maxTurnSpeed, maxTurnSpeed);
	private float RandomSpeed => Random.Range(maxSpeed * 0.3f, maxSpeed);

	private float currentSpeed;

	private void Awake()
	{
		Rigidbody = GetComponent<Rigidbody>();
	}

	private void Start()
	{
		SetRandomPosition();
		StartCoroutine(RandomizeMovement());
		StartCoroutine(CustomizeRoutine());
	}

	private void Update()
	{
		Move();
	}

	private void SetRandomPosition() => transform.position = RandomWithinBounds;

	private IEnumerator RandomizeMovement()
	{
		while (true)
		{
			yield return new WaitForSeconds(1f);
			transform.Rotate(Vector3.forward * RandomRotation);
			currentSpeed = RandomSpeed;
		}
	}

	private IEnumerator CustomizeRoutine()
	{
		while (true)
		{
			yield return null;
			Customize();
		}
	}

	private void Move()
	{
		transform.Translate(transform.right * Time.deltaTime * currentSpeed);
		float x = Mathf.Clamp(transform.position.x, Bounds.min.x, Bounds.max.x);
		float y = Mathf.Clamp(transform.position.y, Bounds.min.y, Bounds.max.y);
		transform.position = new Vector2(x, y);
	}

	protected abstract void Customize();
}