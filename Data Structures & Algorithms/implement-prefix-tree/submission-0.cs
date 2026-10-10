public class PrefixTree {

    TreeNode root;

    public PrefixTree() {
        root = new TreeNode();
    }
    
    public void Insert(string word) {
        if (word.Length == 0)
        {
            return;
        }
        
        var node = this.root;
        for (var i = 0; i < word.Length; i++)
        {
            if (!node.HasChild(word[i]))
            {
                node.AddChild(word[i], i == word.Length - 1);
            }

            node = node.GetChild(word[i]);
        }
        node.eof = true;
    }
    
    public bool Search(string word) {
        if (word.Length == 0)
        {
            return false;
        }

        var node = root;
        for (var i = 0; i < word.Length; i++)
        {
            if (!node.HasChild(word[i]))
            {
                return false;
            }

            node = node.GetChild(word[i]);
        }

        return node.eof;
    }
    
    public bool StartsWith(string prefix) {
        if (prefix.Length == 0)
        {
            return false;
        }

        var node = root;
        for (var i = 0; i < prefix.Length; i++)
        {
            if (!node.HasChild(prefix[i]))
            {
                return false;
            }

            node = node.GetChild(prefix[i]);
        }

        return true;
    }
}

public class TreeNode
{
    public char val;

    // since we are only handling lower case english letters, use array
    TreeNode[] children;

    public bool eof;

    public TreeNode()
    {
        this.val = (char)32;
        this.children = new TreeNode[26];
        this.eof = false;
    }

    public TreeNode(char val, bool eof)
    {
        this.val = val;
        this.eof = eof;
        this.children = new TreeNode[26];
    }

    public void AddChild(char val, bool eof)
    {
        var node = new TreeNode(val, eof);
        this.children[val - 97] = node;
    }

    public bool HasChild(char val)
    {
        return this.children[val - 97] != null;
    }

    public TreeNode GetChild(char val)
    {
        return this.children[val - 97];
    }
}