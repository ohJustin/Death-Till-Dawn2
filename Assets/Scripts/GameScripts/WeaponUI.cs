using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class WeaponUI : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshPro magazineSizeText;
    [SerializeField] private TextMeshPro magazineCountText;

    public void UpdateInfo(Sprite weaponIcon, int magazineSize, int magazineCount) {
        icon.sprite = weaponIcon;
        magazineSizeText.text = magazineSize.ToString();
        int magazineCountAmount = magazineSize * magazineCount;
        magazineCountText.text = magazineCountAmount.ToString();
    }
}
