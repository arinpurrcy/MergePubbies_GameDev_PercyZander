using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

//<summary> This script is used with the Spawner! It tracks the players mouseX and spawns Pubbies. - Zander :3 </summary>
public class Spawner : MonoBehaviour
{
    private float currentX;
    private Vector3 mousePos;
    private bool canSpawn = true;

    private float minX;
    private float maxX;
    private float cooldown = .5f;
    private float lastSpawnTime;

    public int currentPubby = 9;
    private int nextPubby;
    public (int,int) evilPubbyChance = (1, 100);
    public bool isEvilPubby = false;

    public GameObject pubbyPrefab;

    private ServiceHub serviceHub;

    private void Start()
    {
        serviceHub = ServiceHub.Instance;

        currentX = 0;
        minX = -5f;
        maxX = 5f;
        lastSpawnTime = cooldown;

        currentPubby = 9;
        nextPubby = Random.Range(6, 10);
        gameObject.GetComponent<SpriteRenderer>().sprite = serviceHub.MergeLogic.pubbySprites[currentPubby];

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
        if (context.performed && lastSpawnTime >= cooldown && canSpawn)
        {
            Instantiate(pubbyPrefab, transform.position, Quaternion.identity);
            StartCoroutine(ChangeCurrentPubby());
        }
    }

    private IEnumerator ChangeCurrentPubby()
    {
        yield return new WaitForSeconds(.01f);
        currentPubby = nextPubby;
        nextPubby = Random.Range(6, 10);

        int evilChance = Random.Range(1, evilPubbyChance.Item2 + 1); //The +1 is because the Max is exlusive in Random.Range
        if (evilChance == 1)
        {
            isEvilPubby = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = serviceHub.MergeLogic.EvilPubbySprites[currentPubby];
        }
        else
        {
            isEvilPubby = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = serviceHub.MergeLogic.pubbySprites[currentPubby];
        }
            
        lastSpawnTime = 0f;
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

    public void GameOver()
    {
        canSpawn = false;
    }
}