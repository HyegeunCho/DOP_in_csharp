using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace DataMap
{
    public class DataMap
    {
        private Dictionary<string, dynamic> _map;

        public DataMap(Dictionary<string, dynamic> inObj = null)
        {
            _map = inObj ?? new Dictionary<string, dynamic>();
        }
        
        private dynamic GetData_Internal(dynamic inTarget, params string[] inParam)
        {
            var dict = inTarget as Dictionary<string, dynamic>;
            if (dict == null)
            {
                return inTarget;
            }

            string key = inParam[0];
            var nextParam = inParam.Skip(1).ToArray();

            if (!dict.TryGetValue(key, out var result))
            {
                return null;
            }

            if (nextParam.Length == 0)
            {
                return result;
            }

            return GetData_Internal(result, nextParam);
        }
        
        public dynamic GetData(params string[] inParam)
        {
            if (inParam == null || inParam.Length == 0)
            {
                throw new ArgumentNullException();
            }
            return GetData_Internal(_map, inParam);
        }

        public bool SetData(dynamic inValue, params string[] inParam)
        {
            dynamic currentNode = _map;
            
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


        
        public static Dictionary<string, dynamic> MapOf(params dynamic[] inParams)
        {
            if (inParams == null || inParams.Length == 0)
            {
                throw new ArgumentNullException();
            }

            if (inParams.Length % 2 != 0)
            {
                throw new ArgumentException("Argument count not even.");
            }

            Dictionary<string, dynamic> result = new Dictionary<string, dynamic>();
            for (int i = 0; i < inParams.Length; i += 2)
            {
                string key = (string)inParams[i];
                dynamic value = inParams[i + 1];
                result.Add(key, value);
            }
            return result;
        }

        public static List<dynamic> ListOf(params dynamic[] inParams)
        {
            return inParams.ToList();
        }

        public static DataMap Create(Dictionary<string, dynamic> inObj = null)
        {
            DataMap result = new DataMap(inObj);
            return result;
        }
    }
}