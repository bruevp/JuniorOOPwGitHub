using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Bounds bounds;

	private void Awake()
	{
        Initialize();
	}

	private void Initialize()
	{

	}

	private void Update()
    {
        SelectObjectWithMouse();
    }

    private void SelectObjectWithMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hitInfo))
            {
                var shape = hitInfo.transform.GetComponent<Shape>();
                if (shape)
                {
                    Debug.Log($"Clicked on {shape.name} of {shape.GetType().Name} type");
                }
            }
        }
    }
}