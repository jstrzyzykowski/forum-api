using ForumAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI
{
    public class ThreadSeeder
    {
        private readonly ThreadContext _threadContext;

        public ThreadSeeder(ThreadContext threadContext)
        {
            _threadContext = threadContext;
        }

        public void Seed()
        {
            if (!_threadContext.Threads.Any())
            {
                InsertSampleData();
            }
        }

        private void InsertSampleData()
        {
            var threads = new List<Thread>
            {
                new Thread
                {
                    Subject = "Can't finish KnightMaster Quest >>HELP<<",
                    AddDate = DateTime.Now.AddDays(-7),
                    UpdateDate = DateTime.Now.AddDays(-6),
                    Author = "RiderProtector",
                    Content = "Hello guys! after I killed 100 demons and filled the bottle with holy water from a well, the NPC still won't talk to me, what's wrong?",
                    Comments = new List<Comment>
                    {
                        new Comment
                        {
                            AddDate = DateTime.Now.AddDays(-6),
                            UpdateDate = DateTime.Now.AddDays(-6),
                            Author = "Slasher",
                            Content = "From which well did you fill vial with holy water? Coz there are 3 wells mate, on the left side is the correct well"
                        },
                        new Comment
                        {
                            AddDate = DateTime.Now.AddDays(-6),
                            UpdateDate = DateTime.Now.AddDays(-6),
                            Author = "Vipper",
                            Content = "Yeah, like said Slasher - in addition, u need a special vial from Ron's magic shop"
                        }
                    }
                },
                new Thread
                {
                    Subject = "Exactly ServerSave Time",
                    AddDate = DateTime.Now.AddDays(-4),
                    UpdateDate = DateTime.Now.AddDays(-4),
                    Author = "TakeItEasy",
                    Content = "Guys, when exactly global server is saving in UTC ?? It's 11 at point ? Thanks",
                    Comments = new List<Comment>
                    {
                        new Comment
                        {
                            AddDate = DateTime.Now.AddDays(-4),
                            UpdateDate = DateTime.Now.AddDays(-4),
                            Author = "Breezy",
                            Content = "ye, imo it's 11 UTC"
                        },
                        new Comment
                        {
                            AddDate = DateTime.Now.AddDays(-4),
                            UpdateDate = DateTime.Now.AddDays(-4),
                            Author = "Liero",
                            Content = "11 utc"
                        },
                        new Comment
                        {
                            AddDate = DateTime.Now.AddDays(-4),
                            UpdateDate = DateTime.Now.AddDays(-4),
                            Author = "Sansh",
                            Content = "nah, its messaging from 10:40, 10:59 server is off so not exactly 11"
                        },
                        new Comment
                        {
                            AddDate = DateTime.Now.AddDays(-4),
                            UpdateDate = DateTime.Now.AddDays(-4),
                            Author = "Rooz",
                            Content = "Sansh true. Last warning is on 10:55 UTC, 10:59 is off"
                        }
                    }
                }
            };


            _threadContext.AddRange(threads);
            _threadContext.SaveChanges();
        }
    }
}
