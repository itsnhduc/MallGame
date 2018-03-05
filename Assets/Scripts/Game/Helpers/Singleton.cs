using UnityEngine;

public class Singleton<T> : MonoBehaviour where T: MonoBehaviour
{
    public static T Instance { get { return FindObjectOfType<T>(); } }
}