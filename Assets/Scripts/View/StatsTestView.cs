using TMPro;
using UnityEngine;

public class StatsTestView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI SpecialText;
    [SerializeField]
    private TextMeshProUGUI HealthText;

    public void UpdateSpecial(SPECIAL special)
    {
        SpecialText.text =
            $"S {special.S}\n" +
            $"P {special.P}\n" +
            $"E {special.E}\n" +
            $"C {special.C}\n" +
            $"I {special.I}\n" +
            $"A {special.A}\n" +
            $"L {special.L}";
    }

    public void UpdateStats(HealthBar healthBar)
    {
        HealthText.text =
            $"HEALTH {healthBar.Health}/{healthBar.MaxHealth},\n" +
            $"RAD {healthBar.Radiation.RadiationLevel}";
    }
}
