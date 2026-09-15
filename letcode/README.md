# LeetCode Solutions

## My LeetCode Profile

http://leetcode.com/u/Mohamed_nas3er/

## Problems

### 1. Valid Anagram

Problem:
https://leetcode.com/problems/valid-anagram/

Solution:

public class Solution
{
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
            return false;

        int[] count = new int[26];

        for (int i = 0; i < s.Length; i++)
        {
            count[s[i] - 'a']++;
            count[t[i] - 'a']--;
        }

        for (int i = 0; i < count.Length; i++)
        {
            if (count[i] != 0)
                return false;
        }

        return true;
    }
}
Accepted

Screenshot:
`images/valid-anagram-accepted.png`

---

### 2. Greatest Common Divisor of Strings

Problem:
https://leetcode.com/problems/greatest-common-divisor-of-strings/

Solution:


public class Solution
{
    public string GcdOfStrings(string str1, string str2)
    {
        if (str1 + str2 != str2 + str1)
            return "";

        int gcd = GetGCD(str1.Length, str2.Length);

        return str1.Substring(0, gcd);
    }

    private int GetGCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = a % b;
            a = b;
            b = temp;
        }

        return a;
    }
}
Accepted

Screenshot:
`images/gcd-of-strings-accepted.png`