using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTable : MonoBehaviour
{
    public GameObject hexPrefab; // Asigna tu prefab de hex�gono aqu�
	public GameObject hex; // Asigna tu prefab de hex�gono aqu�

	private float hexWidth; // Ancho del hex�gono (suponemos que es regular)
	private float hexHeight; // Altura del hex�gono (suponemos que es regular)
	private int numRows;
	private int numColumns;

	private void Start()
	{
		hex = hexPrefab.transform.GetChild(0).transform.GetChild(1).gameObject;
		hexWidth = hex.GetComponent<Renderer>().bounds.size.x;
		hexHeight = hex.GetComponent<Renderer>().bounds.size.z;
		CalculateGridSize();
		GenerateHexGrid();
	}

	private void CalculateGridSize()
	{
		// Calculamos el n�mero de filas y columnas para crear una cuadr�cula que forme un pent�gono regular
		numRows = Mathf.FloorToInt((2 * hexWidth) / (Mathf.Sqrt(3) * hexHeight)) + 1;
		numColumns = Mathf.FloorToInt(numRows + ((numRows - 1) / 2));
	}

	private void GenerateHexGrid()
	{
		for (int row = 0; row < numRows; row++)
		{
			for (int col = 0; col < numColumns; col++)
			{
				float xPos = col * (hexWidth * 0.75f);
				float zPos = row * (hexHeight * 0.5f);

				if (col % 2 == 1)
				{
					zPos += hexHeight * 0.25f;
				}

				GameObject hex = Instantiate(hexPrefab, new Vector3(xPos, 0f, zPos), Quaternion.identity);
				hex.transform.SetParent(transform);
			}
		}
	}
}



