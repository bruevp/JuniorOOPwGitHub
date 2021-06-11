using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ENCAPSULATION
    public Bounds Bounds { get; private set; }

    // ENCAPSULATION
    public static GameManager Instance { get; private set; }

	private void Awake()
	{
        Instance = this;
        // ABSTRACTION
        Initialize();
	}

	private void Initialize()
	{
        Bounds = new Bounds(Vector3.zero, new Vector2(10, 6f));

	}

	private void Update()
    {
        // ABSTRACTION
        SelectObjectWithMouse();
    }

    private void SelectObjectWithMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hitInfo))
            {
                var shape = hitInfo.transform.GetComponent<Shape>();
                if (shape)
                {
                    Debug.Log($"Clicked on GameObject, Named :{shape.name} of Type: {shape.GetType().Name}");
                }
            }
        }
    }
}