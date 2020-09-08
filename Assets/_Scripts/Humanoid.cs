using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Humanoid : MonoBehaviour {

    protected abstract void Die();

    protected abstract void SetMaterialColor();

    protected abstract void CheckForDeath();

}
