using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipController : MonoBehaviour
{
    private float forewardSpeed = 800f, strafeSpeed = 600f, boostSpeed = 1400f;
    private float activeForwardSpeed, activeStrafeSpeed;
    private float forwardAccleration = 5f, strafeAccleration = 2f;

    //mouse Look
    public float lookRateSpeed = 90f;
    private Vector2 lookInput, screenCentre, mouseDistance;

    private float rollInput;
    public float rollSpeed = 10f, rollAccelleration = 3.5f;


    void Start()
    {
        screenCentre.x = Screen.width * .5f;
        screenCentre.y = Screen.height * .5f;
    }

    void Update()
    {
        //Mouse
        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        mouseDistance.x = (lookInput.x - screenCentre.x) / screenCentre.y; //using y as screen is a rectangle and made turning to side faster than updown
        mouseDistance.y = (lookInput.y - screenCentre.y) / screenCentre.y;

        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        rollInput = Mathf.Lerp(rollInput, Input.GetAxisRaw("Roll"), rollAccelleration * Time.deltaTime);

        transform.Rotate(-mouseDistance.y * lookRateSpeed * Time.deltaTime, mouseDistance.x * lookRateSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime, Space.Self);


        //wasd keyboard
        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Input.GetAxisRaw("Vertical") * forewardSpeed, forwardAccleration * Time.deltaTime);
        activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Horizontal") * strafeSpeed, strafeAccleration * Time.deltaTime);

        transform.position += (transform.forward * activeForwardSpeed * Time.deltaTime) + (transform.right * activeStrafeSpeed * Time.deltaTime);

        // boost
        if (Input.GetKeyDown(KeyCode.LeftShift)) forewardSpeed = boostSpeed;
        if (Input.GetKeyUp(KeyCode.LeftShift)) forewardSpeed = 800f;
    }
}

// movement system : https://www.youtube.com/watch?v=J6QR4KzNeJU