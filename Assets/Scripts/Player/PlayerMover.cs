using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private List<Transform> _availablePaths;

    private int _startPathIndex = 1;
    private int _shiftIndexValue = 1;
    private int _firstPathIndex = 0;
    private int _lastPathIndex;
    private int _currentPathIndex;
    private float _moveSpeed = 10;
    public Vector3 _targetPosition;

    private Coroutine _moveCoroutine;

    public void MoveUp()
    {
        if (_currentPathIndex - _shiftIndexValue >= _firstPathIndex)
        {
            if (_moveCoroutine == null)
            {
                _currentPathIndex--;
                _targetPosition = _availablePaths[_currentPathIndex].position;

                _moveCoroutine = StartCoroutine(Move());
            }
        }
    }

    public void MoveDown()
    {
        if (_currentPathIndex + _shiftIndexValue <= _lastPathIndex)
        {

            if (_moveCoroutine == null)
            {
                _currentPathIndex++;
                _targetPosition = _availablePaths[_currentPathIndex].position;

                _moveCoroutine = StartCoroutine(Move());
            }
        }
    }

    private void Start()
    {
        _currentPathIndex = _startPathIndex;
        _targetPosition = _availablePaths[_currentPathIndex].position;
        _lastPathIndex = _availablePaths.Count - _shiftIndexValue;
        transform.position = _availablePaths[_startPathIndex].position;
    }

    private IEnumerator Move()
    {
        while (transform.position != _targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);

            yield return null;
        }

        _moveCoroutine = null;
    }
}
