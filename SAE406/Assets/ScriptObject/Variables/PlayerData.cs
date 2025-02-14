using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/Variables/PlayerData")]
public class PlayerData : ScriptableObject
{
    public int currentLifePoints = 0;
    public int maxLifePoints = 3;
}
