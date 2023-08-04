using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    [SerializeField] private StringSerializedDictionary data;

    public void Start()
    {
        if (!Instance)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void Set(string key, string value)
    {
        if (data.ContainsKey(key))
            data[key] = value;
        else
            data.Add(key, value);
    }

    public string Get(string key)
    {
        return data[key];
    }

}
