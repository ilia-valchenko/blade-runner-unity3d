using UnityEngine;
using UnityEngine.UI;

public class JumpStaminaBar : MonoBehaviour
{
    private const int MaxJumpStaminaValue = 100;


    public Slider jumpStaminaBar;

    public static JumpStaminaBar instance;

    public int currentJumpStaminaValue;

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
    }

    public bool CanUseStamina(int amount) => this.currentJumpStaminaValue - amount > 0;
}
