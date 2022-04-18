using UnityEngine;


public class BrickGridCalculation : MonoBehaviour
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private GameObject _container;
    // ¬ первой версии буду считать что юзаем квадратный спрайты
    [SerializeField] private int _width;
    [SerializeField] private int _height;

    [SerializeField] private int _xBorderOffset; // от границ экрана слева и справа в процентах
    [SerializeField] private int _yBorderOffset;

    [SerializeField] private int _xCellBorder;
    [SerializeField] private int _yCellBorder;

    [SerializeField] public float _xStep;
    [SerializeField] public float _yStep;

    [SerializeField] private Vector2 _workZone; // границы рабочей зоны дл€ размещени€ блоков
    [SerializeField] private Vector2 _cellSize;
    [SerializeField] private Vector2 _spriteSize;
    [SerializeField] private Vector2 _grid;

    [SerializeField] private Vector3 _startPoint;

    [SerializeField] private float _pixePerUnit;
    [SerializeField] private float _targetScale;
    

    [SerializeField] private bool _isSquare;

    public Vector3 StartPoint
    {
        get 
        {
            return _startPoint;
        }
    }
    public float Scale
    {
        get
        {
           return _targetScale;
        }
    }

    public Vector2 Grid
    {
        get
        {
            return _grid;
        }
    }
    void Start()
    {
        _width = Screen.width;
        _height = Screen.height;
        _workZone = new Vector2();
        CalcSpriteScale();
    }

    private void GetScreenResolution()
    {
        _width = Screen.width;
        _height = Screen.height;
        CalcPixelPerWorldUnit();
        CalcStartPoint();
    }

    private void CalcWorkZone()
    {
        GetScreenResolution();
        _workZone.x = _width - ((_width / 100) * (_xBorderOffset * 2));
        _workZone.y = _height - ((_height / 100) * _yBorderOffset);
    }
    private void CalcCellSize()
    {
        CalcWorkZone();
        _cellSize.x = (int)_workZone.x / _grid.x;
        _yStep =_xStep = _cellSize.x/ _pixePerUnit;
        _cellSize.y = (int)_workZone.y / _grid.y;
    }

    public void CalcSpriteScale()
    {
        CalcCellSize();
        _spriteSize.x = _spriteSize.y = _cellSize.x - ((_cellSize.x / 100) * (_xCellBorder * 2));
        _targetScale = _spriteSize.x / _sprite.textureRect.width;
        Debug.Log(_targetScale);
    }

    private void CalcPixelPerWorldUnit()
    {
        Vector2 leftBottomCorner = new Vector2(0,0);
        Vector2 rightBottomCorner = new Vector2(0,Screen.width);
        Vector3 leftBottomPoint = Camera.main.ScreenToWorldPoint(new Vector3(leftBottomCorner.x, leftBottomCorner.y, Camera.main.nearClipPlane));
        Vector3 rightBottomPoint = Camera.main.ScreenToWorldPoint(new Vector3(rightBottomCorner.x, rightBottomCorner.y, Camera.main.nearClipPlane));
        _pixePerUnit = _width / Mathf.Abs(Vector3.Distance(rightBottomPoint, leftBottomPoint));
    }

    private void CalcStartPoint()
    {
        Vector2 x = new Vector2(((-_workZone.x) / 2) + (_cellSize.x / 2),0f);
        _startPoint = Camera.main.ScreenToWorldPoint(new Vector3(x.x, x.y, Camera.main.nearClipPlane));
    }
}
