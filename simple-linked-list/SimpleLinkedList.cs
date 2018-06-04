using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SimpleLinkedList<T> : IEnumerable<T>
{
    private T _value;
    private SimpleLinkedList<T> _next;
    private SimpleLinkedList<T> _last;
    private SimpleLinkedList<T> _first;

    public SimpleLinkedList(T value)
    {
        _value = value;
        _next = null;
        _last = this;
        _first = this;
    }

    public SimpleLinkedList(IEnumerable<T> values)
    {
        _value = values.First();
        _next = null;
        _last = this;
        _first = this;

        foreach (var value in values.Skip(1))
        {
            this.Add(value);
        }   
    }

    public T Value 
    { 
        get
        {
            return _value;
        } 
    }

    public SimpleLinkedList<T> Next
    { 
        get
        {
            return _next;
        } 
    }

    public SimpleLinkedList<T> Last
    {
        get
        {
            return _last;
        }
    }

    public SimpleLinkedList<T> First
    {
        get
        {
            return _first;
        }
    }

    public SimpleLinkedList<T> Add(T value)
    {
        SimpleLinkedList<T> newList = new SimpleLinkedList<T>(value);
        this._last._next = newList;
        this._last = newList;
        return this;         
    }

    public IEnumerator<T> GetEnumerator()
    {
        SimpleLinkedList<T> current = First;

        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}