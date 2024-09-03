using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonsterUI : MonoBehaviour
{
    public MonsterGrade monsterGrade;

    [SerializeField] private Sprite MonsterImage;
    [SerializeField] private Image ImagePanel;
    [SerializeField] private TextMeshProUGUI NameText;
    [SerializeField] private TextMeshProUGUI HpText;
    [SerializeField] private TextMeshProUGUI SpeedText;

    private Monster monsterState;

    // Start is called before the first frame update
    void Start()
    {
        monsterState = GameManager.Instance.GetMonster((int)monsterGrade);
        SettingText();
    }

    private void SettingText()
    {
        ImagePanel.sprite = MonsterImage;
        NameText.text = monsterState.Name;
        HpText.text = $"HP : {monsterState.MaxHealth}";
        SpeedText.text = $"Spd : {monsterState.Speed}";
    }
}
