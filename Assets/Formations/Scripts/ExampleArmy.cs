using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;

public class ExampleArmy : MonoBehaviour {
    private FormationBase _formation;

    public FormationBase Formation {
        get {
            if (_formation == null) _formation = GetComponent<FormationBase>();
            return _formation;
        }
        set => _formation = value;
    }

    [SerializeField] private GameObject _unitPrefab;
    public float _unitSpeed = 2;

    private readonly List<GameObject> _spawnedUnits = new List<GameObject>();
    private List<Vector3> _points = new List<Vector3>();
    public Transform _parent;

    private void Awake() {
        _parent = new GameObject("Unit Parent").transform;
        _parent.tag = "UnitParent";
        _parent.gameObject.AddComponent<CheckMovingDown>();
    }

    private void Update() {
        SetFormation();
        if(GetComponent<Movement>() != null) {
            _parent.gameObject.GetComponent<CheckMovingDown>().movingDown = GetComponent<Movement>().movingDown;
        }
        _parent.gameObject.GetComponent<CheckMovingDown>().exampleArmy = transform.gameObject;
    }

    private void SetFormation() {
        _points = Formation.EvaluatePoints().ToList();

        if (_points.Count > _spawnedUnits.Count) {
            var remainingPoints = _points.Skip(_spawnedUnits.Count);
            Spawn(remainingPoints);
        }
        else if (_points.Count < _spawnedUnits.Count) {
            Kill(_spawnedUnits.Count - _points.Count);
        }

        for (var i = 0; i < _spawnedUnits.Count; i++) {
            _spawnedUnits[i].transform.position = Vector3.MoveTowards(_spawnedUnits[i].transform.position, transform.position + _points[i], _unitSpeed * Time.deltaTime);
            _spawnedUnits[i].transform.rotation = Quaternion.LookRotation(_spawnedUnits[i].transform.position - transform.position + _points[i], Vector3.up);
            if (GetComponent<Movement>() != null) {
                if (GetComponent<Movement>().movingDown) {
                    if (!_spawnedUnits[i].GetComponent<IndividualMember>().rotatedDown) {
                        _spawnedUnits[i].transform.DORotate(new Vector3(0, 0, 0), 0.5f);
                        _spawnedUnits[i].GetComponent<IndividualMember>().rotatedDown = true;
                    }
                } else {
                    if (_spawnedUnits[i].GetComponent<IndividualMember>().rotatedDown) {
                        _spawnedUnits[i].transform.DORotate(new Vector3(0, 180, 0), 0.5f);
                        _spawnedUnits[i].GetComponent<IndividualMember>().rotatedDown = false;
                    }
                }
            }
        }
    }

    private void Spawn(IEnumerable<Vector3> points) {
        foreach (var pos in points) {
            var unit = Instantiate(_unitPrefab, transform.position + pos, Quaternion.identity, _parent);
            _spawnedUnits.Add(unit);
        }
    }

    private void Kill(int num) {
        for (var i = 0; i < num; i++) {
            var unit = _spawnedUnits.Last();
            _spawnedUnits.Remove(unit);
            Destroy(unit.gameObject);
        }
    }
}