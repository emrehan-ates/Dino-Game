using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.U2D;

[ExecuteInEditMode]
public class EnvironmentGenerator : MonoBehaviour
{
    [SerializeField] private SpriteShapeController _spriteShapeController;

    [SerializeField, Range(2f, 100f)] private int _length = 50;
    [SerializeField, Range(0f, 1f)] private float _smoothness = 0.5f;
    [SerializeField, Range(1f, 50f)] private float _xMul = 2f;
    [SerializeField, Range(1f, 50f)] private float _yMul = 2f;
    [SerializeField] private float _noise = 0.5f;
    [SerializeField] private float _bot = 10f;

    private Vector3 _lastPosisiton;

    private void OnValidate()
    {
        _spriteShapeController.spline.Clear();

        for (int i = 0; i < _length; i++)
        {
            _lastPosisiton = transform.position + new Vector3(i * _xMul, Mathf.PerlinNoise(0, i * _noise) * _yMul);
            _spriteShapeController.spline.InsertPointAt(i, _lastPosisiton);

            if(i != 0 && i != _length - 1)
            {
                _spriteShapeController.spline.SetTangentMode(i , ShapeTangentMode.Continuous);
                _spriteShapeController.spline.SetLeftTangent(i, Vector3.left * _xMul * _smoothness);
                _spriteShapeController.spline.SetRightTangent(i, Vector3.right * _xMul * _smoothness);

            }
        }    

        _spriteShapeController.spline.InsertPointAt(_length, new Vector3(_lastPosisiton.x, transform.position.y - _bot));
        _spriteShapeController.spline.InsertPointAt(_length + 1, new Vector3(transform.position.x, transform.position.y - _bot));   
 
    }

}
