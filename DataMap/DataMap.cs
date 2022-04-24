using System.Collections;
using System.Runtime.ExceptionServices;

namespace DataMap
{
    public class DataMap
    {
        private Hashtable _map;

        public DataMap()
        {
            _map = new Hashtable();
        }

        public object GetData(params string[] inParam)
        {
            if (inParam.Length == 0) return _map;

            object currentNode = _map;
            for (int i = 0; i < inParam.Length; i++)
            {
                if ((currentNode is Hashtable) == false) return currentNode;
                currentNode = (currentNode as Hashtable)[inParam[i]];
            }

            return currentNode;
        }

        public bool SetData(object inValue, params string[] inParam)
        {
            object currentNode = _map;
            for (int i = 0; i < inParam.Length; i++)
            {
                if (currentNode == null)
                {
                    currentNode = new Hashtable();
                }
                else if (currentNode is Hashtable)
                {
                    var currentHashtable = currentNode as Hashtable;
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
                            currentHashtable.Add(inParam[i], new Hashtable());    
                        }
                        
                        currentNode = currentHashtable[inParam[i]];
                    }
                }
            }
            return true;
        }
        
        public static DataMap Create()
        {
            DataMap result = new DataMap();
            return result;
        }
        
        
    }
}