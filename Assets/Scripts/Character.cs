using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;

public interface IDamageable
{
    void TakeDamage(float damage);
}

public class Character : MonoBehaviour, IDamageable
{
    [field: SerializeField] public bool AI { get; set; }
    [field: SerializeField] public Camera CharacterCamera { get; set; }
    [field: SerializeField] protected Gradient healthGradient { get; set; }
    [field: SerializeField] protected CharacterMove characterMove { get; set; }
    [field: SerializeField] protected Renderer characterRenderer { get; set; }


    [field: SerializeField] public float HealthAmount { get; protected set; }
    [field: SerializeField] public float MaxHealthAmount { get; protected set; }

    private void Awake() => UpdateData();

    protected virtual void Start()
    {

    }

    public void UpdateData()
    {
        characterMove.AI = AI;
    }

    public virtual void TakeDamage(float damage)
    {
        HealthAmount -= damage;
        MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
        materialPropertyBlock.SetColor("_Color", healthGradient.Evaluate(HealthAmount / MaxHealthAmount));
        characterRenderer.SetPropertyBlock(materialPropertyBlock);
        if (HealthAmount <= 0)
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
