using UnityEngine;
using UnityEngine.InputSystem;

public class Spawner : MonoBehaviour
{
    float currentX;
    Vector3 mousePos;

    float minX;
    float maxX;

    public GameObject testObject;

    private void Start()
    {
        currentX = 0;
        minX = -5f;
        maxX = 5f;
    }

    private void Update()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos); //Gets mouse position from screen to world coordinates
        currentX = mousePos.x;

        //Prevents spawner from going past certain point
        if (currentX < minX) currentX = minX;
        else if (currentX > maxX) currentX = maxX;

        transform.position = new Vector3(currentX, transform.position.y, transform.position.z);
    }

    public void SpawnObject(InputAction.CallbackContext context)
    {
        if (context.performed) Instantiate(testObject, transform.position, Quaternion.identity);
    }
}