using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Player : Singleton<Player>
{
    [Header("Animation")]
    [SerializeField] Animator _playerAnimator;
    [Header("Sound")]
    [SerializeField] AudioSource _playerSoundSource;
    [Header("Abilities")]
    [SerializeField] Ability _dashLeft;
    [SerializeField] Ability _dashRight;
    [SerializeField] Ability _useItem;
    [Header("Base stats")]
    [SerializeField] PlayerStats _playerStats;
    Ability _previousAbility = null;
    [Header("Events")]
    public UnityEvent OnDeath;
    void OnMoveLeft(InputValue value) => ActivateAbility(_dashLeft);

    void OnMoveRight(InputValue value) => ActivateAbility(_dashRight);

    void OnUseAbility(InputValue value) => ActivateAbility(_useItem);


    private void ActivateAbility(Ability ability)
    {
        if (PreviousAbilityInterruptable() || PreviousAbilityDisabled()) {
            ability.Activate(transform, _playerAnimator, _playerSoundSource, _playerStats.Values);
            _previousAbility = ability;
        }
    }

    private bool PreviousAbilityInterruptable() => _previousAbility?.TryInterrupt(transform, _playerAnimator, _playerSoundSource) ?? true;
    private bool PreviousAbilityDisabled() => _previousAbility == null || !_previousAbility.Enabled;

    private void OnCollisionEnter(Collision collision)
    {
        OnDeath?.Invoke();
    }

}
