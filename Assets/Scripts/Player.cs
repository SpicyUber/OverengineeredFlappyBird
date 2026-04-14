using UnityEngine;
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
    void OnMoveLeft(InputValue value) => ActivateAbility(_dashLeft);

    void OnMoveRight(InputValue value) => ActivateAbility(_dashRight);

    void OnUseAbility(InputValue value) => ActivateAbility(_useItem);

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position, Vector3.one);

    }

    private void ActivateAbility(Ability ability)
    {
        if (PreviousAbilityInterruptable()) { 
        ability.Activate(transform, _playerAnimator, _playerSoundSource,_playerStats.Values);
        _previousAbility = ability;
        }
    }

    private bool PreviousAbilityInterruptable() =>_previousAbility?.TryInterrupt(transform, _playerAnimator, _playerSoundSource) ?? true;
   
}
