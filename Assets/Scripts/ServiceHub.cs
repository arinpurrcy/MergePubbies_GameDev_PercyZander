using UnityEngine;

//<summary> This script is used to allow Scripts to talk to eachother. - Zander :3 </summary>
public class ServiceHub : MonoBehaviour
{
    public static ServiceHub Instance { get; private set; }

    [Header("System References")]
    [SerializeField] private Spawner spawner;
    [SerializeField] private MergeLogic mergelogic;

    public Spawner Spawner => spawner;
    public MergeLogic MergeLogic => mergelogic;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }
}