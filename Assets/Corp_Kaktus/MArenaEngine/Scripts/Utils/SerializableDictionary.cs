using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Utils
{
    [Serializable]
    public class SerializableDictionary <TKey, TValue> :IEnumerable<JoinData<TKey, TValue>>
    {
        [SerializeField] public List<TKey> keys;
        [SerializeField] public List<TValue> values;
        
        
        public TValue this[TKey i]
        {
            get => values[keys.IndexOf(i)];
            set => values[keys.IndexOf(i)] = value;
        }
        public TKey this[TValue i]
        {
            get => keys[values.IndexOf(i)];
            set => keys[values.IndexOf(i)] = value;
        }

        public void Add(TKey key, TValue value)
        {
            keys.Add(key);
            values.Add(value);
        }

        public IEnumerator<JoinData<TKey, TValue>> GetEnumerator()
        {
            return keys.Select((t, i) => new JoinData<TKey, TValue>(values[i],t)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public struct JoinData<TKey, TValue>
    {
        public TKey Key;
        public TValue Value;

        public JoinData(TValue value, TKey key)
        {
            Value = value;
            Key = key;
        }
    }
    // todo 
    // review
    
}