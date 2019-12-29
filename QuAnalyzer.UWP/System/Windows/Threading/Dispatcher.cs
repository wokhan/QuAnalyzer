namespace System.Windows.Threading
{
    using Uno.UI.Generic;

    public class Dispatcher : Proxy<global::Windows.UI.Xaml.Threading.Dispatcher>
    {
        public static System.Windows.Threading.Dispatcher CurrentDispatcher
        {
            get => __ProxyValue.CurrentDispatcher;
        }

        public System.Threading.Thread Thread
        {
            get => __ProxyValue.Thread;
        }

        public System.Boolean HasShutdownStarted
        {
            get => __ProxyValue.HasShutdownStarted;
        }

        public System.Boolean HasShutdownFinished
        {
            get => __ProxyValue.HasShutdownFinished;
        }

        public System.Windows.Threading.DispatcherHooks Hooks
        {
            get => __ProxyValue.Hooks;
        }

        public static System.Windows.Threading.Dispatcher FromThread(System.Threading.Thread thread) => Windows.UI.Xaml.Threading.Dispatcher.FromThread(@thread);
        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
        public void BeginInvokeShutdown(System.Windows.Threading.DispatcherPriority priority) => __ProxyValue.BeginInvokeShutdown(@priority);
        public void InvokeShutdown() => __ProxyValue.InvokeShutdown();
        public void add_ShutdownStarted(System.EventHandler value) => __ProxyValue.add_ShutdownStarted(@value);
        public void remove_ShutdownStarted(System.EventHandler value) => __ProxyValue.remove_ShutdownStarted(@value);
        public void add_ShutdownFinished(System.EventHandler value) => __ProxyValue.add_ShutdownFinished(@value);
        public void remove_ShutdownFinished(System.EventHandler value) => __ProxyValue.remove_ShutdownFinished(@value);
        public static void Run() => Windows.UI.Xaml.Threading.Dispatcher.Run();
        public static void PushFrame(System.Windows.Threading.DispatcherFrame frame) => Windows.UI.Xaml.Threading.Dispatcher.PushFrame(@frame);
        public static void ExitAllFrames() => Windows.UI.Xaml.Threading.Dispatcher.ExitAllFrames();
        public static System.Windows.Threading.DispatcherPriorityAwaitable Yield() => Windows.UI.Xaml.Threading.Dispatcher.Yield();
        public static System.Windows.Threading.DispatcherPriorityAwaitable Yield(System.Windows.Threading.DispatcherPriority priority) => Windows.UI.Xaml.Threading.Dispatcher.Yield(@priority);
        public System.Windows.Threading.DispatcherOperation BeginInvoke(System.Windows.Threading.DispatcherPriority priority, System.Delegate method) => __ProxyValue.BeginInvoke(@priority, @method);
        public System.Windows.Threading.DispatcherOperation BeginInvoke(System.Windows.Threading.DispatcherPriority priority, System.Delegate method, System.Object arg) => __ProxyValue.BeginInvoke(@priority, @method, @arg);
        public System.Windows.Threading.DispatcherOperation BeginInvoke(System.Windows.Threading.DispatcherPriority priority, System.Delegate method, System.Object arg, System.Object[] args) => __ProxyValue.BeginInvoke(@priority, @method, @arg, @args);
        public System.Windows.Threading.DispatcherOperation BeginInvoke(System.Delegate method, System.Object[] args) => __ProxyValue.BeginInvoke(@method, @args);
        public System.Windows.Threading.DispatcherOperation BeginInvoke(System.Delegate method, System.Windows.Threading.DispatcherPriority priority, System.Object[] args) => __ProxyValue.BeginInvoke(@method, @priority, @args);
        public void Invoke(System.Action callback) => __ProxyValue.Invoke(@callback);
        public void Invoke(System.Action callback, System.Windows.Threading.DispatcherPriority priority) => __ProxyValue.Invoke(@callback, @priority);
        public void Invoke(System.Action callback, System.Windows.Threading.DispatcherPriority priority, System.Threading.CancellationToken cancellationToken) => __ProxyValue.Invoke(@callback, @priority, @cancellationToken);
        public void Invoke(System.Action callback, System.Windows.Threading.DispatcherPriority priority, System.Threading.CancellationToken cancellationToken, System.TimeSpan timeout) => __ProxyValue.Invoke(@callback, @priority, @cancellationToken, @timeout);
        public TResult Invoke<TResult>(System.Func<TResult> callback) => __ProxyValue.Invoke(@callback);
        public TResult Invoke<TResult>(System.Func<TResult> callback, System.Windows.Threading.DispatcherPriority priority) => __ProxyValue.Invoke(@callback, @priority);
        public TResult Invoke<TResult>(System.Func<TResult> callback, System.Windows.Threading.DispatcherPriority priority, System.Threading.CancellationToken cancellationToken) => __ProxyValue.Invoke(@callback, @priority, @cancellationToken);
        public TResult Invoke<TResult>(System.Func<TResult> callback, System.Windows.Threading.DispatcherPriority priority, System.Threading.CancellationToken cancellationToken, System.TimeSpan timeout) => __ProxyValue.Invoke(@callback, @priority, @cancellationToken, @timeout);
        public System.Windows.Threading.DispatcherOperation InvokeAsync(System.Action callback) => __ProxyValue.InvokeAsync(@callback);
        public System.Windows.Threading.DispatcherOperation InvokeAsync(System.Action callback, System.Windows.Threading.DispatcherPriority priority) => __ProxyValue.InvokeAsync(@callback, @priority);
        public System.Windows.Threading.DispatcherOperation InvokeAsync(System.Action callback, System.Windows.Threading.DispatcherPriority priority, System.Threading.CancellationToken cancellationToken) => __ProxyValue.InvokeAsync(@callback, @priority, @cancellationToken);
        public System.Windows.Threading.DispatcherOperation<TResult> InvokeAsync<TResult>(System.Func<TResult> callback) => __ProxyValue.InvokeAsync(@callback);
        public System.Windows.Threading.DispatcherOperation<TResult> InvokeAsync<TResult>(System.Func<TResult> callback, System.Windows.Threading.DispatcherPriority priority) => __ProxyValue.InvokeAsync(@callback, @priority);
        public System.Windows.Threading.DispatcherOperation<TResult> InvokeAsync<TResult>(System.Func<TResult> callback, System.Windows.Threading.DispatcherPriority priority, System.Threading.CancellationToken cancellationToken) => __ProxyValue.InvokeAsync(@callback, @priority, @cancellationToken);
        public System.Object Invoke(System.Windows.Threading.DispatcherPriority priority, System.Delegate method) => __ProxyValue.Invoke(@priority, @method);
        public System.Object Invoke(System.Windows.Threading.DispatcherPriority priority, System.Delegate method, System.Object arg) => __ProxyValue.Invoke(@priority, @method, @arg);
        public System.Object Invoke(System.Windows.Threading.DispatcherPriority priority, System.Delegate method, System.Object arg, System.Object[] args) => __ProxyValue.Invoke(@priority, @method, @arg, @args);
        public System.Object Invoke(System.Windows.Threading.DispatcherPriority priority, System.TimeSpan timeout, System.Delegate method) => __ProxyValue.Invoke(@priority, @timeout, @method);
        public System.Object Invoke(System.Windows.Threading.DispatcherPriority priority, System.TimeSpan timeout, System.Delegate method, System.Object arg) => __ProxyValue.Invoke(@priority, @timeout, @method, @arg);
        public System.Object Invoke(System.Windows.Threading.DispatcherPriority priority, System.TimeSpan timeout, System.Delegate method, System.Object arg, System.Object[] args) => __ProxyValue.Invoke(@priority, @timeout, @method, @arg, @args);
        public System.Object Invoke(System.Delegate method, System.Object[] args) => __ProxyValue.Invoke(@method, @args);
        public System.Object Invoke(System.Delegate method, System.Windows.Threading.DispatcherPriority priority, System.Object[] args) => __ProxyValue.Invoke(@method, @priority, @args);
        public System.Object Invoke(System.Delegate method, System.TimeSpan timeout, System.Object[] args) => __ProxyValue.Invoke(@method, @timeout, @args);
        public System.Object Invoke(System.Delegate method, System.TimeSpan timeout, System.Windows.Threading.DispatcherPriority priority, System.Object[] args) => __ProxyValue.Invoke(@method, @timeout, @priority, @args);
        public System.Windows.Threading.DispatcherProcessingDisabled DisableProcessing() => __ProxyValue.DisableProcessing();
        public static void ValidatePriority(System.Windows.Threading.DispatcherPriority priority, System.String parameterName) => Windows.UI.Xaml.Threading.Dispatcher.ValidatePriority(@priority, @parameterName);
        public void add_UnhandledExceptionFilter(System.Windows.Threading.DispatcherUnhandledExceptionFilterEventHandler value) => __ProxyValue.add_UnhandledExceptionFilter(@value);
        public void remove_UnhandledExceptionFilter(System.Windows.Threading.DispatcherUnhandledExceptionFilterEventHandler value) => __ProxyValue.remove_UnhandledExceptionFilter(@value);
        public void add_UnhandledException(System.Windows.Threading.DispatcherUnhandledExceptionEventHandler value) => __ProxyValue.add_UnhandledException(@value);
        public void remove_UnhandledException(System.Windows.Threading.DispatcherUnhandledExceptionEventHandler value) => __ProxyValue.remove_UnhandledException(@value);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}