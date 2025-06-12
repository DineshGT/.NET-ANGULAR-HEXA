using System;
using EventAppDAL;
using EventAppDAL.Models;
using EventAppDAL.Repositories;
using EventUIApp;
using UIApp.BusinessLogic;

namespace UIApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new EventDbContext();

            // Repositories
            var userRepo = new UserInfoRepository(context);
            var eventRepo = new EventDetailsRepository(context);
            var sessionRepo = new SessionInfoRepository(context);

            // Business Logic Layer
            var userBL = new UserInfoBL(userRepo);
            var eventBL = new EventDetailsBL(eventRepo);
            var sessionBL = new SessionInfoBL(sessionRepo);

            while (true)
            {
                Console.WriteLine("\n--- Main Menu ---");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. View All Users");
                Console.WriteLine("3. Add Event (SP)");
                Console.WriteLine("4. Update Event (SP)");
                Console.WriteLine("5. Delete Event (SP)");
                Console.WriteLine("6. View All Events");
                Console.WriteLine("7. Add Session");
                Console.WriteLine("8. View Sessions by EventId");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        var user = new UserInfo
                        {
                            EmailId = "abc@example.com",
                            UserName = "ABC",
                            Role = "Admin",
                            Password = "pass123"
                        };
                        userBL.AddUser(user);
                        Console.WriteLine("User added.");
                        break;

                    case "2":
                        var users = userBL.GetAllUsers();
                        foreach (var u in users)
                            Console.WriteLine($"{u.EmailId} - {u.UserName} - {u.Role}");
                        break;

                    case "3":
                        var evt = new EventDetails
                        {
                            EventName = "AI Meet",
                            EventCategory = "Tech",
                            EventDate = DateTime.Now.AddDays(7),
                            Description = "Future of AI",
                            Status = "Active"
                        };
                        eventBL.AddEventUsingSP(evt);
                        Console.WriteLine("Event inserted using SP.");
                        break;

                    case "4":
                        var updatedEvt = new EventDetails
                        {
                            EventId = 1, // existing ID
                            EventName = "AI Meet - Updated",
                            EventCategory = "Technology",
                            EventDate = DateTime.Now.AddDays(8),
                            Description = "Updated description",
                            Status = "Active"
                        };
                        eventBL.UpdateEventUsingSP(updatedEvt);
                        Console.WriteLine("Event updated using SP.");
                        break;

                    case "5":
                        Console.Write("Enter EventId to delete: ");
                        int delId = int.Parse(Console.ReadLine());
                        eventBL.DeleteEventUsingSP(delId);
                        Console.WriteLine("Event deleted.");
                        break;

                    case "6":
                        var events = eventBL.GetAllEvents();
                        foreach (var e in events)
                            Console.WriteLine($"{e.EventId} - {e.EventName} - {e.Status}");
                        break;

                    case "7":
                        var session = new SessionInfo
                        {
                            EventId = 1,
                            SessionTitle = "Intro to AI",
                            SpeakerId = 1,
                            Description = "Basics of AI",
                            SessionStart = DateTime.Now.AddHours(1),
                            SessionEnd = DateTime.Now.AddHours(2),
                            SessionUrl = "http://session.ai"
                        };
                        sessionBL.AddSession(session);
                        Console.WriteLine("Session added.");
                        break;

                    case "8":
                        Console.Write("Enter EventId to view sessions: ");
                        int eId = int.Parse(Console.ReadLine());
                        var sessions = sessionBL.GetSessionsByEventId(eId);
                        foreach (var s in sessions)
                            Console.WriteLine($"{s.SessionId} - {s.SessionTitle} - {s.SessionStart} to {s.SessionEnd}");
                        break;

                    case "0":
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
