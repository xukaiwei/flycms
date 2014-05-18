﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Common
{
    public class ValidaterFactory
    {
        public ValidaterFactory(ErrorProvider ep)
        {
            mErrorTip = ep;
        }
        private ErrorProvider mErrorTip;
        private Dictionary<Control, ValidaterInfo> mValidaters = new Dictionary<Control, ValidaterInfo>();
        public void AddValidater(Control control, IValidater validater, string errorTip)
        {

            Type objtype = control.GetType();

            System.ComponentModel.DefaultBindingPropertyAttribute[] dpa
            = (System.ComponentModel.DefaultBindingPropertyAttribute[])control.GetType().GetCustomAttributes(typeof(System.ComponentModel.DefaultBindingPropertyAttribute), true);
            AddValidater(control, validater, errorTip, dpa[0].Name);


        }
        public void AddValidater(Control control, IValidater validater, string errorTip, string property)
        {
            ValidaterInfo info;
            Type objtype = control.GetType();
            PropertyInfo defproperty;
            defproperty = objtype.GetProperty(property);
            info = new ValidaterInfo(defproperty, validater, errorTip);
            mValidaters.Add(control, info);
            control.Validating += new System.ComponentModel.CancelEventHandler(onValidateing);
        }
        public bool IsVali()
        {
            mErrorTip.Clear();
            bool isVali = true;
            bool AllVali = true;
            foreach (Control item in mValidaters.Keys)
            {
                ValidaterInfo info = mValidaters[item];
                object value = info.Property.GetValue(item, null);
                isVali = info.Validater.Validating(value);
                if (!isVali)
                    mErrorTip.SetError(item, info.Message);
                if (!isVali)
                    AllVali = isVali;


            }
            return AllVali;
        }
        private void onValidateing(object source, System.ComponentModel.CancelEventArgs e)
        {

            ValidaterInfo info = mValidaters[(Control)source];
            object value = info.Property.GetValue(source, null);
            bool isVali = info.Validater.Validating(value);
            if (!isVali)
                mErrorTip.SetError((Control)source, info.Message);
            else
                mErrorTip.SetError((Control)source, null);





        }
        class ValidaterInfo
        {
            public ValidaterInfo(PropertyInfo property, IValidater validater,
                string message)
            {
                Property = property;
                Message = message;
                Validater = validater;
            }
            private PropertyInfo mProperty;
            public PropertyInfo Property
            {
                get
                {
                    return mProperty;
                }
                set
                {
                    mProperty = value;
                }
            }
            private string mMessage;
            public string Message
            {
                get
                {
                    return mMessage;
                }
                set
                {
                    mMessage = value;
                }
            }
            private IValidater mValidater;
            public IValidater Validater
            {
                get
                {
                    return mValidater;
                }
                set
                {
                    mValidater = value;
                }
            }
        }
    }
    public interface IValidater
    {
        bool Validating(object value);
    }
    public abstract class ValidaterBase : IValidater
    {
        #region IValidater 成员

        public abstract bool Validating(object value);
        protected T CastValue<T>(object value)
        {
            if (value is IConvertible)
                return (T)System.Convert.ChangeType(value, typeof(T));
            return (T)value;
        }

        #endregion
    }
    public class StringValidater : ValidaterBase
    {
        /// <summary>
        /// 长度验证
        /// </summary>
        /// <param name="min">最小长度</param>
        /// <param name="max">最大长度</param>
        public StringValidater(int min, int max)
        {
            LengthMin = min;
            LengthMax = max;
        }
        /// <summary>
        /// 正则表达式验证
        /// </summary>
        /// <param name="regex">正则表达式</param>
        public StringValidater(string regex)
        {
            RegexString = regex;
        }
        /// <summary>
        /// 非空验证
        /// </summary>
        /// <param name="bl">是否非空验证</param>
        public StringValidater(bool bl)
        {
            NonNull = bl;
        }
        private bool mNonNull = false;
        public bool NonNull
        {
            get
            {
                return mNonNull;
            }
            set
            {
                mNonNull = value;
            }
        }
        private int mLengthMin = int.MinValue;
        public int LengthMin
        {
            get
            {
                return mLengthMin;
            }
            set
            {
                mLengthMin = value;
            }
        }
        private int mLengthMax = int.MinValue;
        public int LengthMax
        {
            get
            {
                return mLengthMax;
            }
            set
            {
                mLengthMax = value;
            }
        }
        private string mRegexString = null;
        public string RegexString
        {
            get
            {
                return mRegexString;
            }
            set
            {
                mRegexString = value;
            }
        }
        #region IValidater 成员
        public override bool Validating(object value)
        {
            string newvalue = null;
            try
            {
                newvalue = CastValue<string>(value);
            }
            catch
            {
                return false;
            }
            if (NonNull)
            {
                if (newvalue == null || newvalue == string.Empty)
                    return false;
            }
            if (LengthMin != int.MinValue)
            {
                if (newvalue.Length < LengthMin)
                    return false;

            }
            if (LengthMax != int.MinValue)
                if (newvalue.Length > LengthMax)
                    return false;
            if (RegexString != null && RegexString != string.Empty)
            {
                if (newvalue == null || newvalue == string.Empty)
                    return false;
                return System.Text.RegularExpressions.Regex.IsMatch(newvalue, RegexString, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            }
            return true;
        }

        #endregion
    }
    public class SturctValidater<T> : ValidaterBase where T : struct, IComparable
    {
        public SturctValidater(T min, T max)
        {
            Min = min;
            Max = max;
        }
        private T mMax = default(T);
        public T Max
        {
            get
            {
                return mMax;
            }
            set
            {
                mMax = value;
            }
        }
        private T mMin = default(T);
        public T Min
        {
            get
            {
                return mMin;
            }
            set
            {
                mMin = value;
            }
        }
        #region IValidater 成员

        public override bool Validating(object value)
        {
            T newvalue;
            try
            {
                newvalue = CastValue<T>(value);
            }
            catch
            {
                return false;
            }

            if (Min.CompareTo(default(T)) > 0)
            {
                if (newvalue.CompareTo(Min) < 0)
                    return false;
            }
            if (Max.CompareTo(default(T)) > 0)
            {
                if (newvalue.CompareTo(Max) > 0)
                {
                    return false;
                }
            }
            return true;

        }

        #endregion
    }
}
