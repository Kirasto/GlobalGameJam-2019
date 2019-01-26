using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Key
{
    public string name;
    public KeyCode keyCode;

    public Key(string name, KeyCode keyCode)
    {
        this.name = name;
        this.keyCode = keyCode;
    }
}

public class KeysStore : MonoBehaviour
{
    public static KeyCode GetKeyCode(string name)
    {
        if (instance != null)
        {
            Key key = new Key("None", KeyCode.None);

            instance.keys.TryGetValue(name, out key);
            return key.keyCode;
        }
        return KeyCode.None;
    }

    public static KeysStore instance;
    public Dictionary<string, Key> keys;

    private void AddKey(string name, KeyCode keyCode)
    {
        keys.Add(name, new Key(name, keyCode));
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        keys = new Dictionary<string, Key>();
        AddKey("Up", KeyCode.Z);
        AddKey("Down", KeyCode.S);
        AddKey("Left", KeyCode.Q);
        AddKey("Right", KeyCode.D);
    }
}
