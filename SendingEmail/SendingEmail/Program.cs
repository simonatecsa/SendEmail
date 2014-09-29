using System;

namespace SendingEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            var hollidayRequest = new HolidayRequest("Simona", "employee@iquest.com", "manager@iquest.com", DateTime.Now, DateTime.Now.AddDays(3));
            hollidayRequest.SubmitForApproval();

            //the manager approves or rejects the request

        }
    }
}
