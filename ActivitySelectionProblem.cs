using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class ActivitySelectionProblem
    {
        public class Activity
        {
            public int StartTime { get; set; }
            public int EndTime { get; set; }
            public string Name { get; set; }
        }

        public static List<Activity> MaxActivities(Activity[] activities)
        {
            // Sắp xếp các hoạt động theo thời gian kết thúc tăng dần
            Array.Sort(activities, (a, b) => a.EndTime.CompareTo(b.EndTime));

            int n = activities.Length;
            int count = 1;
            int prevEndTime = activities[0].EndTime;
            List<Activity> selectedActivities = new List<Activity> { activities[0] };

            for (int i = 1; i < n; i++)
            {
                if (activities[i].StartTime >= prevEndTime)
                {
                    count++;
                    prevEndTime = activities[i].EndTime;
                    selectedActivities.Add(activities[i]);
                }
            }

            return selectedActivities;
        }

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Activity[] activities = new Activity[]
            {
            new Activity { Name = "A1", StartTime = 1, EndTime = 4 },
            new Activity { Name = "A2", StartTime = 2, EndTime = 9 },
            new Activity { Name = "A3", StartTime = 7, EndTime = 15 },
            new Activity { Name = "A4", StartTime = 5, EndTime = 8 },
            new Activity { Name = "A5", StartTime = 10, EndTime = 18 },
            new Activity { Name = "A6", StartTime = 16, EndTime = 17 },
            new Activity { Name = "A7", StartTime = 21, EndTime = 27 },
            new Activity { Name = "A8", StartTime = 23, EndTime = 30 }
            };

            List<Activity> selectedActivities = MaxActivities(activities);

                Console.WriteLine("Các cuộc họp được chọn là:");
            foreach (var activity in selectedActivities)
            {
                Console.Write(activity.Name + " ");
            }
        }
    }
}
