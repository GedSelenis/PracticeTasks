using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTasks.Models
{
    public class TernarySearchTreeDictionary
    {
        private Node root;

        public TernarySearchTreeDictionary()
        {
            root = null;
        }

        public void Insert(string key,string value)
        {
            root.Insert(root, key, value);
        }
        public void Insert(Dictionary<string, string> keyValuePairs)
        {
            foreach (var kvp in keyValuePairs)
            {
                root.Insert(root, kvp.Key, kvp.Value);
            }
        }
        public string? Search(string key)
        {
            return root.Search(root, key);
        }
        public string? PartialSearch(string key)
        {
            return root.PartialSearch(root, key);
        }
        private class Node
        {
            string data;
            char key;
            bool isEndOfWord = false;
            public Node left, equal, right;
            
            public Node(string data)
            {
                this.data = data;
                left = equal = right = null;
            }

            public string? Search(Node node,string key)
            {
                if (node == null)
                {
                    return null; // Not found
                }
                if (key[0] < node.key)
                {
                    return Search(node.left, key);
                }
                else if (key[0] > node.key)
                {
                    return Search(node.right, key);
                }
                else
                {
                    if (key.Length == 1)
                    {
                        return node.isEndOfWord ? node.data : null; // Found or not found
                    }
                    return Search(node.equal, key.Substring(1));
                }
            }

            public string? PartialSearch(Node node, string key)
            {
                if (node == null)
                {
                    return null; // Not found
                }
                
                if (key[0] == node.key)
                {
                    if (key.Length == 1)
                    {
                        return node.data; // Found
                    }
                    return PartialSearch(node.equal, key.Substring(1));
                }
                else
                {
                    string? leftResult = PartialSearch(node.left, key);
                    string? rightResult = PartialSearch(node.right, key);
                    if (leftResult != null)
                    {
                        return leftResult; // Found in left subtree
                    }
                    else if (rightResult != null)
                    {
                        return rightResult; // Found in right subtree
                    }
                    else
                    {
                        return null; // Not found in either subtree
                    }
                }
            }

            public Node Insert(Node node, string key, string value)
            {
                if (node == null)
                {
                    node = new Node(value);
                    this.key = key[0];
                }
                if (key[0] < node.key)
                {
                    node.left = Insert(node.left, key, value);
                }
                else if (key[0] > node.key)
                {
                    node.right = Insert(node.right, key, value);
                }
                else
                {
                    if (key.Length > 1)
                    {
                        node.equal = Insert(node.equal, key.Substring(1), value);
                    }
                    else
                    {
                        node.isEndOfWord = true;
                        node.data = value;
                    }
                }
                
                return node;
            }
        }
    }
}
