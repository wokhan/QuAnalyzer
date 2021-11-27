
using System.Threading;

using Wokhan.ComponentModel.Extensions;
using Wokhan.Core.ComponentModel;

namespace QuAnalyzer.Core.Helpers;

public class GlobalTask : NotifierHelper
{
    private string title;
    public string Title { get => title; set => this.SetValue(ref title, value, NotifyPropertyChanged); }

    private double? progress;
    public double? Progress { get => progress; set => this.SetValue(ref progress, value, NotifyPropertyChanged); }

    public CancellationTokenSource CancellationTokenSource { get; } = new CancellationTokenSource();
}
