using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuartzNetExample
{
    public class ConcurrentJob : IJob
    {
        public void PrintConsole()
        {
            Console.WriteLine("Before");
            Thread.Sleep(2000);
            Console.WriteLine("After");
        }

        async Task IJob.Execute(IJobExecutionContext context)
        {
            PrintConsole();
        }
    }

    [DisallowConcurrentExecution]
    public class SequentialJob : IJob
    {
        public void PrintConsole()
        {
            Console.WriteLine("Before");
            Thread.Sleep(2000);
            Console.WriteLine("After");
        }

        async Task IJob.Execute(IJobExecutionContext context)
        {
            PrintConsole();
        }
    }

    public class QuartzExample
    {
        public static void Example1_一般版()
        {
            // 建立簡單的、以 RAM 為儲存體的排程器
            var schedular = StdSchedulerFactory.GetDefaultScheduler().Result;

            // 建立工作
            IJobDetail job = JobBuilder.Create<ConcurrentJob>()
                                .WithIdentity("SendMailJob")
                                .Build();

            // 建立觸發器
            ITrigger trigger = TriggerBuilder.Create()
                                    .WithCronSchedule("* * * ? * * ")  // 每秒觸發一次。
                                    .WithIdentity("123")
                                    .Build();

            // 把工作加入排程
            schedular.ScheduleJob(job, trigger); ;

            // 啟動排程器
            schedular.Start();
        }

        public static void Example2_一般版_等前一個做完()
        {
            // 建立簡單的、以 RAM 為儲存體的排程器
            var schedular = StdSchedulerFactory.GetDefaultScheduler().Result;

            // 建立工作
            IJobDetail job = JobBuilder.Create<SequentialJob>()
                                .WithIdentity("SendMailJob")
                                .Build();

            // 建立觸發器
            ITrigger trigger = TriggerBuilder.Create()
                                    .WithCronSchedule("* * * ? * * ")  // 每秒觸發一次。
                                    .WithIdentity("123")
                                    .Build();

            // 把工作加入排程
            schedular.ScheduleJob(job, trigger); ;

            // 啟動排程器
            schedular.Start();
        }
    }
}
