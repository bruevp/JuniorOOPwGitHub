using UnityEngine;

public class Cube : Shape
{
	[SerializeField] private float changeColorSpeed = 5f;
	private new Renderer renderer;

	private Color Color1 => Color.red;
	private Color Color2 => Color.green;

	private void Awake()
	{
		renderer = GetComponent<Renderer>();
	}
	protected override void Customize()
	{
		renderer.material.color = Color.Lerp(Color1, Color2, Mathf.PingPong(changeColorSpeed * Time.time, 1));
	}
}