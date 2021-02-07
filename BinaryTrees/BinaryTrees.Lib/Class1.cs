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
                return headnode.depth();
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
                else if(left.right != null && left.left != null) //both children
                {
                    //delete_two(left.right,this,"left",left);
                    if (left.right.left == null)
                    {
                        left.right.left = left.left;
                        left = left.right;
                    }
                    else
                    {
                    Node tempNode = findMin(left.right);
                    tempNode.right = left.right;
                    tempNode.left = left.left;
                    left = tempNode;
                    }
                }
                else //one child
                {
                    if (left.left != null && left.right == null)
                    {
                        left = left.left;
                        //left.left = null;
                    }
                    else if (left.left == null && left.right != null)
                    {
                        left = left.right;
                        //left.right = null;
                    }
                    else
                        Debug.Assert(false, "function for one child does not work");
                }
            }
            else if(right.value == val)
            {
                if (right.right == null && right.left == null) //no children
                {
                    right = null;
                }
                if (right.right != null && right.left != null) //both children
                {
                    //delete_two(right.right, this,"right",right);
                    if (right.right.left == null) //same as left function however i have not run unit test for this, should work
                    {
                        right.right.left = left.left;
                        right = right.right;
                    }
                    else
                    {
                        Node tempNode = findMin(right.right);
                        tempNode.right = right.right;
                        tempNode.left = right.left;
                        right = tempNode;
                    }
                }
                else //one child
                {
                    if (right.left != null && right.right == null)
                    {
                        
                        right = right.left;
                        //right.left = null; this ends up deleting the left value of my new node, how do you delete the pointer of the deleted node? as the deleted node still points to a value
                    }
                    else if (right.left == null && right.right != null)
                    {
                        right = right.right;
                        //right.right = null;
                    }
                    else
                        Debug.Assert(false, "function for one child does not work");
                }
            }
            else if (val < value)
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
        public Node findMin(Node entry)
        {
            if (entry.left != null)
            {
                return findMin(entry.left);
            }
            else
                return entry;
        }
        public void delete_two(Node n,Node constant,string pointer,Node delete)
        {
            if (n.left != null)
                delete_two(n.left, constant,pointer,delete);
            else
            {
                if(pointer == "right")
                {
                    n.left = delete.left;
                    n.right = delete.right;
                    constant.right = n; //havent completely disconnected deleted node, (deleted node still points to )
                    delete.left = null;
                    delete.right = null;
                }
                else if(pointer == "left")
                {
                    n.right = delete.right;
                    n.left = delete.left;
                    constant.left = n;
                    delete.left = null;
                    delete.right = null;
                }
            }
        }
       
       
        public int depth()
        {
            int rightdepth = right_depth(1);
            int leftdepth = left_depth(1);
            if (rightdepth > leftdepth)
                return rightdepth;
            else
                return leftdepth;
        }

        public int left_depth(int count)
        {
            if (left != null)
                return left.left_depth(count + 1);
            else if (right != null)
                return right.left_depth(count + 1);
            else
                return count;
        }

        public int right_depth(int count)
        {
            if (right != null)
                return right.right_depth(count + 1);
            else if (left != null)
                return left.right_depth(count + 1);
            else
                return count;
        }
    }
    
}
