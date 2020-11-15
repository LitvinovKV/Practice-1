using System.Threading;

namespace DevelopmentSystemTest.ThreadClasses
{
    public interface IThreadRunnable
    {
        EventWaitHandle WaitHandle { get; }
        void Run();
    }
}
