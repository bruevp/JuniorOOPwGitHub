using UnityEngine;

// INHERITANCE
public class Sphere : Shape
{
	[SerializeField] private float pulseSpeed = 5f;

	// POLYMORPHISM
	protected override void Customize()
	{
		transform.localScale = Vector3.one * (1.5f + Mathf.Sin(pulseSpeed * Time.time) * 0.25f);
	}
}