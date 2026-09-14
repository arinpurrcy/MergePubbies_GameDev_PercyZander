using UnityEngine;

//<summary> This script is used to allow Scripts to talk to eachother. - Zander :3 </summary>
public class ServiceHub : MonoBehaviour
{
    public static ServiceHub Instance { get; private set; }

    [Header("System References")]
    [SerializeField] private Spawner spawner;

    public Spawner Spawner => spawner;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }
}