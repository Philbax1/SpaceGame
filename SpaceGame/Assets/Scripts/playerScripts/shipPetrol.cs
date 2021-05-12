using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipPetrol : MonoBehaviour
{
    public int maxPetrol = 100;
    public int currentPetrol;

    public petrolBar petrolBar;

    // Start is called before the first frame update
    void Start()
    {
        currentPetrol = maxPetrol;
        petrolBar.SetMaxPetrol(maxPetrol);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log(maxPetrol + currentPetrol);
            drainPetrol(20);
        }
    }

    void drainPetrol(int petrolDrain)
    {
        currentPetrol -= petrolDrain;

        petrolBar.SetPetrol(currentPetrol);
    }
}

//https://www.youtube.com/watch?v=BLfNP4Sc_iA