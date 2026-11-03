using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Forms;

namespace UI.Extensions
{
    public static class LoadingExtensions
    {
        public static async Task<T> WithLoading<T>(
            this Form owner,
            Func<CancellationToken, Task<T>> operation,
            string message = "...انتظر قليلا")
        {
            if (owner == null)
                throw new ArgumentNullException(nameof(owner));

            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            using (var cts = new CancellationTokenSource())
            using (var form = new LoadingForm(cts, message))
            {
                Task<T> operationTask = operation(cts.Token);

                await Task.WhenAny(
                    operationTask,
                    Task.Delay(100));

                if (operationTask.IsCompleted)
                    return await operationTask;

                form.Shown += async (s, e) =>
                {
                    try { await operationTask; }
                    finally
                    {
                        if (!form.IsDisposed)
                            form.CloseAfterOperation();
                    }
                };

                form.ShowDialog(owner);

                return await operationTask;
            }
        }
    }
}