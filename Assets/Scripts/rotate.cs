using UnityEngine;

public class rotate : MonoBehaviour
{
  [SerializeField]
    private float _rotateSpeed = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  [SerializeField]
    private bool _isRotating = true;

    public bool IsRotating 
    {
      get {return _isRotating;}
      set {_isRotating = value;}
    }
    // Update is called once per frame
    void Update()
    {
      RotateWeapon(); 
    }
    private void RotateWeapon()
    {
      if (_isRotating)
      {
        gameObject.transform.Rotate(0f, _rotateSpeed * Time.deltaTime, 0f);
      }
    }
}
