using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class JumpStaminaBar : MonoBehaviour
{
    private const float MaxJumpStaminaValue = 100;
    private const float JumpStaminaRechargeCoefficient = 200;
    private const int RegenDelayInSeconds = 4;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    public static JumpStaminaBar instance;
    public Slider jumpStaminaBar;
    public float currentJumpStaminaValue;

    public void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.currentJumpStaminaValue = MaxJumpStaminaValue;
        this.jumpStaminaBar.maxValue = MaxJumpStaminaValue;
        this.jumpStaminaBar.value = this.currentJumpStaminaValue;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UseStamina(int amount)
    {
        if (!this.CanUseStamina(amount))
        {
            // TODO: Display an attempt of usage on UI.
            Debug.Log("Not enough stamina.");
            return;
        }

        this.currentJumpStaminaValue -= amount;
        this.jumpStaminaBar.value = this.currentJumpStaminaValue;

        if (this.regen != null)
        {
            StopCoroutine(this.regen);
        }

        this.regen = StartCoroutine(RegenStamina());
    }

    public bool CanUseStamina(int amount) => this.currentJumpStaminaValue - amount > 0;

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(RegenDelayInSeconds);

        while (this.currentJumpStaminaValue < MaxJumpStaminaValue)
        {
            this.currentJumpStaminaValue += MaxJumpStaminaValue / JumpStaminaRechargeCoefficient;
            this.jumpStaminaBar.value = this.currentJumpStaminaValue;

            yield return this.regenTick;
        }
    }
}
