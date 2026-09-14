using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

//<summary> This script is used with the Spawner! It tracks the players mouseX and spawns Pubbies. - Zander :3 </summary>
public class Spawner : MonoBehaviour
{
    float currentX;
    Vector3 mousePos;

    float minX;
    float maxX;
    float cooldown = .5f;
    float lastSpawnTime;

    public GameObject testObject;

    private void Start()
    {
        currentX = 0;
        minX = -5f;
        maxX = 5f;
        lastSpawnTime = cooldown;
        
        StartCoroutine(CooldownTimer());
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
        if (context.performed && lastSpawnTime >= cooldown)
        {
            Instantiate(testObject, transform.position, Quaternion.identity);
            lastSpawnTime = 0f;
        }
    }

    IEnumerator CooldownTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(.1f);
            lastSpawnTime += .1f;
            yield return null;
        }
    }

    public void UpgradePubby()
    {

    }
}