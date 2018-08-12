using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BinarySearchTree : IEnumerable<int>
{
    private int _value;
    private BinarySearchTree _left;
    private BinarySearchTree _right;

    public BinarySearchTree(int value)
    {
        _value = value;
        _left = null;
        _right = null;
    }

    public BinarySearchTree(IEnumerable<int> values)
    {
        _value = values.First();
        _left = null;
        _right = null;

        foreach (int value in values.Skip(1))
        {
            this.Add(value);
        }
    }

    public int Value
    {
        get
        {
            return _value;
        }
    }

    public BinarySearchTree Left
    {
        get
        {
            return _left;
        }
    }

    public BinarySearchTree Right
    {
        get
        {
            return _right;
        }
    }

    public BinarySearchTree Add(int value)
    {
        BinarySearchTree newTree = new BinarySearchTree(value);

        if (value <= this.Value)
        {
            if (this.Left == null) this._left = newTree;
            else this.Left.Add(value);
        }

        else if (value > this.Value)
        {
            if (this.Right == null) this._right = newTree;
            else this.Right.Add(value);
        }

        return this;
    }

    public IEnumerator<int> GetEnumerator()
    {
        if (Left != null)
        {
            foreach (var v in Left) yield return v;
        }

        yield return Value;

        if (Right != null)
        {
            foreach (var v in Right) yield return v;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}