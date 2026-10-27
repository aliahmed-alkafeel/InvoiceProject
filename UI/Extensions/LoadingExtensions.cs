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
            string message = "Please wait...")
        {
            if (owner == null)
                throw new ArgumentNullException(nameof(owner));

            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            using (var cts = new CancellationTokenSource())
            using (var form = new LoadingForm(cts, message))
            {
                // Start the operation immediately.
                Task<T> operationTask = operation(cts.Token);

                // Wait up to 100 milliseconds before showing the loading form.
                await Task.WhenAny(
                    operationTask,
                    Task.Delay(100));

                // If the operation has already completed,
                // return its result without showing the loading form.
                if (operationTask.IsCompleted)
                    return await operationTask;

                // The operation is still running.
                // Close the loading form when the operation finishes.
                form.Shown += async (s, e) =>
                {
                    try
                    {
                        await operationTask;
                    }
                    catch (Exception)
                    {
                        // The exception will be propagated below.
                    }
                    finally
                    {
                        if (!form.IsDisposed)
                            form.CloseAfterOperation();
                    }
                };

                // Show the loading form only when the delay has elapsed
                // and the operation is still running.
                if (operationTask.IsCompleted)
                    return await operationTask;

                form.ShowDialog(owner);

                // Return the result or propagate the exception/cancellation.
                return await operationTask;
            }
        }
    }
}