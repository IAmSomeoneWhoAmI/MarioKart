using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2ItemManager : MonoBehaviour
{
    [SerializeField]
    private List<Scriptable> _itemList;

    [SerializeField]
    private Scriptable _currentItem;

    [SerializeField]
    private Image _itemImage;

    [SerializeField]
    private int _numberOfItemUse;

    public KartControlP2 carControler;


    private void Update()
    {
        if (Input.GetButtonDown("ItemP2"))
        {
            UseItem();
        }
    }
    public void GenerateItem()
    {
        if (_currentItem == null)
        {
            _currentItem = _itemList[Random.Range(0, _itemList.Count)];
            _itemImage.sprite = _currentItem.itemSprite;
            _numberOfItemUse = _currentItem.itemUseCount;
        }
    }

    public void UseItem()
    {
        if (_currentItem != null)
        {
            _currentItem.Activation(this);
            _numberOfItemUse--;
            if (_numberOfItemUse <= 0)
            {
                _currentItem = null;
                _itemImage.sprite = null;
            }
        }
    }

}

