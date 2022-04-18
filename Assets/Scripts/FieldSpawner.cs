using UnityEngine;

public class FieldSpawner : MonoBehaviour
{
    [SerializeField] private int[,] _field;

    [SerializeField] private GameObject[] _blockTypes;

    [SerializeField] private GameManager _gm;

    [SerializeField]private BrickGridCalculation _brickGrid;

    private JsonSaver _fieldSaver = new JsonSaver();

    private int blocksCount = 0;

    public int BlocksCount
    {
        set 
        {
            blocksCount -= value;
            _gm.Score = 10;
            if (blocksCount <= 0)
            {
                blocksOver();
            }
        }
    }

    public delegate void BlocksOver();
    public static BlocksOver blocksOver;

    // Update is called once per frame
    private void Start()
    {
        _field = new int[(int)_brickGrid.Grid.x, (int)_brickGrid.Grid.y];
        _brickGrid.CalcSpriteScale();
        FieldFiller();
        FieldBlockSpawner();
    }
    private void FieldFiller()
    {
        for (int i = 0; i < (int)_brickGrid.Grid.x; i++)
        {
            for (int j = 0; j < (int)_brickGrid.Grid.y; j++)
            {
                _field[i, j] = Random.Range(1, _blockTypes.Length);
            }
        }
    }

    public void FieldBlockSpawner()
    {
        for (int i = 0; i < (int)_brickGrid.Grid.x; i++)
        {
            for (int j = 0; j < (int)_brickGrid.Grid.y; j++)
            {
                Debug.Log($"{_brickGrid.StartPoint}");
                Vector3 scale = new Vector3(_brickGrid.Scale, _brickGrid.Scale, _brickGrid.Scale);
                Vector2 spawnPoint = new Vector2(_brickGrid.StartPoint.x + _brickGrid._xStep * i, _brickGrid.StartPoint.y + _brickGrid._yStep * j);
                GameObject block = Instantiate(_blockTypes[_field[i, j]], spawnPoint, Quaternion.identity);
                block.transform.localScale = scale;
                block.transform.parent = this.transform;
                block.GetComponent<Block>().FieldSpawner = this;
                blocksCount += 1;
            }
        }
    }
    public void SaveFieldToFile()
    {
        _fieldSaver.SaveToFile(_field, _gm.ScneNumber);
    }
}
