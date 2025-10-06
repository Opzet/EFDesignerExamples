using EventSourcingTutorial;
using EventSourcingTutorial.Events;

var studentDatabase = new StudentDatabase();
var studentId = Guid.Parse("410efa39-917b-45d4-83ff-f9a618d760a3");

while (true)
{

    Console.WriteLine("\r\n--------------\r\nChoose an option\r\n--------------");
    Console.WriteLine("1. Create Student");
    Console.WriteLine("2. Enroll Student in Course");
    Console.WriteLine("3. Update Student Information");
    Console.WriteLine("4. Show Student View");

    Console.WriteLine("5. Show Student Event Timeline");

    Console.WriteLine("0. Exit");
    var choice = Console.ReadLine();
    Console.Clear();
   
    switch (choice)
    {
        case "1":
            var studentCreated = new StudentCreated
            {
                StudentId = studentId,
                Email = "nick.smith@xyz.com",
                FullName = "Nick Smith",
                DateOfBirth = new DateTime(1993, 1, 1)
            };
            await studentDatabase.AppendAsync(studentCreated);
            Console.WriteLine($"Student Created: {studentCreated.FullName}, {studentCreated.Email}, {studentCreated.DateOfBirth}");
            break;

        case "2":   
            var studentEnrolled = new StudentEnrolled
            {
                StudentId = studentId,
                CourseName = "EDA, CRUD and REST APIs in .NET"
            };
            await studentDatabase.AppendAsync(studentEnrolled);
            Console.WriteLine($"Student Enrolled: {studentEnrolled.CourseName}");
            break;

        case "3":
            var studentUpdated = new StudentUpdated
            {
                StudentId = studentId,
                Email = "nick.smith@xyz.com",
                FullName = "Nick Smith"
            };
            await studentDatabase.AppendAsync(studentUpdated);
            Console.WriteLine($"Student Updated: {studentUpdated.FullName}, {studentUpdated.Email}");
            break;

        case "4":
            var student = await studentDatabase.GetStudentAsync(studentId);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                break;
            }
            var enrolledCourses = string.Join(", ", student.EnrolledCourses);
            // Show Student View
            Console.WriteLine("Final Student State:");
            Console.WriteLine("\tFull Name: \t" + student.FullName);
            Console.WriteLine("\tEmail: \t\t" + student.Email);
            Console.WriteLine("\tDate of Birth: \t" + student.DateOfBirth.ToShortDateString());
            Console.WriteLine("\tEnrolled Courses: " + enrolledCourses);

            break;

            case "5":
            // Show timelime in ASCII art of Events history for all
            var timeline = await studentDatabase.GetAllEventsAsync(studentId);
            //Render ASCII timeline
            RenderTimeline(timeline);
            //Console.WriteLine(
            break;

          

        case "0":
            return;
    }
}

void RenderTimeline(List<Event> timeline)
{
    Console.WriteLine("Student Event Timeline:");
    Console.WriteLine("-----------------------");

    foreach (var @event in timeline.OrderBy(e => e.CreatedAtUtc))
    {
        Console.WriteLine($"| {@event.CreatedAtUtc:yyyy-MM-dd HH:mm:ss} | {@event.GetType().Name}");
    }

    Console.WriteLine("-----------------------");
}
