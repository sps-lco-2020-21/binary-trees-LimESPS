using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace BinaryTrees.Lib
{
    public class TreeList
    {
        Node headnode;

        public TreeList()
        {
            headnode = null;
        }
        public TreeList(int v)
        {
            headnode = new Node(v);
        }
        public void Add(int v)
        {
            if (headnode == null)
                headnode = new Node(v);
            else
                headnode.Add(v);
        }
        public bool check(int v)
        {
            if (headnode == null)
            {
                Console.WriteLine("Empty");
                return false;
            }
            else if(headnode.value == v)
            {
                return true;
            }
            else
                return headnode.check(v);
        }
        public int depth()
        {
            if (headnode == null)
                return 0;
            else
                return headnode.depth(0);
        }
        public void delete(int val)
        {
            if (headnode == null)
                Console.WriteLine("Empty");
            else
                headnode.delete(val);
        }
    }
    public class Node
    {
        Node right; //larger than or equal to
        Node left;
        public int value;
        public Node(int v)
        {
            right = null;
            left = null;
            value = v;
        }
        public void Add(int v)
        {
            if (v < value) //left
            {
                if (left == null)
                    left = new Node(v);
                else
                    left.Add(v);

            }
            else if(v >= value) //right
            {
                if (right == null)
                    right = new Node(v);
                else
                    right.Add(v);
            }

        }
        public bool check(int v)
        {
            if (value == v)
                return true;
            if(v< value)
            {
                if (left == null)
                {
                    if (value == v)
                        return true;
                    else
                        return false;
                }
                else
                    return left.check(v);
            }
            else
            {
                
                if (right == null)
                {
                    if (value == v)
                        return true;
                    else
                        return false;
                }
                else
                    return right.check(v);
            }
                
        }
        public void delete(int val) //finds location of Node with this value
        {
            if(left.value == val)
            {
                if(left.right == null && left.left == null) //no children
                {
                    left = null;
                }
                if(left.right != null && left.left != null) //both children
                {
                    delete_two(this, "two",this);
                }
                else //one child
                {
                    if (left.left != null && left.right == null)
                    {
                        this.right = right.left;
                        right = null;
                    }
                    else if (left.left == null && left.right != null)
                    {
                        this.right = right.right;
                        right = null;
                    }
                    else
                        Debug.Assert(false, "function for one child does not work");
                }
            }
            if(right.value == val)
            {
                if (right.right == null && right.left == null) //no children
                {
                    right = null;
                }
                if (right.right != null && right.right != null) //both children
                {
                    delete_two(this, "two", this);
                }
                else //one child
                {
                    if (right.left != null && right.right == null)
                    {
                        
                        this.right = right.left;
                        right = null;
                    }
                    else if (right.left == null && right.right != null)
                    {
                        this.right = right.right;
                        right = null;
                    }
                    else
                        Debug.Assert(false, "function for one child does not work");
                }
            }
            if (val < value)
            {
                if(left == null)
                {
                    Console.WriteLine("Cannot be found");
                }
                else
                {
                    left.delete(val);
                }
            }
            else if(val >= value)
            {
                if (right == null)
                {
                    Console.WriteLine("Cannot be found");
                }
                else
                    right.delete(val);
            }
        }
        
        
        public void delete_two(Node n,string s,Node stored)
        {
            if(s == "two")
            {
                if (n.left != null)
                    delete_two(n.left, "two", stored);
                else 
                {
                    stored.left = n.left;
                    n.left = null;
                }    

            }
            if(s == "oneS")
            {
                stored.left = stored.left.left;
                stored.left = null;
            }
            if(s == "oneB")
            {
                stored.right = stored.right.right;
                stored.right = null;
            }
        }
        public void remove(Node n) //actually removes node
        {
            
        }
        public int depth(int count)
        {
            return 1;
        }
    }
    
}
