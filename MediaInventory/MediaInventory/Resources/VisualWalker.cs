using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace MediaInventory.Resources
{
    public static class VisualWalker
    {
        #region Static Fields
        static List<DependencyObject> _hitTestResultsList = new List<DependencyObject>();
        static readonly object HitTestLock = new object();
        #endregion
        #region Public Static Methods
        public static T FindTypedChildInVisualTree<T>(DependencyObject parentToSearch)
           where T : DependencyObject
        {
            if (parentToSearch == null)
                return null;
            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(parentToSearch); i++)
            {
                var child = VisualTreeHelper.GetChild(parentToSearch, i);
                if (child != null && child is T)
                    return child as T;
                var recurse = FindTypedChildInVisualTree<T>(child);
                if (recurse != null)
                    return recurse;
            }
            return null;
        }
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj)
            where T : DependencyObject
        {
            if (depObj == null)
                yield break;
            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);
                var typedChild = child as T;
                if (typedChild != null)
                    yield return typedChild;
                foreach (var childOfChild in FindVisualChildren<T>(child))
                    yield return childOfChild;
            }
        }
        public static T FindTypedParentInLogicalTree<T>(DependencyObject childToSearch)
            where T : DependencyObject
        {
            if (childToSearch == null)
                return null;
            var parentType = typeof(T);
            var logicalParent = LogicalTreeHelper.GetParent(childToSearch);
            while (logicalParent != null && parentType.IsAssignableFrom(logicalParent.GetType()) == false)
                logicalParent = LogicalTreeHelper.GetParent(logicalParent);
            return logicalParent as T;
        }
        public static T FindTypedParentInVisualTree<T>(DependencyObject childToSearch)
            where T : DependencyObject
        {
            if (childToSearch == null)
                return null;
            var parentType = typeof(T);
            //If child is already of the search type, return the child
            if (parentType.IsAssignableFrom(childToSearch.GetType()))
                return childToSearch as T;
            var visualParent = VisualTreeHelper.GetParent(childToSearch);
            while (visualParent != null && parentType.IsAssignableFrom(visualParent.GetType()) == false)
                visualParent = VisualTreeHelper.GetParent(visualParent);
            return visualParent as T;
        }
        public static List<DependencyObject> HitTest(Visual visual, Point point)
        {
            lock (HitTestLock)
            {
                _hitTestResultsList = new List<DependencyObject>();
                VisualTreeHelper.HitTest(visual, null, ResultCallback, new PointHitTestParameters(point));
                return _hitTestResultsList;
            }
        }
        #endregion Public Static Methods 
        #region Static Methods
        private static HitTestResultBehavior ResultCallback(HitTestResult result)
        {
            _hitTestResultsList.Add(result.VisualHit);
            return HitTestResultBehavior.Continue;
        }
        #endregion Static Methods 
    }
}