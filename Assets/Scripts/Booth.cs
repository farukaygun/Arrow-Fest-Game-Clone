using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Booth : MonoBehaviour {

	[SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Material blue;
    [SerializeField] private Material red;
    [SerializeField] private TMP_Text boothText;
    [SerializeField] private string boothOperator;
    [SerializeField] private int boothNumber;
    [SerializeField] private MeshRenderer meshRenderer;

	private GameObject arrows;

    private void Start() {
        AssignOperator();
        AssignNumber();
        AssignText();
    }

    private void Update() {
    }

    private void AssignOperator() {
        int _operator = Random.Range(0, 3);

        switch (_operator) 
		{
            case 0:
                boothOperator = "+";
                meshRenderer.material = blue;
                break;
            case 1:
                boothOperator = "-";
                meshRenderer.material = red;
                break;
            case 2:
                boothOperator = "*";
                meshRenderer.material = blue;
                break;
            case 3:
                boothOperator = "/";
                meshRenderer.material = red;
                break;
        }
    }

    private void AssignNumber() {
        if (boothOperator == "+" || boothOperator == "-") 
		{
            boothNumber = Random.Range(1, 50);
        } 
		else if (boothOperator == "*" || boothOperator == "/") 
		{
            boothNumber = Random.Range(1, 3);
        }
    }

    private void AssignText() {
        boothText.text = boothOperator + boothNumber.ToString();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
		{
            arrows = other.gameObject;
            GateTrigger(arrows.transform.childCount);
			Destroy(this); // TODO: 
        }
    }

    private void GateTrigger(int arrowsCount) {
        int newArrowsCount;
		int instantiateCount;
		int destroyCount;
		
		if (boothOperator == "+")
		{
			newArrowsCount = arrowsCount + boothNumber;

			for (int i = 0; i < boothNumber; i++)
			{
				Instantiate(arrowPrefab, arrows.transform);
			}
		}
		else if (boothOperator == "-")
		{
			newArrowsCount = arrowsCount - boothNumber;
			destroyCount = arrowsCount - newArrowsCount;

			for (int i = 0; i < destroyCount; i++)
			{
				Destroy(arrows.transform.GetChild(i).gameObject);
			}
		}
		else if (boothOperator == "*")
		{
			newArrowsCount = arrowsCount * boothNumber;
			instantiateCount = newArrowsCount - arrowsCount;

			for (int i = 0; i < instantiateCount; i++)
			{
				Instantiate(arrowPrefab, arrows.transform);
			}
		}
		else if (boothOperator == "/")
		{
			newArrowsCount = arrowsCount / boothNumber;
			destroyCount = arrowsCount - newArrowsCount;

			for (int i = 0; i < destroyCount; i++)
            {
                Destroy(arrows.transform.GetChild(i).gameObject);
            }
		}
    }
}
