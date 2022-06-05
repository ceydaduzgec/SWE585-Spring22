using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerBehaviour : MonoBehaviour
{

	[SerializeField] Button resetAllButton;
	[SerializeField] Transform objectsContainer;


	private List<Vector3> spawnPositions;


	// Start is called before the first frame update
	void Start()
	{
		spawnPositions = new List<Vector3>();
		for (var i = 0; i < objectsContainer.childCount; i++)
		{
			spawnPositions.Add(objectsContainer.GetChild(i).position);
		}

		resetAllButton.onClick.AddListener(ResetAll);
	}

	public void ResetAll()
	{
		for (var i = 0; i < objectsContainer.childCount; i++)
		{
			Transform tr = objectsContainer.GetChild(i);
			tr.position = spawnPositions[i];
			tr.GetComponent<Rigidbody>().velocity = Vector3.zero;
		}
	}

}
