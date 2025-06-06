﻿class AVL<T> where T : IComparable
{
    Node root;
    public class Node
    {
        public T item;
        public Node right;
        public Node left;
        public int height;
    }

    public void Insert(T element)
    {
        var newNode = new Node();
        newNode.item = element;
        newNode.height = 0;
        Node temp = root;
        bool placed = false;
        if (root is null)
        {
            root = newNode;
            return;
        }
        while (!placed)
        {
            if (newNode.item.CompareTo(temp.item) == 1)
            {
                if (temp.right is not null)
                {
                    temp.height = 1 + Math.Max(temp.right.height, temp.left.height);
                    temp = temp.right;
                }
                else
                {
                    temp.right = newNode;
                    placed = true;
                }
            }
            else
            {
                if (temp.left is not null)
                {
                    temp.height = 1 + Math.Max(temp.right.height, temp.left.height);
                    temp = temp.left; 
                }
                else
                {
                    temp.left = newNode;
                    placed = true;
                }
            }

        }
    }
    public bool Contains(T element)
    {
        Node temp = root;
        while (temp is not null)
        {
            if (element.CompareTo(temp.item) == 0)
            {
                return true;
            }
            else if (element.CompareTo(temp.item) == 1)
            {
                temp = temp.right;
            }
            else
            {
                temp = temp.left;
            }
        }
        return false;
    }
    public void Delete(T element)
    {
        Node temp = root;
        Node parentTemp = null;
        while (true)
        {
            if (element.CompareTo(temp.item) == 0)
            {
                break;
            }
            else if (element.CompareTo(temp.item) == 1)
            {
                if (temp.right is null)
                    throw new Exception("This element isn't exist");
                parentTemp = temp;
                temp = temp.right;
            }
            else
            {
                if (temp.left is null)
                    throw new Exception("This element isn't exist");
                parentTemp = temp;
                temp = temp.left;
            }
        }
        if (temp.right is null && temp.left is null)
        {
            if (temp == root)
                root = null;
            else if (parentTemp.left == temp)
                parentTemp.left = null;
            else
                parentTemp.right = null;
        }
        else if (temp.left is null)
        {
            if (temp == root)
                root = temp.right;
            else if (parentTemp.left == temp)
                parentTemp.left = temp.right;
            else
                parentTemp.right = temp.right;
        }
        else if (temp.right is null)
        {
            if (temp == root)
                root = temp.left;
            else if (parentTemp.left == temp)
                parentTemp.left = temp.left;
            else
                parentTemp.right = temp.left;
        }
        else
        {
            Node successor = temp.right;
            Node parentSuccessor = temp;

            while (successor.left != null)
            {
                parentSuccessor = successor;
                successor = successor.left;
            }

            temp.item = successor.item;

            if (parentSuccessor == temp)
                parentSuccessor.right = successor.right;
            else
                parentSuccessor.left = successor.right;

        }
    }


}
