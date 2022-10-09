using System.Collections.Generic;
using System.Linq;

namespace Scrabble_Solver
{
    class Trie
    {
        private Dictionary<char, Trie> children = new Dictionary<char, Trie>();
        private bool isWord = false;

        public List<string> Solve(Dictionary<char, int> letters)
        {
            List<string> result = new List<string>();
            if (isWord)
            {
                result.Add("");
            }
            foreach (char letter in children.Keys)
            {
                if (letters.ContainsKey(letter) && letters[letter] > 0)
                {
                    letters[letter]--;
                    result.AddRange(children[letter].Solve(letters).Select(tail => letter + tail));
                    letters[letter]++;
                }
                else if (letters.ContainsKey(Constants.Blank) && letters[Constants.Blank] > 0)
                {
                    letters[Constants.Blank]--;
                    result.AddRange(children[letter].Solve(letters).Select(tail => letter + tail));
                    letters[Constants.Blank]++;
                }
            }
            return result;
        }

        public void Insert(string word)
        {
            if (word.Length == 0)
            {
                isWord = true;
            }
            else
            {
                if (!children.ContainsKey(word[0]))
                {
                    children[word[0]] = new Trie();
                }
                children[word[0]].Insert(word.Substring(1));
            }
        }
    }
}
