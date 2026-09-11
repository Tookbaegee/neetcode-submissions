public class Solution {
    public bool IsValid(string s) {
        var stack = new List<char>();

        for (var i = 0; i < s.Length; i++) {
            if (!IsClosing(s[i])) {
                stack.Add(s[i]);
            } else {
                if (stack.Count() > 0) {
                    var opening = stack[stack.Count() - 1];
                    if (IsMatchingClosing(opening, s[i])) {
                        stack.RemoveAt(stack.Count() - 1);
                    }
                    else
                    {
                        return false;
                    }
                } else
                {
                    return false;
                }
            }
        }

        return stack.Count() == 0;
    }

    public static bool IsClosing(char c) {
        return c == ']' || c == '}' || c == ')';
    }

    public static bool IsMatchingClosing(char opening, char closing) {
        if (opening == '[') {
            return closing == ']';
        } else if (opening == '(') {
            return closing == ')';
        } else if (opening == '{') {
            return closing == '}';
        }

        return false;
    }
}
