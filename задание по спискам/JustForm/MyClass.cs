using System;
using System.Windows.Forms;

namespace JustForm
{
    class MyClass<T> : IComparable
    {
        int val1;
        bool val2;
        string val3;

        public MyClass(T val)
        {
            if (val.GetType() == val1.GetType())
            {
                val1 = int.Parse(val.ToString());
            }
            else if (val.GetType() == val2.GetType())
            {
                val2 = Convert.ToBoolean(val);
            }
            else if (val.GetType() == val3.GetType())
            {
                val3 = Convert.ToString(val);
            }
        }

        public override string ToString()
        {
            if(typeof(T) == typeof(int))
            {
                return val1.ToString();
            }
            if (typeof(T) == typeof(bool))
            {
                return val2.ToString();
            }
            if (typeof(T) == typeof(string))
            {
                return val3;
            }
            return "";
        }

        public void set(int val)
        {
            val1 = val;
        }

        public void set(bool val)
        {
            val2 = val;
        }

        public void set(string val)
        {
            val3 = val;
        }

        public static implicit operator int(MyClass<T> s) {
            return s.val1;
        }

        public static implicit operator bool(MyClass<T> s)
        {
            return s.val2;
        }

        public static implicit operator string(MyClass<T> s)
        {
            return s.val3;
        }

        public int CompareTo(object obj)
        {
            if(typeof(T) == typeof(int))
            {
                return val1.CompareTo((MyClass<T>)obj);
            }
            else if (typeof(T) == typeof(bool))
            {
                return val2.CompareTo((MyClass<T>)obj);
            }
            else if (typeof(T) == typeof(string))
            {
                return val3.CompareTo((MyClass<T>)obj);
            }
            return 0;
        }

        public override bool Equals(object value)
        {
            if (typeof(T) == typeof(int))
            {
                return val1.Equals((MyClass<T>)value);
            }
            else if (typeof(T) == typeof(bool))
            {
                return val2.Equals((MyClass<T>)value);
            }
            else if (typeof(T) == typeof(string))
            {
                return val3.Equals((MyClass<T>)value);
            }
            return false;
        }
    }
}
