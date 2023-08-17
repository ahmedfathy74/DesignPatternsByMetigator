namespace Singleton.ThreadSafeUsingLock
{
    public class MemoryLogger
    {
        private int _InfoCount;
        private int _WarningCount;
        private int _ErrorCount;

        private static MemoryLogger _instance = null;
        private static readonly object _lock = new object();    


        private List<LogMessage> _logs = new List<LogMessage>();
        public IReadOnlyCollection<LogMessage> Logs => _logs;

        private  MemoryLogger()
        {
                
        }

        public static MemoryLogger GetLogger
        {
            get
            {
                /* Only one check*/
                // make only one thread to be used and no other threads will be go in the lock keyword.
                // doing sync for every thread ---> T1,T2
                /*
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new MemoryLogger();
                    }
                    return _instance;
                }*/
                /* Double Check*/
                // we can improve that by making Double Check throw enhance the previous code 
                // because we have an case when i entered and when instance is already have value why i am waiting the lock so
                // we we can check first about if instance is null or not 
                //T1, T2
                if(_instance is null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new MemoryLogger();
                        }
                    }
                }
                return _instance;
               
            }
        }

        private void Log(string message, LogType logType)
        {
            _logs.Add(new LogMessage
            {
                Message = message,
                LogType = logType,
                CreatedAt = DateTime.Now
            });
        }

        public void LogInfo(string message)
        {
            ++_InfoCount;
            Log(message, LogType.INFO);
        }
        public void LogError(string message)
        {
            ++_ErrorCount;
            Log(message, LogType.ERROR);
        }
        public void LogWarning(string message)
        {
            ++_WarningCount;
            Log(message, LogType.WARNING);
        }

        public void ShowLog()
        {

            _logs.ForEach(x => Console.WriteLine(x));
            Console.WriteLine($"-------------------------------");

            Console.WriteLine($"Info ({_InfoCount}), Warning ({_WarningCount}), Error ({_ErrorCount})");
        }

    }
}
