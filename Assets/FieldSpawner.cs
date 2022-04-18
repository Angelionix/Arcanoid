using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldSpawner : MonoBehaviour
{
    [SerializeField] private int _fieldX = 5;
    [SerializeField] private int _fieldY = 5;

    [SerializeField] private int[,] _field;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private float _xOffset;
    [SerializeField] private float _yOffset;

    [SerializeField] private GameObject[] _blockTypes;

    [SerializeField] private GameManager _gm;

    private GameObject[,] _fieldObj;

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
        _field = new int[_fieldX, _fieldY];
        _fieldObj = new GameObject[_fieldX, _fieldY];
        FieldFiller();
        FieldBlockSpawner();
        GameManager.levelRestarted += FieldReActivate;
    }
    private void FieldFiller()
    {
        for (int i = 0; i < _fieldX; i++)
        {
            for (int j = 0; j < _fieldY; j++)
            {
                _field[i, j] = Random.Range(1, _blockTypes.Length);
            }
        }
    }

    private void FieldBlockSpawner()
    {
        for (int i = 0; i < _fieldX; i++)
        {
            for (int j = 0; j < _fieldY; j++)
            {
                Vector2 spawnPoint = new Vector2(_startPoint.position.x + _xOffset * i, _startPoint.position.y + _yOffset * j);
                GameObject block = Instantiate(_blockTypes[_field[i, j]], spawnPoint, _startPoint.rotation);
                _fieldObj[i, j] = block;
                block.transform.parent = this.transform;
                block.GetComponent<Block>().FieldSpawner = this;
                blocksCount += 1;
            }
        }
    }

    private void FieldReActivate()
    {
        blocksCount = 0;
        foreach (GameObject block in _fieldObj)
        {
            block.SetActive(true);
            blocksCount += 1;
        }
    }

    public void SaveFieldToFile()
    {
        _fieldSaver.SaveToFile(_field, _gm.ScneNumber);
    }
}
