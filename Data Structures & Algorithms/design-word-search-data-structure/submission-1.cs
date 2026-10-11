public class WordDictionary {
    private TrieNode root;

    public WordDictionary() {
        root = new TrieNode('.', false);
    }

    public void AddWord(string word) {
        if (word.Length == 0) {
            return;
        }

        var node = root;

        for (var i = 0; i < word.Length; i++) {
            if (!node.HasChild(word[i])) {
                node.AddChild(word[i], i == word.Length - 1);
            }
            node = node.GetChild(word[i]);
        }

        node.eof = true;
    }

    public bool Search(string word) {
        if (word.Length == 0) {
            return false;
        }

        return this.Search(root, word, 0);
    }

    public bool Search(TrieNode node, string word, int idx) {
        if (node == null)
        {
            return false;
        }

        if (node.eof && idx == word.Length) {
            return true;
        }

        if (idx == word.Length)
        {
            return false;
        }

        if (word[idx] != '.') {
            return node.HasChild(word[idx]) && this.Search(node.GetChild(word[idx]), word, idx + 1);
        }

        var found = false;
        for (var i = 0; i < node.children.Length; i++) {
            found = found || this.Search(node.children[i], word, idx + 1);
        }

        return found;
    }
}

// handle prefix by .? or suffix pointing to root?
// handling by . will add memory overhead of adding every combination to the trie
// for bay - we add bay, .ay, b.y, ba., b.., .a., ..y, ... - n ^ n - 1
// instead we can point suffixes to the root and when searching we effectively skip on .
// however gotta be careful on matching word to suffix
// if we point suffix ay to root - without check can match on word ay but shouldn't
// vice versa .ay shouldn't match on real word ay.
// but a node can be both - word and suffix ex) bay ay y can all be in dictionary
// with bool start we can denote a node as a starting character, bool suffix as a suffix so it's not
// either or with bay and ay : b! - a - y, a!? - y

// b e a t
// b! e a t, b! a t, b! e t b! t, e a t, e t

// just recursively expand search space since we are limited to english characters
public class TrieNode {
    public char val;

    public TrieNode[] children = new TrieNode[26];  // last for . to denote prefix

    public bool eof;

    public TrieNode(char val, bool eof) {
        this.val = val;
        this.eof = eof;
    }

    public void AddChild(char val, bool eof) {
        var child = new TrieNode(val, eof);

        children[val - 97] = child;
    }

    public TrieNode GetChild(char val) {
        return this.children[val - 97];
    }

    public bool HasChild(char val) {
        return this.children[val - 97] != null;
    }
}