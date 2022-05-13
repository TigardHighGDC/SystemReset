using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour {
    private int Ammo = 5;
    public Text ammoText;

    void Update(){

        ammoText.text = Ammo.ToString();

    }
}
