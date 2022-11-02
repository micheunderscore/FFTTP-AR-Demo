using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextBtn : MonoBehaviour {
    public GameObject f1, f2, f3, ui1, ui2, ui3;
    public GameObject furnitureUI;

    public void showF1() {
        f1.SetActive(true);
        f2.SetActive(false);
        f3.SetActive(false);
        furnitureUI = ui1;
        furnitureUI.SetActive(false);
    }

    public void showF2() {
        f1.SetActive(false);
        f2.SetActive(true);
        f3.SetActive(false);
        furnitureUI = ui2;
        furnitureUI.SetActive(false);
    }

    public void showF3() {
        f1.SetActive(false);
        f2.SetActive(false);
        f3.SetActive(true);
        furnitureUI = ui3;
        furnitureUI.SetActive(false);
    }

    public void showFurnUI() {
        furnitureUI.SetActive(!furnitureUI.activeSelf);
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}

public enum Furnitures {
    f1,
    f2,
    f3
}
