using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private Transform _bulletPivot;
    [SerializeField]
    private Animator _weaponAnimator;
    [SerializeField]
    private int _maxBulletNumber = 20;
    [SerializeField]
    private int _cartidgeBulletsNumber = 5;
    private int _totalBulletsNumber = 0;
    private int _currentBulletsNumber = 0;
    private Text _bulletText;
    public void Shoot ()
    {
        _weaponAnimator.Play("Shoot", -1, 0);
    GameObject.Instantiate(_bullet, _bulletPivot.position, _bulletPivot.rotation);  
    _currentBulletsNumber --;
    UpdateBulletText();
    }
    public void PickUpWeapon()
    {
        _totalBulletsNumber = _maxBulletNumber;
        _currentBulletsNumber = _cartidgeBulletsNumber;
        _weaponAnimator.Play("GetWeapon");
        UpdateBulletText();
    }
    public void Reload()
    {
        if (_totalBulletsNumber >= _cartidgeBulletsNumber)
        {
            _currentBulletsNumber = _cartidgeBulletsNumber;
        }   
        else if (_totalBulletsNumber > 0)
        {
            _currentBulletsNumber = _totalBulletsNumber;
        }
        _totalBulletsNumber -= _currentBulletsNumber; 
        UpdateBulletText();
    }
    private void UpdateBulletText()
    {
        if(_bulletText == null)
        {
            _bulletText = GameObject.Find("BulletText").GetComponent<Text>();
        }
        _bulletText.text = _currentBulletsNumber + "/" + _totalBulletsNumber;
    }
}
