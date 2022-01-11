namespace StupidASM.Lang 
{
    public class Memory
    {
        private Dictionary<string, object> _data = new Dictionary<string, object>();

        public void SetResource(string key, object value)
        {
            key = key.ToLower();
            if (_data.ContainsKey(key) == false)
            {
                _data.Add(key, value);
                return;
            }
            _data[key] = value;
        }

        public void ClearResource(string key)
        {
            key = key.ToLower();
            if (_data.ContainsKey(key) == false)
            {
                throw new KeyNotFoundException("Key not found");
            }
            _data.Remove(key);
        }

        public object GetResource(string key)
        {
            key = key.ToLower();
            if (_data.ContainsKey(key) == false)
            {
                throw new KeyNotFoundException("Key not found");
            }
            if (key.StartsWith('[') && key.EndsWith(']'))
            {
                return _data[_data[key].ToString()];
            }
            return _data[key];
        }
    }
}