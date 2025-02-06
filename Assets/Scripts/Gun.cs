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
    private GetWeapon _getWeapon;

    private void RemoveWeapon()
    {
        _getWeapon.RemoveWeapon();
        _getWeapon = null;
    }
        public void PickUpWeapon(GetWeapon getWeapon)
        {
            _getWeapon = getWeapon;
            _totalBulletsNumber = _maxBulletNumber;
            Reload();
            _weaponAnimator.Play("GetWeapon");
            UpdateBulletText();
        }
    public void Shoot ()
    {
        if (_currentBulletsNumber == 0)
        {
            if (_totalBulletsNumber == 0)
            {
                RemoveWeapon();
            }
            return;
        }
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
        if (_currentBulletsNumber >= _cartidgeBulletsNumber || _totalBulletsNumber == 0)
        {
            return;
        }
        int bulletsNeeded = _cartidgeBulletsNumber - _currentBulletsNumber;
        if (_totalBulletsNumber >= _cartidgeBulletsNumber)
        {
            _currentBulletsNumber = bulletsNeeded;
        }   
        else if (_totalBulletsNumber > 0)
        {
            _currentBulletsNumber = _totalBulletsNumber;
        }
        _totalBulletsNumber -= _currentBulletsNumber; 
        UpdateBulletText();
        _weaponAnimator.Play("Reload");
    }
    private void UpdateBulletText()
    {
        if(_bulletText == null)
        {
            _bulletText = _getWeapon.GetComponent<UIController>().BulletsText;
        }
        _bulletText.text = _currentBulletsNumber + "/" + _totalBulletsNumber;
    }
}
