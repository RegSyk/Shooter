using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeaponRotate : MonoBehaviour
{
    public float offset;
    public float RotationSpeed;

    [SerializeField] private Camera _myCamera;
    private Vector2 _direction;
    private Vector3 _worldPosition;
    private Vector3 _directionV3;

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = _myCamera.nearClipPlane + offset;
        _worldPosition = _myCamera.ScreenToWorldPoint(mousePosition);
        _directionV3 = _worldPosition - transform.position;

        Vector3 directionV3N = _directionV3.normalized;

        _direction = new Vector2(directionV3N.x, directionV3N.z);

        float singleStep = RotationSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, _directionV3, singleStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    private void OnDrawGizmos()
    {
    }
}
