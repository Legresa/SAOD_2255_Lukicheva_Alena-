using System;
using System.Collections;
using System.Collections.Generic;

namespace JustForm
{
    class MyList<T> : IEnumerable, IEnumerator
    {
        public ListNode<T> First, Last;
        int index = -1;

        public object Current => At(index);

        //конструктор
        public MyList()
        {
            First = null;
            Last = null;
        }

        //метод добавления элемента в конец списка
        public void Append(T value)
        {
            if (First != null)
            {
                ListNode<T> n = new ListNode<T>(value);
                Last.next = n;
                n.prev = Last;
                Last = n;
            }
            else
            {
                First = new ListNode<T>(value);
                Last = First;
            }
        }

        //метод добавления элемента в начало списка
        public void Prepend(T value)
        {
            if (First != null)
            {
                ListNode<T> n = new ListNode<T>(value);
                n.next = First;
                First.prev = n;
                First = n;
            }
            else
            {
                First = new ListNode<T>(value);
                Last = First;
            }
        }

        //метод возвращает массив элементов
        public T[] ToArray()
        {
            List<T> arr = new List<T>();
            if (First != null)
            {
                ListNode<T> ptr = First;
                while (ptr != null)
                {
                    arr.Add(ptr.value);
                    ptr = ptr.next;
                }
            }
            return arr.ToArray();
        }

        //метод для поиска элемента в списке
        public T Find(T _value)
        {
            if (First != null)
            {
                ListNode<T> ptr = First;
                while (ptr != null)
                {
                    if (ptr.value.Equals(_value))
                    {
                        return ptr.value;
                    }
                    ptr = ptr.next;
                }
            }
            return default(T);
        }

        //метод для удаления элемента в списке
        public void Remove(T _value)
        {
            if (First != null)
            {
                ListNode<T> ptr = First;
                ListNode<T> prev = ptr;
                while (ptr != null)
                {
                    if (ptr.value.Equals(_value))
                    {
                        break;
                    }
                    else
                    {
                        prev = ptr;
                        ptr = ptr.next;
                    }
                }
                //.
                if (ptr == prev)
                {
                    First = First.next;
                    if (First != null)
                    {
                        First.prev = null;
                    }
                }
                else if (ptr != null)
                {
                    if (ptr.next == null)
                    {
                        Last = prev;
                        Last.next = null;
                    }
                    else
                    {
                        prev.next = ptr.next;
                        ptr.next.prev = prev;
                    }
                }
            }
        }

        //метод для получения элемента по индексу
        public T At(int index)
        {
            if (First != null)
            {
                ListNode<T> ptr = First;
                while (ptr != null && index != 0)
                {
                    index -= 1;
                    ptr = ptr.next;
                }
                if (ptr != null)
                {
                    return ptr.value;
                }
            }
            return default(T);
        }

        //метод для удаления элемента по индексу
        public void RemoveAt(int index)
        {
            if (First != null && index >= 0)
            {
                ListNode<T> ptr = First;
                ListNode<T> prev = ptr;
                while (ptr != null && index != 0)
                {
                    index -= 1;
                    prev = ptr;
                    ptr = ptr.next;
                }
                //голова
                if (ptr == prev)
                {
                    First = First.next;
                    if (First != null)
                    {
                        First.prev = null;
                    }
                }
                else if (ptr != null)
                {
                    if (ptr.next == null)
                    {
                        Last = prev;
                        Last.next = null;
                    }
                    else
                    {
                        prev.next = ptr.next;
                        ptr.next.prev = prev;
                    }
                }
            }
        }

        //получение узла для изменения значения
        protected ListNode<T> Change(int index)
        {
            if (First != null)
            {
                ListNode<T> ptr = First;
                while (ptr != null && index != 0)
                {
                    index -= 1;
                    ptr = ptr.next;
                }
                if (ptr != null)
                {
                    return ptr;
                }
            }
            return null;
        }

        //индексатор
        public T this[int i]
        {
            get => At(i);
            set => Change(i).value = value;
        }

        //размер списка
        public int Size()
        {
            int n = 0;
            if (First != null)
            {
                ListNode<T> ptr = First;
                while (ptr != null)
                {
                    n++;
                    ptr = ptr.next;
                }
            }
            return n;
        }

        //сортировка списка методом слияния
        public void Sort()
        {
            MergeSort(0, Size()-1);
        }

        //сортировка слиянием
        protected void MergeSort(int left, int right)
        {
            int mid;

            if (right > left)
            {
                mid = (right + left) / 2;
                MergeSort(left, mid);
                MergeSort((mid + 1), right);

                Merge(left, (mid + 1), right);
            }
        }

        //слияние
        protected void Merge(int left, int mid, int right)
        {
            T[] temp = new T[25];
            int i, left_end, num_elements, tmp_pos;

            left_end = (mid - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);

            while ((left <= left_end) && (mid <= right))
            {
                var v1 = Change(left);
                var v2 = Change(mid);
                if (Comparer<T>.Default.Compare(v1.value,v2.value) == -1 || v1.value.Equals(v2.value))
                {
                    temp[tmp_pos++] = v1.value;
                    left++;
                }
                else
                {
                    temp[tmp_pos++] = v2.value;
                    mid++;
                }
            }

            while (left <= left_end)
            {
                temp[tmp_pos++] = Change(left).value;
                    left++;
            }

            while (mid <= right)
            {
                temp[tmp_pos++] = Change(mid).value;
                mid++;
            }

            for (i = 0; i < num_elements; i++)
            {
                Change(right).value = temp[right];
                right--;
            }
        }

        //возврат перечислителя
        public IEnumerator GetEnumerator()
        {
            return this;
        }

        //переход на след элемент
        public bool MoveNext()
        {
            if (index == Size()-1)
            {
                Reset();
                return false;
            }
            index++;
            return true;
        }

        //сброс
        public void Reset()
        {
            index = -1;
        }
    }
}
