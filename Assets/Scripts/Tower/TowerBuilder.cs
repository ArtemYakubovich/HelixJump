using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int _levelCount;
    [SerializeField] private float _additioanalScale;
    [SerializeField] private GameObject _beam;
    [SerializeField] private SpawnPlatform _spawnPlatform;
    [SerializeField] private FinishPlatform _finishPlatfom;
    [SerializeField] private Platform[] _platfoms;

    private float _startAndFinishAdditionalScale = 0.5f;

    public float BeamScaleY => _levelCount / 2f + _startAndFinishAdditionalScale + _additioanalScale / 2f;
    
    private void Start()
    {
        Build();
    }

    private void Build()
    {
        GameObject beam = Instantiate(_beam, transform);
        beam.transform.localScale = new Vector3(1, BeamScaleY, 1);

        Vector3 spawnPosition = beam.transform.position;
        spawnPosition.y += beam.transform.localScale.y - _additioanalScale;

        SpawnPlatform(_spawnPlatform, ref spawnPosition, Quaternion.identity, beam.transform);
        
        for (int i = 0; i < _levelCount; i++)
        {
            int index = Random.Range(0, _platfoms.Length);
            float yRotation = Random.Range(0, 360);
            SpawnPlatform(_platfoms[index], ref spawnPosition, Quaternion.Euler(0, yRotation, 0), beam.transform);
        }
        
        SpawnPlatform(_finishPlatfom, ref spawnPosition, Quaternion.identity, beam.transform);
    }

    private void SpawnPlatform(Platform platform, ref Vector3 spawnPosition, Quaternion rotation, Transform parent)
    {
        Instantiate(platform, spawnPosition, rotation, parent);
        spawnPosition.y -= 1;
    }
}