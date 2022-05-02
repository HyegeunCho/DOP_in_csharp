using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace DataMap
{
    public static class _
    {
        public static dynamic Get(dynamic inTarget, params string[] inParams)
        {
            var dict = inTarget as Map;
            if (dict == null)
            {
                return inTarget;
            }

            string key = inParams[0];
            var nextParam = inParams.Skip(1).ToArray();

            if (!dict.TryGetValue(key, out var result))
            {
                return null;
            }

            if (nextParam.Length == 0)
            {
                return result;
            }

            return Get(result, nextParam);
        }

        // IMPL Listing 3.12
        public static dynamic Map(List<string> inKeys, Func<string, dynamic> inFunction)
        {
            List result = new List();
            foreach (string key in inKeys)
            {
                result.Add(inFunction(key));
            }
            return result;
        }
    }
    public class List : List<dynamic>
    {
        public static List of(params dynamic[] inParams)
        {
            List result = new List();
            foreach (var item in inParams)
            {
                result.Add(item);
            }

            return result;
        }
    }
    
    public class Map : Dictionary<string, dynamic>
    {
        public static Map of(params dynamic[] inParams)
        {
            if (inParams == null || inParams.Length == 0)
            {
                throw new ArgumentNullException();
            }

            if (inParams.Length % 2 != 0)
            {
                throw new ArgumentException("Argument count not even.");
            }

            Map result = new Map();
            for (int i = 0; i < inParams.Length; i += 2)
            {
                string key = (string)inParams[i];
                dynamic value = inParams[i + 1];
                result.Add(key, value);
            }
            return result;
        }
    }

    public class DataMap
    {
        public dynamic Value { private set; get; } = null;

        public bool SetData(dynamic inValue, params string[] inParam)
        {
            dynamic currentNode = Value;
            
            for (int i = 0; i < inParam.Length; i++)
            {
                if (currentNode == null)
                {
                    currentNode = new Dictionary<string, dynamic>();
                }
                else if (currentNode is Dictionary<string, dynamic>)
                {
                    var currentHashtable = currentNode as Dictionary<string, dynamic>;
                    if (currentHashtable.ContainsKey(inParam[i]))
                    {
                        currentNode = currentHashtable[inParam[i]];
                    }
                    else
                    {
                        if (i == inParam.Length - 1)
                        {
                            currentHashtable.Add(inParam[i], inValue);    
                        }
                        else
                        {
                            currentHashtable.Add(inParam[i], new Dictionary<string, dynamic>());    
                        }
                        
                        currentNode = currentHashtable[inParam[i]];
                    }
                }
            }
            return true;
        }
    }
}