public class TimeMap {
    Dictionary<string, IList<(string value, int timestamp)>> map;

    public TimeMap() {
        map = new Dictionary<string, IList<(string value, int timestamp)>>();    
    }
    
    public void Set(string key, string value, int timestamp) {
        if (!map.ContainsKey(key)) 
            map.Add(key, new List<(string value, int timestamp)>());
        map[key].Add((value, timestamp));
    }
    
    public string Get(string key, int timestamp) {
        if (!map.ContainsKey(key)) return "";
        var list = map[key];
        if (list is null || list.Count == 0) return "";

        int l = 0, r = list.Count - 1;
        int index = -1;
        while (l <= r) {
            int middle = l + (r - l) / 2;
            
            if (list[middle].timestamp <= timestamp) {
                index = middle;
                l = middle + 1;
            } else {
                r = middle - 1;
            }
        }

        if (index != -1) return list[index].value;
        return "";
    }
}
