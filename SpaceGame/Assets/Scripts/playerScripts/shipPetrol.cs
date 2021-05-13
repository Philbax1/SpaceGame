using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipPetrol : MonoBehaviour
{
    public int maxEnergy = 100;
    public int currentPetrol;

    public petrolBar petrolBar;

    // Start is called before the first frame update
    void Start()
    {
        currentPetrol = maxEnergy;
        petrolBar.SetMaxEnergy(maxEnergy);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log(maxEnergy + currentPetrol);
            drainPetrol(20);
        }
    }

    void drainPetrol(int petrolDrain)
    {
        currentPetrol -= petrolDrain;

        petrolBar.SetEnergy(currentPetrol);
    }
}

//https://www.youtube.com/watch?v=BLfNP4Sc_iA