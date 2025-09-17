using UnityEngine;

public class spawner : MonoBehaviour
{
    public float spawntime = 10f;
    public Transform spawnpoint;
    public GameObject spawnobject;

    void Update()
    {
        if (Time.time < spawntime)
            Instantiate(spawnobject);
    }
}
