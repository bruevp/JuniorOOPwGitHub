using UnityEngine;

// INHERITANCE
public class Cylinder : Shape
{
	[SerializeField] private int changeProbability = 300;

	// POLYMORPHISM
	protected override void Customize()
	{
		if(Random.Range(0, changeProbability) == 0)
		{
			transform.localScale = Random.Range(0.5f, 2f) * Vector3.one;
		}
	}
}