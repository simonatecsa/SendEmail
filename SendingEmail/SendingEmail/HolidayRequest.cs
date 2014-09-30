using System;

namespace SendingEmail
{
    public class HolidayRequest
    {
        private string EmployeeName { get; set; }
        private string EmployeeEmail { get; set; }
        private string ManagerEmail { get; set; }

        private HolidayPeriod HolidayPeriod { get; set; }

        private HolidayRequestStatus Status { get; set; }

        public HolidayRequest(string employeeName, string employeeEmail, string managerEmail, DateTime from, DateTime to)
        {
            EmployeeName = employeeName;
            EmployeeEmail = employeeEmail;
            ManagerEmail = managerEmail;
            HolidayPeriod.From = from;
            HolidayPeriod.To = to;

            Status = HolidayRequestStatus.NotSubmitted;
        }

        public void SubmitForApproval()
        {
            Status = HolidayRequestStatus.Pending;
            SendEmailToManager();
        }

        private void SendEmailToManager()
        {
            string subject = "Holliday request";
            string body = string.Format("I want to take a vacation in the period from {0} to {1}", HolidayPeriod.From, HolidayPeriod.To);

            var email = new Email();
            email.Send(EmployeeEmail, ManagerEmail, subject, body);
        }

        public void Approve()
        {
            Status = HolidayRequestStatus.Approved;
            SendEmailToHR();           
        }

        private void SendEmailToHR()
        {
            string subject = "OK";
            string body = string.Format("It is ok in the period from {0} to {1}", HolidayPeriod.From, HolidayPeriod.To );
            string HREmail = "hr@iquest.com";

            var email = new Email();
            email.Send(ManagerEmail, HREmail, subject, body);
        }

        public void Reject()
        {
            Status = HolidayRequestStatus.Rejected;
            SendEmailBackToEmployee();
        }

        private void SendEmailBackToEmployee()
        {
            string subject = "NOT OK";
            string body = string.Format("It is not ok in the period from {0} to {1}", HolidayPeriod.From, HolidayPeriod.To);

            var email = new Email();
            email.Send(ManagerEmail, EmployeeEmail, subject, body);
        }
    }
}
