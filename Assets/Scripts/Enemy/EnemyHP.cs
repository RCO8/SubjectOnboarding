using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] private Slider HpBar;
    private float maxHealth;

    public void SetMaxHealth(int h)
    {
        maxHealth = h;
    }

    public void ApplyHP(float h)
    {
        float getDmg = h / maxHealth;
        HpBar.value = getDmg;
    }
}