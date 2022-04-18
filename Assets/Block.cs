using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private int _health = 2;
    [SerializeField] private int _value = 5;
    private FieldSpawner _fieldSpawner;

    public FieldSpawner FieldSpawner
    {
        set
        {
            _fieldSpawner = value;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Baller>())
        {
            _health -= 1;
            if (_health <= 0)
            {
                _fieldSpawner.BlocksCount = 1;
                this.gameObject.SetActive(false);
            }
        }
    }
    

}
