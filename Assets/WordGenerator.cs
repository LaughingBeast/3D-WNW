using System.Collections;
using Unity.AI.Navigation;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

public class WordGenerator : MonoBehaviour
{
    public CinemachineCamera CameraFollow;
    public GameObject NavMesh;
    public Camera Camera;

    #region PreFab Definition
    private GameObject Player;
    private GameObject Enemy; 
    private GameObject Ground;
    private GameObject _obj1;
    #endregion

    #region Arena Generate <T>
    private float _mapX, _mapZ;
    private float _cameraRange = 25;

    [SerializeField]
    private int _enemyNumberOfFirstWawe = 100;
    public int ActualNumberOfEnemy;

    private Vector3 _spawnPoin = new Vector3(0, 1, 0);

    #endregion

    void Start()
    {

        #region ResourcesLoad

        Player = Resources.Load<GameObject>("GameObject/Player");
        Enemy = Resources.Load<GameObject>("GameObject/Enemy");
        Ground = Resources.Load<GameObject>("GameObject/Ground");
        _obj1 = Resources.Load<GameObject>("GameObject/Obj1");

        #endregion

        #region Map Generatot

        // Arena Generate
        int _sizeMin = 20;
        int _arenaSizeRange = 35;
        int _size = Random.Range(_sizeMin, _arenaSizeRange);
        var Arena = Instantiate(Ground);
        Arena.transform.position = new Vector3(0, 0, 0);
        Arena.transform.localScale = new Vector3(_size,_size,_size);

        _mapX = Arena.GetComponent<MeshRenderer>().bounds.size.x / 2;
        _mapZ = Arena.GetComponent<MeshRenderer>().bounds.size.z / 2;

        //Objects Generate
        int obj1CountRange = 10;
        int obj1SpawnCount = Random.Range(9, obj1CountRange);

        var testObj = Instantiate(_obj1);
        testObj.transform.position = new Vector3(11, 3, 11);
        var test = Physics.OverlapBox(new Vector3(10,3,10),_obj1.GetComponent<BoxCollider>().size, Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)),0);
        
        if (test.Length >= 0)
        {
            print("Zabrano");
        }
        
        for (int i = 1; i < obj1SpawnCount; i++)
        {

            StartCoroutine(ObjectSpawn(_obj1, 0, 3, 20)); 
            

        }
        
        

        //NavMesh Generate
        NavMesh.GetComponent<NavMeshSurface>().BuildNavMesh();
       
       
        #endregion

        #region Player Spawn
        var spawnP = Instantiate(Player);
        spawnP.transform.position = _spawnPoin;
        spawnP.GetComponent<Player>().Cam = Camera;
        Player = spawnP;
        CameraFollow.Follow = Player.transform; // Camera Follow
        
        #endregion

        #region Firs Wawe Spawn

        ActualNumberOfEnemy = _enemyNumberOfFirstWawe;

        for (int i = _sizeMin; i < _size; i++)
        {
            _enemyNumberOfFirstWawe += 10;
        }// Enemy+ depend on map size.

        for (int i = 0; i < _enemyNumberOfFirstWawe; i++) 
        {
            Vector3 _spawnPosition = RandomNPCPosition(5);
            while ( _spawnPosition.x > Player.transform.position.x - _cameraRange &&  _spawnPosition.x < Player.transform.position.x + _cameraRange &&  _spawnPosition.z > Player.transform.position.z - _cameraRange &&  _spawnPosition.z < Player.transform.position.z + _cameraRange ) 
            {
                _spawnPosition = RandomNPCPosition(5);
            }
            
            InstanceSpawn(Enemy, _spawnPosition, Quaternion.identity);
            
        }//enemy Spawn
        #endregion
    }


    void Update()
    {
        



    }

    private GameObject InstanceSpawn(GameObject instance,Vector3 _position, Quaternion rotation)
    {
        var spawnObject = Instantiate(instance, _position, rotation);
        if (instance == Enemy)
        {
            spawnObject.GetComponentInChildren<Navigation>().Player = Player;
        }

        
        return spawnObject;
    }

    
    private Vector3 RandomNPCPosition(float z) 
    {
        Vector3 _randomPosition = new Vector3(Random.Range(-_mapX, _mapX), z, Random.Range(-_mapZ, _mapZ));
        return _randomPosition;
    }

    private Vector3 RandomObjectPosition(float z,float borderGap)
    {
        Vector3 _randomPosition = new Vector3(Random.Range(-_mapX + borderGap, _mapX - borderGap), z, Random.Range(-_mapZ + borderGap, _mapZ - borderGap));

        
        return _randomPosition;
    }

    IEnumerator ObjectSpawn(GameObject instance, int layer, float z, float borderGap)
    {
  
        

        Quaternion _rotation = Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0));

        for (int i = 0; i < 10; i++)
        {
            Vector3 _position = RandomObjectPosition(z, borderGap);
            var _positonTester = Physics.OverlapBox(_position, instance.GetComponent<BoxCollider>().size * 0.5f, _rotation, layer);
            print(_position);
            //print(instance.GetComponent<BoxCollider>().size);
            
            if (_positonTester.Length == 0)
            { Instantiate(instance, _position, _rotation); break; }
            else
            {
                print("KOLIZE");
            }
        }
        yield return 1; //poèká jeden frame
    }
}
