using System;
using System.Collections.Generic;
using System.Text;

 
    public static class ExtendMothed
    {
        #region 扩展方法
        public static T ToT<T>(this object str)
        {
            try
            {
                return (T)Convert.ChangeType(str, typeof(T));
            }
            catch
            {
                return default(T);
            }
        }

        #endregion
    }
 
