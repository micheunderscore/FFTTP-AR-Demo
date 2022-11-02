using System.Linq;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class NewDimCalc : MonoBehaviour {

    private GameObject[] objects; // GameObjects which make up the entire furniture

    public UnityEngine.UI.Text[] dimensionUi; // Dimensions UI Text for object

    private List<float>[,] dimensions = new List<float>[3, 2]; // Min & Max values for each dimension (x, y, z)

    private float[] totalDimensions = new float[3] { 0, 0, 0 }; // Total for each dimension

    private int totalCount = 0; // Total object count

    public void Awake() {
        // Initialization run, can't be placed anywhere else
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 2; j++) {
                dimensions[i, j] = new List<float>();
            }
        }
    }

    public void Start() {
        CheckTotalSize();
    }

    private void CheckTotalSize() {
        // Not for optimization, just makes it easier to read
        objects = GameObject.FindGameObjectsWithTag("Forniture");
        totalCount = objects.Length;

        // First run: Add up all min & max values for all child object 
        // bounds within the GameObject (manual min & max search)
        foreach (GameObject obj in objects) {
            for (int j = 0; j < 3; j++) {
                Bounds currObjBounds = obj.GetComponent<Renderer>().bounds;
                totalDimensions[j] = 0f;

                dimensions[j, 0].Add(currObjBounds.min[j]);
                dimensions[j, 1].Add(currObjBounds.max[j]);
            }
        }

        // Second run: Sort min & max lists and calculate distance 
        // between min and max points (length of entire object)
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 2; j++) {
                dimensions[i, j].Sort();
            }
            totalDimensions[i] = dimensions[i, 1][totalCount - 1] - dimensions[i, 0][0];
            dimensionUi[i].text = (totalDimensions[i] * 100f).ToString("F2") + "cm";
        }
    }

}