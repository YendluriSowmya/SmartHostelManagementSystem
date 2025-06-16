using SmartHostelManagementSystem.Models;
using SmartHostelManagementSystem.Services;


var studentService = new StudentService();
var roomService = new RoomService();
var feeService = new FeeService();
var complaintService = new ComplaintService();

while (true)
{
    Console.WriteLine("\n📋 MENU");
    Console.WriteLine("1. Register Student");
    Console.WriteLine("2. Allocate Room");
    Console.WriteLine("3. Pay Fee");
    Console.WriteLine("4. Register Complaint");
    Console.WriteLine("5. Show Fee Defaulters");
    Console.WriteLine("6. Show Complaints by Status");
    Console.WriteLine("7. Exit");
    Console.Write("Choose: ");
    var input = Console.ReadLine();

    try
    {
        switch (input)
        {
            case "1":
                Console.Write("Name: ");
                string name = Console.ReadLine()!;
                Console.Write("Email: ");
                string email = Console.ReadLine()!;
                await studentService.AddStudentAsync(new Student { Name = name, Email = email});
                break;

            case "2":
                var students = await studentService.GetAllAsync();
                var last = students.Last();
                await roomService.AllocateRoomAsync(last);
                Console.WriteLine($"Room allocated to {last.Name}");
                break;

            case "3":
                Console.Write("Student ID: ");
                int id = int.Parse(Console.ReadLine()!);
                Console.Write("Amount: ");
                decimal amount = decimal.Parse(Console.ReadLine()!);
                await feeService.AddPaymentAsync(new FeeRecord { StudentId = id, Amount = amount, PaymentDate = DateTime.Now });
                break;

            case "4":
                Console.Write("Student ID: ");
                int cid = int.Parse(Console.ReadLine()!);
                Console.Write("Issue: ");
                string desc = Console.ReadLine()!;
                await complaintService.RegisterComplaintAsync(new Complaint { StudentId = cid, Description = desc });
                break;

            case "5":
                var allStudents = await studentService.GetAllAsync();
                var defaulters = await feeService.GetFeeDefaultersAsync(allStudents);
                Console.WriteLine("Fee Defaulters:");
                foreach (var d in defaulters)
                    Console.WriteLine($"Student ID: {d.StudentId}");
                break;

            case "6":
                Console.Write("Enter Status (Open/InProgress/Resolved): ");
                string status = Console.ReadLine()!;
                var list = await complaintService.GetByStatusAsync(status);
                list.ForEach(c => Console.WriteLine($"Complaint {c.ComplaintId} - {c.Description}"));
                break;

            case "7":
                return;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Error: {ex.Message}");
    }
}

