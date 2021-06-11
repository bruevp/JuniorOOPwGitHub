using UnityEngine;

public class Sphere : Shape
{
	[SerializeField] private float pulseSpeed = 5f;

	protected override void Customize()
	{
		transform.localScale = Vector3.one * (1.5f + Mathf.Sin(pulseSpeed * Time.time) * 0.25f);
	}
}