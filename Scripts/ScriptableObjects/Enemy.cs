using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy",menuName ="Enemy")]
public class Enemy : ScriptableObject
{
    public float health; 
    public float damage; 
    public float lookRadius;
}
