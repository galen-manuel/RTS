using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace COG.RTS
{
    public abstract class RuntimeSet<T> : ScriptableObject
    {
        public List<T> Items = new List<T>();

        public void Add(T pT)
        {
            if (Items.Contains(pT) == false)
            {
                Items.Add(pT);
            }
        }

        public void Remove(T pT)
        {
            Items.Remove(pT);
        }
    }
}
