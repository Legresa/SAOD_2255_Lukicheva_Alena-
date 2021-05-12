using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JustForm
{
    class ListNode<T>
    {
        public T value;
        public ListNode<T> next;
        public ListNode<T> prev;

        //конструктор
        public ListNode(T _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }
}
