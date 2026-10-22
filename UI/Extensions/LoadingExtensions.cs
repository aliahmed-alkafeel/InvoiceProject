using System;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Forms;

namespace UI.Extensions
{
    public static class LoadingExtensions
    {
        public static T WithLoading<T>(
            this Form owner,
            Func<CancellationToken, Task<T>> operation,
            string message = "Please wait...")
        {
            using (var cts = new CancellationTokenSource())
            using (var form = new LoadingForm(cts, message))
            {
                T result = default(T);
                Exception error = null;
                bool cancelled = false;

                form.Shown += async (s, e) =>
                {
                    try
                    {
                        // Task.Run حتى لا يتجمد الفورم إذا كان في الـ operation جزء متزامن
                        result = await Task.Run(() => operation(cts.Token));
                    }
                    catch (OperationCanceledException) when (cts.IsCancellationRequested)
                    {
                        cancelled = true;
                    }
                    catch (Exception ex)
                    {
                        error = ex;
                    }
                    finally
                    {
                        form.CloseAfterOperation();
                    }
                };

                form.ShowDialog(owner);

                if (cancelled)
                    throw new OperationCanceledException();

                if (error != null)
                    ExceptionDispatchInfo.Capture(error).Throw();

                return result;
            }
        }
    }
}