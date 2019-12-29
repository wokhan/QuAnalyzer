namespace System.Windows.Interop
{
    using Uno.UI.Generic;

    public class DynamicScriptObject : Proxy<global::Windows.UI.Xaml.Interop.DynamicScriptObject>
    {
        public System.Boolean TryInvokeMember(System.Dynamic.InvokeMemberBinder binder, System.Object[] args, out System.Object result) => __ProxyValue.TryInvokeMember(@binder, @args, @result);
        public System.Boolean TryGetMember(System.Dynamic.GetMemberBinder binder, out System.Object result) => __ProxyValue.TryGetMember(@binder, @result);
        public System.Boolean TrySetMember(System.Dynamic.SetMemberBinder binder, System.Object value) => __ProxyValue.TrySetMember(@binder, @value);
        public System.Boolean TryGetIndex(System.Dynamic.GetIndexBinder binder, System.Object[] indexes, out System.Object result) => __ProxyValue.TryGetIndex(@binder, @indexes, @result);
        public System.Boolean TrySetIndex(System.Dynamic.SetIndexBinder binder, System.Object[] indexes, System.Object value) => __ProxyValue.TrySetIndex(@binder, @indexes, @value);
        public System.Boolean TryInvoke(System.Dynamic.InvokeBinder binder, System.Object[] args, out System.Object result) => __ProxyValue.TryInvoke(@binder, @args, @result);
        public override System.String ToString() => __ProxyValue.ToString();
        public System.Boolean TryDeleteMember(System.Dynamic.DeleteMemberBinder binder) => __ProxyValue.TryDeleteMember(@binder);
        public System.Boolean TryConvert(System.Dynamic.ConvertBinder binder, out System.Object result) => __ProxyValue.TryConvert(@binder, @result);
        public System.Boolean TryCreateInstance(System.Dynamic.CreateInstanceBinder binder, System.Object[] args, out System.Object result) => __ProxyValue.TryCreateInstance(@binder, @args, @result);
        public System.Boolean TryBinaryOperation(System.Dynamic.BinaryOperationBinder binder, System.Object arg, out System.Object result) => __ProxyValue.TryBinaryOperation(@binder, @arg, @result);
        public System.Boolean TryUnaryOperation(System.Dynamic.UnaryOperationBinder binder, out System.Object result) => __ProxyValue.TryUnaryOperation(@binder, @result);
        public System.Boolean TryDeleteIndex(System.Dynamic.DeleteIndexBinder binder, System.Object[] indexes) => __ProxyValue.TryDeleteIndex(@binder, @indexes);
        public System.Collections.Generic.IEnumerable<System.String> GetDynamicMemberNames() => __ProxyValue.GetDynamicMemberNames();
        public System.Dynamic.DynamicMetaObject GetMetaObject(System.Linq.Expressions.Expression parameter) => __ProxyValue.GetMetaObject(@parameter);
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}