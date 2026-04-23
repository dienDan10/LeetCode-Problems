public class Solution {

    public string Encode(IList<string> strs) {
        var result = new StringBuilder();
        foreach (var s in strs) {
            result.Append(s.Length);
            result.Append('#');
            result.Append(s);
        }

        return result.ToString();
    }

    public List<string> Decode(string s) {
        var result = new List<string>();

        int i = 0;
        while (i < s.Length) {
            //i will always be at the first index of the length 
            //and j will always be at the first index of the string
            int j = i;

            // find the # char
            while (s[j] != '#') j++;
            // get the length of the string
            int length = int.Parse(s.Substring(i, j - i));
            // get the string and put to result
            j++;
            result.Add(s.Substring(j, length));
            i = j + length;
        }

        return result;
   }
}
