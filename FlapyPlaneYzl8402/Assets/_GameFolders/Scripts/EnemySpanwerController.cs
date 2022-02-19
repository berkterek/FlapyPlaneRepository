using UnityEngine;

public class EnemySpanwerController : MonoBehaviour
{
    [SerializeField] EnemyController _enemyPrefab;
    [SerializeField] float _timeCounterSpeed = 1f;
    [SerializeField] float _maxSpawnTime = 5f;
    [SerializeField] float _minSpawnTime = 1f;
    [SerializeField] float _yMaxBorder = 1.8f;

    float _currentTimeCounter;
    float _maxRandomTime;

    void Awake()
    {
        _currentTimeCounter = 0f;
        _maxRandomTime = Random.Range(_minSpawnTime, _maxSpawnTime);
        Debug.Log(_maxRandomTime);
    }

    void Update()
    {
        _currentTimeCounter += Time.deltaTime * _timeCounterSpeed;

        //3 saniyede bir calisicak
        if (_currentTimeCounter > _maxRandomTime)
        {
            SpawnProcess();
            _currentTimeCounter = 0f;
            _maxRandomTime = Random.Range(_minSpawnTime, _maxSpawnTime);
            Debug.Log(_maxRandomTime);
        } 
    }

    //3 sayiniyede bir spawn etsin
    [ContextMenu(nameof(SpawnProcess))]
    private void SpawnProcess()
    {
        //olusucak olan nesnenin prefab modelini ve bu modele bir parent atamis oluyoruz
        //Instantiate(_enemyPrefab, this.transform);
        
        //olsucakl olan nesnenin prefab modelinin pozisyon 0 rotasyon 0 vermis olduk
        //Instantiate(_enemyPrefab, Vector2.zero,Quaternion.identity);
        
        //Instantiate ile prefab modelinden yeni bir nesne clone'ladik ve onun enemycontroller referansini aldik
        // EnemyController enemyController = Instantiate(_enemyPrefab, Vector2.zero,Quaternion.identity);
        // enemyController.Message();

        float randomYValue = Random.Range(-_yMaxBorder, _yMaxBorder);
        Vector2 enemyPosition = new Vector2(transform.position.x, randomYValue);
        
        Instantiate(_enemyPrefab, enemyPosition, Quaternion.identity);
    }
}