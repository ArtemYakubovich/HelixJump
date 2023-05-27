using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int _levelCount;
    [SerializeField] private GameObject _beam;
    [SerializeField] private SpawnPlatform _spawnPlatform;
    [SerializeField] private FinishPlatform _finishPlatfom;
    [SerializeField] private Platform[] _platfoms;

    private void Start()
    {
        Build();
    }

    private void Build()
    {
        GameObject beam = Instantiate(_beam, transform);
        float y = _levelCount / 2f;
        beam.transform.localScale = new Vector3(1, y, 1);

        Vector3 spawnPosition = beam.transform.position;
        spawnPosition.y += beam.transform.localScale.y;

        for (int i = 0; i < _levelCount; i++)
        {
            int index = Random.Range(0, _platfoms.Length);
            float yRotation = Random.Range(0, 360);
            SpawnPlatform(_platfoms[index],
                ref spawnPosition,
                Quaternion.Euler(0, yRotation, 0),
                beam.transform);
        }
    }

    private void SpawnPlatform(Platform platform,
        ref Vector3 spawnPosition,
        Quaternion rotation,
        Transform parent)
    {
        Instantiate(platform, spawnPosition, rotation, parent);
        spawnPosition.y -= 1;
    }
}
