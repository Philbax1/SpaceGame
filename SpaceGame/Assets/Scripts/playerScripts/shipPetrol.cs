using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipPetrol : MonoBehaviour
{
    public float maxEnergy = 100.00f;
    public static float currentPetrol;

    public petrolBar petrolBar;

    float regularPetrolDrain = 0.0001f;
    float boostPetrolDrain = 0.01f;


    // Start is called before the first frame update
    void Start()
    {
        currentPetrol = maxEnergy;
        petrolBar.SetMaxEnergy(maxEnergy);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.E)) drainPetrol(regularPetrolDrain);
        if (Input.GetKey(KeyCode.LeftShift)) drainPetrol(boostPetrolDrain);

    }

    void drainPetrol(float petrolDrain)
    {
        currentPetrol -= petrolDrain;

        petrolBar.SetEnergy(currentPetrol);
    }
}

//https://www.youtube.com/watch?v=BLfNP4Sc_iA