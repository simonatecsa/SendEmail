﻿using System;

namespace SendingEmail
{
    public class HolidayRequest
    {
        // These properties can and *should* be private
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
        public string ManagerEmail { get; set; }

        public HolidayPeriod HolidayPeriod { get; set; }

        public HolidayRequestStatus Status { get; set; }

        public HolidayRequest(string employeeName, string employeeEmail, string managerEmail, DateTime from, DateTime to)
        {
            EmployeeName = employeeName;
            EmployeeEmail = employeeEmail;
            ManagerEmail = managerEmail;
            HolidayPeriod.From = from;
            HolidayPeriod.To = to;

            // What is the status of a created but not submitted request?
        }

        // This is unused.
        public HolidayRequest()
        {
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

            var email = new EmailServer();
            email.SendEmail(EmployeeEmail, ManagerEmail, subject, body);
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

            // Name: email = new EmailServer?
            // I would call the class Email and the method Send()
            var email = new EmailServer();
            // This should be from the manager to the HR
            email.SendEmail(EmployeeEmail, ManagerEmail, subject, body);
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

            var email = new EmailServer();
            email.SendEmail(ManagerEmail, EmployeeEmail, subject, body);
        }
    }
}
