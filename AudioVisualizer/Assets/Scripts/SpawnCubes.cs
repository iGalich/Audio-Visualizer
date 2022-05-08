using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    private const float _cubeRotation = 0.703125f; // 360 / 512

    [SerializeField] private GameObject _sampleCubePrefab;
    [SerializeField] private float _maxScale = 1000f;
    private GameObject[] _sampleCubes = new GameObject[512];

    private void Start()
    {
        for (int i = 0; i < _sampleCubes.Length; i++)
        {
            GameObject _instanceSampleCube = (GameObject)Instantiate(_sampleCubePrefab);
            _instanceSampleCube.transform.position = this.transform.position;
            _instanceSampleCube.transform.parent = this.transform;
            _instanceSampleCube.name = "SampleCube" + i;
             this.transform.eulerAngles = new Vector3(0f, -_cubeRotation * i, 0f);
             _instanceSampleCube.transform.position = Vector3.forward * 100;
             _sampleCubes[i] = _instanceSampleCube;
        }
    }

    private void Update()
    {
        for (int i = 0; i < _sampleCubes.Length; i++)
        {
            if (_sampleCubes != null)
            {
                _sampleCubes[i].transform.localScale = new Vector3(10f, AudioPeer.Samples[i] * _maxScale + 2, 10f);
            }
        }
    }
}