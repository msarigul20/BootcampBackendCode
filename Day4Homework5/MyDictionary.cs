using System;
using System.Collections.Generic;
using System.Text;

namespace Day4Homework5
{
    class MyDictionary<KeyType,ValueType>
    {
        KeyType[] keys;
        ValueType[] values;
        KeyType[] tempKeys;
        ValueType[] tempValues;
        public MyDictionary()
        {
            keys = new KeyType[0];
            values = new ValueType[0];
        }
        //Providing t0 add stuff.
        public void Add(KeyType key, ValueType value)
        {
            tempKeys = keys;
            keys = new KeyType[keys.Length + 1];
            for (int i = 0; i < tempKeys.Length; i++)
            {
                keys[i] = tempKeys[i];
            }
            keys[keys.Length - 1] = key;

            tempValues = values;
            values = new ValueType[values.Length + 1];
            for (int i = 0; i < tempValues.Length; i++)
            {
                values[i] = tempValues[i];
            }
            values[values.Length - 1] = value;
        }
        //Returning the number of values.
        public int valueCount
        {
            get { return values.Length; }
        }
        //Returning the number of keys.
        public int keyCount
        {
            get { return keys.Length; }
        }
        //Displaying dictionary with keys and values.
        public void Print()
        {
            Console.WriteLine("\nKeys      " + "Values       \n");
            for (int i = 0; i < keys.Length; i++)
            {
                Console.WriteLine(keys[i]+"       "+values[i]);
            }
        }
    }
}
